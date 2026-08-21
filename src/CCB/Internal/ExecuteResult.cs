namespace CCB.Internal;

public readonly ref struct ExecuteResult
{
    private readonly ModuleHandle _module;

    internal ExecuteResult(ModuleHandle module)
    {
        this._module = module;
    }

    public bool GetBool()
    {
        return NativeBindings.GetModuleReturnBoolean(this._module);
    }

    public byte GetByte()
    {
        return NativeBindings.GetModuleReturnByte(this._module);
    }

    public short GetShort()
    {
        return NativeBindings.GetModuleReturnShort(this._module);
    }

    public int GetInt()
    {
        return NativeBindings.GetModuleReturnInt(this._module);
    }

    public uint GetUInt()
    {
        return NativeBindings.GetModuleReturnUInt(this._module);
    }

    public long GetLong()
    {
        NativeBindings.GetModuleReturnInt64(this._module, out var high, out var low);

        return (long)high << 32 | (uint)low;
    }

    public float GetFloat()
    {
        return NativeBindings.GetModuleReturnFloat(this._module);
    }

    public unsafe string GetString()
    {
        return *NativeBindings.GetModuleReturnString(this._module);
    }

    public T GetObject<T>() where T : IScriptObject
    {
        return (T)T.Create(NativeBindings.GetModuleReturnObject(this._module));
    }

    public unsafe T GetRefObject<T>() where T : IScriptObject
    {
        var pointer = (ObjectHandle*)NativeBindings.GetModuleReturnAddress(this._module);

        if (pointer == null)
        {
            return (T)T.Create(ObjectHandle.Null);
        }

        return (T)T.Create(*pointer);
    }

    public ObjectHandle GetObject()
    {
        return NativeBindings.GetModuleReturnObject(this._module);
    }

    public IntPtr GetPointer()
    {
        return NativeBindings.GetModuleReturnAddress(this._module);
    }
}