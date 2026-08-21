namespace CCB.Extensions;

using CCB.Abstractions;
using CCB.Services;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddCcb()
        {
            return services
                .AddSingleton<IConfigLoader, FileConfigLoader>()
                .AddSingleton(typeof(IConfigProvider<>), typeof(ConfigProvider<>))
                .AddSingleton<IPathProvider, PathProvider>()
                .AddSingleton<IObjectSerializer, JsonObjectSerializer>();
        }
    }
}