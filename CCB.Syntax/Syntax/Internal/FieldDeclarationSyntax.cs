namespace CCB.Syntax.Internal;

using CCB.AstGenerator;

[SyntaxNode]
internal partial class FieldDeclarationSyntax : MemberDeclarationSyntax
{
    [NodeSlot(0, isTokenList: true)]
    public SyntaxList<SyntaxToken> Modifiers { get; }

    [NodeSlot(1)]
    public TypeSyntax Type { get; }

    [NodeSlot(2, isToken: true)]
    public SyntaxToken Identifier { get; }

    [NodeSlot(3, isToken: true)]
    public SyntaxToken Semicolon { get; }
}