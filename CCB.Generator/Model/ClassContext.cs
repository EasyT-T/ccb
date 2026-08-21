namespace CCB.Generator.Model;

internal sealed record ClassContext(ClassType Type, NamespaceType Namespace) : TypeContext
{
    public override NamespaceType Namespace { get; } = Namespace;
}