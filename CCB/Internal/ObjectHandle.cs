namespace CCB.Internal;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct ObjectHandle(IntPtr pointer)
{
    public static ObjectHandle Null => new ObjectHandle(IntPtr.Zero);

    public IntPtr Pointer { get; } = pointer;
}