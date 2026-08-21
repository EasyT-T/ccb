namespace CCB.Internal;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct ModuleHandle(IntPtr handle)
{
    private readonly IntPtr _handle = handle;
}