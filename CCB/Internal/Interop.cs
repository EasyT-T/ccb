namespace CCB.Internal;

using System.Diagnostics;
using System.Runtime.InteropServices;

internal static class Interop
{
    [UnmanagedCallersOnly]
    public static void RegisterMethod(int index, nint classNamePtr, nint methodNamePtr, nint functionPtr)
    {
        while (!Debugger.IsAttached)
        {
            Thread.Sleep(100);
        }

        var className = Marshal.PtrToStringUTF8(classNamePtr);
        var methodName = Marshal.PtrToStringUTF8(methodNamePtr);

        if (className is null || methodName is null)
        {
            return;
        }

        var metadata = new MethodMetadata(index, className, methodName);

        FunctionRegistry.Singleton.RegisterMethod(metadata, functionPtr);
    }
}