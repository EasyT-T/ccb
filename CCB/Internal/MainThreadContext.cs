namespace CCB.Internal;

using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using Serilog;

public class MainThreadContext : SynchronizationContext
{
    private readonly ConcurrentQueue<(SendOrPostCallback, object?)> _tasks = [];
    private readonly int _mainThreadId;

    private MainThreadContext(int mainThreadId)
    {
        this._mainThreadId = mainThreadId;
    }

    public static MainThreadContext Instance => field ??= new MainThreadContext(Environment.CurrentManagedThreadId);

    public bool IsMainThread => this._mainThreadId == Environment.CurrentManagedThreadId;

    public override void Post(SendOrPostCallback d, object? state)
    {
        this._tasks.Enqueue((d, state));
    }

    public override void Send(SendOrPostCallback d, object? state)
    {
        if (this.IsMainThread)
        {
            d.Invoke(state);
            return;
        }

        using var completionEvent = new ManualResetEventSlim(false);
        Exception? exception = null;

        this._tasks.Enqueue((s =>
        {
            try
            {
                d.Invoke(s);
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                completionEvent.Set();
            }
        }, state));

        completionEvent.Wait();

        if (exception is not null)
        {
            ExceptionDispatchInfo.Capture(exception).Throw();
        }
    }

    internal void Update()
    {
        foreach (var task in this._tasks)
        {
            try
            {
                task.Item1(task.Item2);
            }
            catch (Exception e)
            {
                Log.Error(e, "Unexpected exception thrown while updating synchronize context.");
            }
        }

        this._tasks.Clear();
    }
}