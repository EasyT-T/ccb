namespace CCB.Internal;

using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using Serilog;

public class MainThreadContext : SynchronizationContext
{
    private readonly Lock _lock = new Lock();
    private List<(SendOrPostCallback, object?)> _tasks = new List<(SendOrPostCallback, object?)>(64);
    private List<(SendOrPostCallback, object?)> _spare = new List<(SendOrPostCallback, object?)>(64);
    private volatile int _pendingCount;

    private readonly int _mainThreadId;

    private MainThreadContext(int mainThreadId)
    {
        this._mainThreadId = mainThreadId;
    }

    public static MainThreadContext Instance { get; private set; } = null!;

    public bool IsMainThread => this._mainThreadId == Environment.CurrentManagedThreadId;

    internal static void Initialize()
    {
        Instance = new MainThreadContext(Environment.CurrentManagedThreadId);
        SetSynchronizationContext(Instance);
    }

    public override void Post(SendOrPostCallback d, object? state)
    {
        lock (this._lock)
        {
            this._tasks.Add((d, state));
            this._pendingCount = this._tasks.Count;
        }
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

        lock (this._lock)
        {
            this._tasks.Add((s =>
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

            this._pendingCount = this._tasks.Count;
        }

        completionEvent.Wait();

        if (exception is not null)
        {
            ExceptionDispatchInfo.Capture(exception).Throw();
        }
    }

    internal void Update()
    {
        if (this._pendingCount == 0)
        {
            return;
        }

        List<(SendOrPostCallback, object?)> tasks;

        lock (this._lock)
        {
            if (this._tasks.Count == 0)
            {
                return;
            }

            tasks = this._tasks;
            this._tasks = this._spare;
            this._spare = tasks;
            this._pendingCount = 0;
        }

        foreach (var task in tasks)
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

        tasks.Clear();
    }
}