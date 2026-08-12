namespace CCB.Syntax.Internal;

using CCB.AstGenerator;

[SyntaxNode]
internal partial class TypeSyntax : GreenNode
{
    [NodeSlot(0, true)]
    public SyntaxToken Identifier { get; }

    [NodeSlot(1, true)]
    public SyntaxToken RefHandle { get; }

    [NodeSlot(2, true)]
    public SyntaxToken Inout { get; }
}