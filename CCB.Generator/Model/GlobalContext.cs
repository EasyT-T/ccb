namespace CCB.Generator.Model;

internal sealed record GlobalContext(NamespaceType Namespace) : TypeContext
{
    public override NamespaceType Namespace { get; } = Namespace;
}