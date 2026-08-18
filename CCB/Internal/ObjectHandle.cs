namespace CCB.Internal;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct ObjectHandle(IntPtr pointer)
{
    public IntPtr Pointer { get; } = pointer;
}