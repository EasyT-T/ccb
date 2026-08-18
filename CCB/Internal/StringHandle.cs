namespace CCB.Internal;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal ref struct StringHandle(ObjectHandle handle)
{
    private ObjectHandle _handle = handle;

    public static unsafe implicit operator string(StringHandle handle)
    {
        var pointerToStr = (char**)handle._handle.Pointer.ToPointer();
        var str = Marshal.PtrToStringUTF8((IntPtr)(*pointerToStr));

        return str ?? throw new ArgumentNullException(nameof(handle));
    }
}