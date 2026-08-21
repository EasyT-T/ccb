namespace CCB.Extensions;

using CCB.Syntax;

public static class SyntaxListExtension
{
    internal static Syntax.Internal.SyntaxList<TNode> ToGreenList<TNode>(this SyntaxNode list) where TNode : Syntax.Internal.GreenNode
    {
        if (!list.Node.IsList)
        {
            return default;
        }

        return new Syntax.Internal.SyntaxList<TNode>(list.Node);
    }

    internal static Syntax.Internal.SyntaxList<Syntax.Internal.SyntaxToken> ToGreenList(this SyntaxTokenList list)
    {
        return new Syntax.Internal.SyntaxList<Syntax.Internal.SyntaxToken>(list.Node);
    }
}