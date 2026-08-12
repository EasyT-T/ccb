namespace CCB.Internal;

internal class FunctionRegistry
{
    public static FunctionRegistry Singleton => field ??= new FunctionRegistry(Environment.CurrentManagedThreadId);

    private readonly int _threadId;

    private readonly Dictionary<MethodMetadata, nint> _functions = [];

    private FunctionRegistry(int threadId)
    {
        this._threadId = threadId;
    }

    public void RegisterMethod(MethodMetadata metadata, nint functionPtr)
    {
        this._functions[metadata] = functionPtr;
    }

    public nint GetFunction(MethodMetadata metadata)
    {
        if (this._threadId != Environment.CurrentManagedThreadId)
        {
            throw new InvalidOperationException("Script function must be called from main thread.");
        }

        return this._functions[metadata];
    }
}