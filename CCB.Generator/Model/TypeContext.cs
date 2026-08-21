namespace CCB.Generator.Model;

internal abstract record TypeContext
{
    public abstract NamespaceType Namespace { get; }
}