namespace CCB.Syntax.Internal;

using CCB.AstGenerator;

[SyntaxNode]
internal partial class ParameterSeparatedElementSyntax : GreenNode
{
    [NodeSlot(0)]
    public ParameterSyntax Element { get; }

    [NodeSlot(1, isToken: true)]
    public SyntaxToken Separator { get; }
}