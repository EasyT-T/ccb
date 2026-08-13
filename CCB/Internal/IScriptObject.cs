namespace CCB.Internal;

internal interface IScriptObject
{
    ObjectHandle Handle { get; }

    abstract static IScriptObject Create(ObjectHandle handle);
}