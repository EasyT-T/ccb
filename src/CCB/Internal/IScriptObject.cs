namespace CCB.Internal;

public interface IScriptObject
{
    ObjectHandle Handle { get; }

    abstract static IScriptObject Create(ObjectHandle handle);
}