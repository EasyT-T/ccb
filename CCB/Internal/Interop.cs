namespace CCB.Internal;

using System.Diagnostics;
using System.Runtime.InteropServices;

internal static class Interop
{
    [UnmanagedCallersOnly]
    public static void Load()
    {
        while (!Debugger.IsAttached)
        {
            Thread.Sleep(100);
        }

        var moduleHandle = NativeBindings.GetExecutedModule();

        ScriptFunctions.ModuleHandle = moduleHandle;
    }

    [UnmanagedCallersOnly]
    public static void RegisterMethod(int index, nint classNamePtr, nint methodNamePtr, nint functionPtr)
    {
    }
}