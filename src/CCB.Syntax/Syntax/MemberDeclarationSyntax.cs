namespace CCB.Syntax;

using CCB.Syntax.Internal;

public abstract class MemberDeclarationSyntax : SyntaxNode
{
    internal MemberDeclarationSyntax(GreenNode node, SyntaxNode? parent, int position) : base(node, parent, position)
    {
    }
}