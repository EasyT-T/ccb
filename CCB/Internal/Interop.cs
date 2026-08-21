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
            var moduleHandle = NativeBindings.GetExecutedModule();

            ExecuteHelper.ModuleHandle = moduleHandle;

            EventRegistry.RegisterEventFunctions();

            eventHandle = ModuleHandle.FromScript("event.as", "./ccb/event.as");
            ExecuteContext.FromDeclaration("void OnInitialize()", eventHandle).Execute();

            var currentAssembly = Assembly.GetExecutingAssembly();
            SynchronizationContext.SetSynchronizationContext(MainThreadContext.Instance);

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

            EventRegistry.ServerUpdate += MainThreadContext.Instance.Update;

            loader = new Loader();

            loader.LoadAllPlugins();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }
    }

    [UnmanagedCallersOnly]
    public static void RegisterMethod(int index, nint classNamePtr, nint methodNamePtr, nint functionPtr)
    {
    }
}