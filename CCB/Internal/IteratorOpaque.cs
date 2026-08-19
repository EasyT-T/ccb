namespace CCB.Internal;

using System.Runtime.InteropServices;

// Every iterable object has its own IteratorOpaque
// Mix them up may cause MAV
// Share the same struct here because we don't need to access their native memory manually
[StructLayout(LayoutKind.Sequential, Size = 12)]
public struct IteratorOpaque
{
    public static IteratorOpaque Create(ObjectHandle handle)
    {
        return Marshal.PtrToStructure<IteratorOpaque>(handle.Pointer);
    }
}