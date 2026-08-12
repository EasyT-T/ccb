namespace CCB.Internal;

using System.Runtime.InteropServices;

public static class Interop
{
    [UnmanagedCallersOnly]
    public static void RegisterMethod(int index, nint classNamePtr, nint methodNamePtr, nint functionPtr)
    {
        var className = Marshal.PtrToStringUTF8(classNamePtr);
        var methodName = Marshal.PtrToStringUTF8(methodNamePtr);
    }
}