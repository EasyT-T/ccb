namespace CCB.Syntax.Internal;

using CCB.AstGenerator;

[SyntaxNode]
internal partial class ParameterListSyntax : GreenNode
{
    [NodeSlot(0, isToken: true)]
    public SyntaxToken OpenParenthesisToken { get; }

    [NodeSlot(1, isList: true)]
    public SyntaxList<ParameterSeparatedElementSyntax> Parameters { get; }

    [NodeSlot(2, isToken: true)]
    public SyntaxToken CloseParenthesisToken { get; }
}