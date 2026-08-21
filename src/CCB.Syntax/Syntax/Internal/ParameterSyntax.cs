namespace CCB.Syntax.Internal;

using CCB.AstGenerator;

[SyntaxNode]
internal partial class ParameterSyntax : GreenNode
{
    [NodeSlot(0)]
    public TypeSyntax Type { get; }

    [NodeSlot(1, isToken: true)]
    public SyntaxToken Identifier { get; }

    [NodeSlot(2, isToken: true)]
    public SyntaxToken EqualTo { get; }

    [NodeSlot(3, isToken: true)]
    public SyntaxToken DefaultValue { get; }
}