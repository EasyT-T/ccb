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
        Guard.IsTrue(pointer != IntPtr.Zero);
    }

    public static void IsNotNullptr(ObjectHandle handle)
    {
        Guard.IsTrue(handle.Pointer != IntPtr.Zero);
    }
}