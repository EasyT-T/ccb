namespace CCB.Syntax.Internal;

using CCB.AstGenerator;

[SyntaxNode]
internal partial class MethodDeclarationSyntax : MemberDeclarationSyntax
{
    [NodeSlot(0, isTokenList: true)]
    public SyntaxList<SyntaxToken> LeadingModifiers { get; }

    [NodeSlot(1)]
    public TypeSyntax ReturnType { get; }

    [NodeSlot(2, isToken: true)]
    public SyntaxToken Identifier { get; }

    [NodeSlot(3)]
    public ParameterListSyntax ParameterList { get; }

    [NodeSlot(4, isTokenList: true)]
    public SyntaxList<SyntaxToken> TrailingModifiers { get; }

    [NodeSlot(5, isToken: true)]
    public SyntaxToken SemicolonToken { get; }
}