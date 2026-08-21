namespace CCB.Internal;

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

[StructLayout(LayoutKind.Sequential)]
internal struct StringHandle(IntPtr pointer) : IDisposable
{
    private IntPtr _pointer = pointer;

    public static unsafe StringHandle Create(string value)
    {
        var pointer = (IntPtr)Utf8StringMarshaller.ConvertToUnmanaged(value);

        return new StringHandle(pointer);
    }

    public static unsafe implicit operator string(StringHandle handle)
    {
        var ptr = (byte*)handle._pointer.ToPointer();
        var str = Utf8StringMarshaller.ConvertToManaged(ptr);

        return str ?? throw new ArgumentNullException(nameof(handle));
    }

    public unsafe void Dispose()
    {
        Utf8StringMarshaller.Free((byte*)this._pointer);
    }
}