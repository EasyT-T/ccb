namespace CCB.Internal;

public interface IScriptObject
{
    ObjectOpaque Opaque { get; }

    static abstract IScriptObject Create(ObjectOpaque handle);
}