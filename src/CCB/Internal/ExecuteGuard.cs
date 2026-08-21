namespace CCB.Internal;

using CommunityToolkit.Diagnostics;

internal static class ExecuteGuard
{
    public static void IsOnMainThread()
    {
        if (MainThreadContext.Instance.IsMainThread)
        {
            return;
        }

        ThrowHelper.ThrowInvalidOperationException("Script functions must be called on main thread.");
    }

    public static void IsFunctionExists(int functionIndex)
    {
        Guard.IsGreaterThan(functionIndex, 0, "Function Index");
    }

    public static void IsSuccess(int errorCode)
    {
        Guard.IsGreaterThanOrEqualTo(errorCode, 0, "Error Code");
    }

    public static void IsNotNullptr(IntPtr pointer)
    {
        if (pointer != IntPtr.Zero)
        {
            return;
        }

        ThrowHelper.ThrowArgumentNullException(nameof(pointer));
    }

    public static void IsNotNullptr(ObjectHandle handle)
    {
        if (handle != null)
        {
            return;
        }

        ThrowHelper.ThrowArgumentNullException(nameof(handle));
    }

    public static void IsNotNullptr<T>(T value) where T : IScriptObject
    {
        IsNotNullptr(value.Handle);
    }
}