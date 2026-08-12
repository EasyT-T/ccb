namespace CCB.Syntax.Internal;

using CCB.AstGenerator;

[SyntaxNode]
internal partial class FunctionDeclarationSyntax : GreenNode
{
    [NodeSlot(0, isTokenList: true)]
    public SyntaxList<SyntaxToken> Modifiers { get; }

    [NodeSlot(1)]
    public TypeSyntax ReturnType { get; }

    [NodeSlot(2, isToken: true)]
    public SyntaxToken Identifier { get; }

    [NodeSlot(3)]
    public ParameterListSyntax ParameterList { get; }

    [NodeSlot(5, isToken: true)]
    public SyntaxToken SemicolonToken { get; }
}