namespace CCB.Internal;

using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct ObjectHandle(IntPtr pointer) : IEquatable<ObjectHandle>
{
    public static ObjectHandle Null { get; } = new ObjectHandle(IntPtr.Zero);

    public IntPtr Pointer { get; } = pointer;

    public bool Equals(ObjectHandle other)
    {
        return this.Pointer == other.Pointer;
    }

    public override bool Equals(object? obj)
    {
        return obj is ObjectHandle other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return this.Pointer.GetHashCode();
    }

    public static bool operator ==(ObjectHandle left, ObjectHandle right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ObjectHandle left, ObjectHandle right)
    {
        return !left.Equals(right);
    }

    public static bool operator ==(ObjectHandle left, ObjectHandle? right)
    {
        return right.HasValue ? left.Equals(right.Value) : left.Pointer == IntPtr.Zero;
    }

    public static bool operator !=(ObjectHandle left, ObjectHandle? right)
    {
        return !(left == right);
    }

    public static bool operator ==(ObjectHandle? left, ObjectHandle right)
    {
        return right == left;
    }

    public static bool operator !=(ObjectHandle? left, ObjectHandle right)
    {
        return !(right == left);
    }
}