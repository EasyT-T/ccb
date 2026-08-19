namespace CCB.Internal;

using CommunityToolkit.Diagnostics;

internal static class InvokeGuard
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
}