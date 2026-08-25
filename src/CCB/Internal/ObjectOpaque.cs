namespace CCB.Internal;

using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public readonly struct ObjectOpaque(IntPtr pointer) : IEquatable<ObjectOpaque>
{
    public static ObjectOpaque Null { get; } = new ObjectOpaque(IntPtr.Zero);

    public IntPtr Pointer { get; } = pointer;

    public bool Equals(ObjectOpaque other)
    {
        return this.Pointer == other.Pointer;
    }

    public override bool Equals(object? obj)
    {
        return obj is ObjectOpaque other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return this.Pointer.GetHashCode();
    }

    public static bool operator ==(ObjectOpaque left, ObjectOpaque right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ObjectOpaque left, ObjectOpaque right)
    {
        return !left.Equals(right);
    }

    public static bool operator ==(ObjectOpaque left, ObjectOpaque? right)
    {
        return right.HasValue ? left.Equals(right.Value) : left.Pointer == IntPtr.Zero;
    }

    public static bool operator !=(ObjectOpaque left, ObjectOpaque? right)
    {
        return !(left == right);
    }

    public static bool operator ==(ObjectOpaque? left, ObjectOpaque right)
    {
        return right == left;
    }

    public static bool operator !=(ObjectOpaque? left, ObjectOpaque right)
    {
        return !(right == left);
    }
}