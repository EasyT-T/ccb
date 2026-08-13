namespace CCB.Internal;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal struct ModuleHandle
{
    private IntPtr _handle;
}