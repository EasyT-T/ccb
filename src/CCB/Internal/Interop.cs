namespace CCB.Internal;

using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using CCB.Extensions;

internal static class Interop
{
    private static Loader? loader;

    private static ModuleHandle eventHandle;

    [UnmanagedCallersOnly]
    public static void Load()
    {
        try
        {
            SynchronizationContext.SetSynchronizationContext(MainThreadContext.Instance);

            RegisterAssemblyPath();
            RegisterScript();
            RegisterEvents();

            StartLoader();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }
    }

    private static void StartLoader()
    {
        loader = new Loader();
        loader.LoadAllPlugins();
    }

    private static void RegisterScript()
    {
        var scriptHandle = ModuleHandle.FromScript("script.as", "./ccb/script.as");

        ExecuteHelper.ScriptHandle = scriptHandle;
    }

    private static void RegisterEvents()
    {
        EventRegistry.RegisterEventFunctions();

        eventHandle = ModuleHandle.FromScript("event.as", "./ccb/event.as");
        ExecuteContext.FromDeclaration("void OnInitialize()", eventHandle).Execute();

        EventRegistry.ServerUpdate += MainThreadContext.Instance.Update;
    }

    private static void RegisterAssemblyPath()
    {
        var currentAssembly = Assembly.GetExecutingAssembly();

        AssemblyLoadContext.Default.Resolving += (context, assemblyName) =>
        {
            if (assemblyName.Name == currentAssembly.GetName().Name)
            {
                return currentAssembly;
            }

            var dependenciesPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "ccb",
                "dependencies",
                assemblyName.Name + ".dll");

            return File.Exists(dependenciesPath) ? context.LoadFromAssemblyPath(dependenciesPath) : null;
        };

        AssemblyLoadContext.Default.ResolvingUnmanagedDll += (_, assemblyName) =>
        {
            if (!Path.HasExtension(assemblyName))
            {
                assemblyName += ".dll";
            }

            var dependenciesPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "ccb",
                "dependencies",
                assemblyName);

            return File.Exists(dependenciesPath) ? NativeLibrary.Load(assemblyName) : IntPtr.Zero;
        };
    }
}