namespace CCB.Internal;

using System.Runtime.InteropServices;

// Every iterable object has its own IteratorOpaque
// Mix them up may cause MAV
// Share the same struct here because we don't need to access their native memory manually
[StructLayout(LayoutKind.Sequential, Size = 12)]
public struct IteratorOpaque
{
    public static unsafe IteratorOpaque Create(string declaration)
    {
        var result = ExecuteContext
            .FromDeclaration(declaration)
            .Execute();

        var handle = result.GetObject();

        ExecuteGuard.IsNotNullptr(handle);

        return *(IteratorOpaque*)handle.Pointer;
    }

    public unsafe T Get<T>(string declaration) where T : IScriptObject
    {
        fixed (IteratorOpaque* ptr = &this)
        {
            var result = ExecuteContext
                .FromDeclaration(declaration)
                .WithArgument(0, (IntPtr)ptr)
                .Execute();

            return result.GetObject<T>();
        }
    }

    public unsafe void Advance(string declaration)
    {
        fixed (IteratorOpaque* ptr = &this)
        {
            ExecuteContext
                .FromDeclaration(declaration)
                .WithArgument(0, (IntPtr)ptr)
                .Execute();
        }
    }

    public unsafe bool IsNull(string declaration)
    {
        fixed (IteratorOpaque* ptr = &this)
        {
            var result = ExecuteContext
                .FromDeclaration(declaration)
                .WithArgument(0, (IntPtr)ptr)
                .Execute();

            return result.GetBool();
        }
    }
}