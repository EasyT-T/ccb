namespace CCB.Syntax.Internal;

using CCB.AstGenerator;

[SyntaxNode]
internal partial class ClassDeclarationSyntax : GreenNode
{
    [NodeSlot(0, true)]
    public SyntaxToken ClassKeyword { get; }

    [NodeSlot(1, true)]
    public SyntaxToken Identifier { get; }

    [NodeSlot(2, true)]
    public SyntaxToken OpenBrace { get; }

    [NodeSlot(3, isList: true)]
    public SyntaxList<MemberDeclarationSyntax> Members { get; }

    [NodeSlot(4, true)]
    public SyntaxToken CloseBrace { get; }
}