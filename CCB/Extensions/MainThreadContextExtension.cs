namespace CCB.Extensions;

using CCB.Internal;

public static class MainThreadContextExtension
{
    extension(MainThreadContext)
    {
        public static void RunOnMainThread(
            Action<CancellationToken> func,
            CancellationToken cancellationToken = default)
        {
            if (MainThreadContext.Instance.IsMainThread)
            {
                func(cancellationToken);

                return;
            }

            MainThreadContext.Instance.Send(_ => func(cancellationToken), null);
        }

        public static Task RunOnMainThreadAsync(
            Action<CancellationToken> func,
            CancellationToken cancellationToken = default)
        {
            if (MainThreadContext.Instance.IsMainThread)
            {
                try
                {
                    func(cancellationToken);

                    return Task.CompletedTask;
                }
                catch (Exception e)
                {
                    return Task.FromException(e);
                }
            }

            var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

            CancellationTokenRegistration ctr = default;
            if (cancellationToken.CanBeCanceled)
            {
                ctr = cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken));
            }

            MainThreadContext.Instance.Post(
                void (_) =>
                {
                    try
                    {
                        func(cancellationToken);
                        tcs.SetResult();
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        tcs.TrySetCanceled(cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                    finally
                    {
                        ctr.Dispose();
                    }
                },
                null);

            return tcs.Task;
        }

        public static Task RunOnMainThreadAsync(
            Func<CancellationToken, Task> func,
            CancellationToken cancellationToken = default)
        {
            if (MainThreadContext.Instance.IsMainThread)
            {
                return func(cancellationToken);
            }

            var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

            CancellationTokenRegistration ctr = default;
            if (cancellationToken.CanBeCanceled)
            {
                ctr = cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken));
            }

            MainThreadContext.Instance.Post(
                async void (_) =>
                {
                    try
                    {
                        await func(cancellationToken).ConfigureAwait(true);
                        tcs.SetResult();
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        tcs.TrySetCanceled(cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                    finally
                    {
                        await ctr.DisposeAsync();
                    }
                },
                null);

            return tcs.Task;
        }

        public static Task<T> RunOnMainThreadAsync<T>(
            Func<CancellationToken, Task<T>> func,
            CancellationToken cancellationToken = default)
        {
            if (MainThreadContext.Instance.IsMainThread)
            {
                return func(cancellationToken);
            }

            var tcs = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);

            CancellationTokenRegistration ctr = default;
            if (cancellationToken.CanBeCanceled)
            {
                ctr = cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken));
            }

            MainThreadContext.Instance.Post(
                async void (_) =>
                {
                    try
                    {
                        var result = await func(cancellationToken).ConfigureAwait(true);
                        tcs.TrySetResult(result);
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        tcs.TrySetCanceled(cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        tcs.TrySetException(ex);
                    }
                    finally
                    {
                        await ctr.DisposeAsync();
                    }
                },
                null);

            return tcs.Task;
        }
    }
}