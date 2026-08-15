namespace CCB.Internal;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
public readonly struct ObjectHandle(IntPtr handle)
{
    public IntPtr Handle { get; } = handle;
}