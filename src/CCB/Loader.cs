namespace CCB;

using System.Reflection;
using System.Runtime.Loader;
using CCB.Abstractions;
using CCB.Attributes;
using CCB.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

public partial class Loader
{
    private readonly ServiceCollection _serviceCollection = new ServiceCollection();

    private readonly List<IPluginMetadata> _plugins = [];

    private IServiceProvider? _serviceProvider;

    public IEnumerable<IPluginMetadata> Plugins => this._plugins;

    internal Loader()
    {
        var logger = new LoggerConfiguration().WriteTo.Console(standardErrorFromLevel: LogEventLevel.Verbose).MinimumLevel.Verbose().CreateLogger();
        Log.Logger = logger;

        this._serviceCollection.AddCcb();
        this._serviceCollection.AddLogging(builder => builder.AddSerilog(logger));
    }

    internal void LoadAllPlugins()
    {
        using var preloadProvider = this._serviceCollection.BuildServiceProvider();
        var pathProvider = preloadProvider.GetRequiredService<IPathProvider>();
        var logger = preloadProvider.GetRequiredService<ILogger<Loader>>();
        var pluginsDirectory = pathProvider.GetPluginsDirectory();

        LogPluginStartLoading(logger, pluginsDirectory);

        foreach (var file in Directory.EnumerateFiles(pluginsDirectory, "*.dll", SearchOption.AllDirectories))
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);

            Type? metadataType = null;
            var injectables = new Dictionary<Type, List<Type>>();

            foreach (var type in assembly.GetTypes())
            {
                if (type.IsAssignableTo(typeof(IPluginMetadata)))
                {
                    if (metadataType is not null)
                    {
                        logger.LogError("Plugin {assembly} has multi metadata!", assembly);
                        break;
                    }

                    metadataType = type;
                }

                if (type.GetCustomAttribute<InjectableAttribute>() != null)
                {
                    injectables[type] = [..type.GetInterfaces()];
                }
            }

            if (metadataType is null)
            {
                LogPluginMetadataNotFound(logger, assembly);
                continue;
            }

            if (Activator.CreateInstance(metadataType) is not IPluginMetadata metadata)
            {
                logger.LogError("Could not create instance of {metadataType}.", metadataType);
                continue;
            }

            this._plugins.Add(metadata);

            foreach (var (injectableType, injectableInterfaces) in injectables)
            {
                this._serviceCollection.AddSingleton(injectableType);

                foreach (var injectableInterface in injectableInterfaces)
                {
                    this._serviceCollection.AddSingleton(injectableInterface, provider => provider.GetRequiredService(injectableType));
                }
            }

            LogPluginRegistered(logger, metadata.Name, metadata.Description, metadata.Author);
        }

        var provider = this._serviceCollection.BuildServiceProvider();

        var preloads = provider.GetServices<IPreload>();

        foreach (var preload in preloads)
        {
            preload.Preload();
        }

        var loads = provider.GetServices<ILoad>();

        foreach (var load in loads)
        {
            load.Load();
        }

        this._serviceProvider = provider;

        LogPluginsLoaded(logger);
    }

    internal void UnloadAllPlugins()
    {
        if (this._serviceProvider is null)
        {
            return;
        }

        var unloads = this._serviceProvider.GetServices<IUnload>();

        foreach (var unload in unloads)
        {
            unload.Unload();
        }

        this._serviceProvider = null;
    }

    [LoggerMessage(LogLevel.Debug, "Start loading plugins from directory {pluginsDirectory}")]
    static partial void LogPluginStartLoading(ILogger<Loader> logger, string pluginsDirectory);

    [LoggerMessage(LogLevel.Debug, "Could not find plugin metadata in {assembly}, it's may a dependency.")]
    static partial void LogPluginMetadataNotFound(ILogger<Loader> logger, Assembly assembly);

    [LoggerMessage(LogLevel.Information, "{pluginName}({pluginDescription}) code by {pluginAuthor} is successfully registered.")]
    static partial void LogPluginRegistered(ILogger<Loader> logger, string pluginName, string pluginDescription, string pluginAuthor);

    [LoggerMessage(LogLevel.Information, "All plugins loaded successfully")]
    static partial void LogPluginsLoaded(ILogger<Loader> logger);
}