namespace CCB.Internal;

public readonly ref struct ExecuteContext : IDisposable
{
    private readonly ModuleHandle _module;

    private readonly List<StringHandle> _stringHandles;

    private ExecuteContext(ModuleHandle moduleModule, List<StringHandle> stringHandles)
    {
        this._module = moduleModule;
        this._stringHandles = stringHandles;
    }

    private ExecuteContext(ModuleHandle moduleModule) : this(moduleModule, [])
    {
    }

    public static ExecuteContext FromDeclaration(string declaration)
    {
        return FromDeclaration(declaration, ExecuteHelper.ScriptHandle);
    }

    public static ExecuteContext FromDeclaration(string declaration, ModuleHandle handle)
    {
        ExecuteHelper.PrepareFunction(declaration, handle, isDecl: true);

        return new ExecuteContext(handle);
    }

    public ExecuteContext WithArgument(int index, bool value)
    {
        var errCode = NativeBindings.SetModuleArgBoolean(this._module, index, value);

        ExecuteGuard.IsSuccess(errCode);

        return this;
    }

    public ExecuteContext WithArgument(int index, byte value)
    {
        var errCode = NativeBindings.SetModuleArgByte(this._module, index, value);

        ExecuteGuard.IsSuccess(errCode);

        return this;
    }

    public ExecuteContext WithArgument(int index, short value)
    {
        var errCode = NativeBindings.SetModuleArgShort(this._module, index, value);

        ExecuteGuard.IsSuccess(errCode);

        return this;
    }

    public ExecuteContext WithArgument(int index, int value)
    {
        var errCode = NativeBindings.SetModuleArgInt(this._module, index, value);

        ExecuteGuard.IsSuccess(errCode);

        return this;
    }

    public ExecuteContext WithArgument(int index, uint value)
    {
        var errCode = NativeBindings.SetModuleArgUInt(this._module, index, value);

        ExecuteGuard.IsSuccess(errCode);

        return this;
    }

    public ExecuteContext WithArgument(int index, long value)
    {
        var high = (int)(value >> 32);
        var low = (int)value;

        var errCode = NativeBindings.SetModuleArgInt64(this._module, index, high, low);

        ExecuteGuard.IsSuccess(errCode);

        return this;
    }

    public ExecuteContext WithArgument(int index, float value)
    {
        var errCode = NativeBindings.SetModuleArgFloat(this._module, index, value);

        ExecuteGuard.IsSuccess(errCode);

        return this;
    }

    public ExecuteContext WithArgument(int index, string value)
    {
        var handle = StringHandle.Create(value);

        try
        {
            var errCode = NativeBindings.SetModuleArgString(this._module, index, handle);

            ExecuteGuard.IsSuccess(errCode);
        }
        catch (Exception)
        {
            handle.Dispose();
            throw;
        }

        this._stringHandles.Add(handle);

        return this;
    }

    public ExecuteContext WithArgument<T>(int index, T value) where T : IScriptObject
    {
        var errCode = NativeBindings.SetModuleArgObject(this._module, index, value.Handle);

        ExecuteGuard.IsSuccess(errCode);

        return this;
    }

    public ExecuteContext WithArgument(int index, IntPtr value)
    {
        var errCode = NativeBindings.SetModuleArgAddress(this._module, index, value);

        ExecuteGuard.IsSuccess(errCode);

        return this;
    }

    public ExecuteResult Execute()
    {
        try
        {
            var errCode = NativeBindings.ExecuteModuleFunction(this._module);

            ExecuteGuard.IsSuccess(errCode);

            return new ExecuteResult(this._module);
        }
        finally
        {
            this.Dispose();
        }
    }

    public void Dispose()
    {
        foreach (var stringHandle in this._stringHandles)
        {
            stringHandle.Dispose();
        }

        this._stringHandles.Clear();
    }
}