namespace CCB.Internal;

public interface IScriptObject
{
    ObjectHandle Handle { get; }

    static abstract IScriptObject Create(ObjectHandle handle);
}