namespace CCB.Syntax.Factory;

using CCB.Syntax;

public static partial class SyntaxFactory
{
    internal static SyntaxList List(IEnumerable<Syntax.Internal.GreenNode> nodes)
    {
        return (SyntaxList)Internal.SyntaxFactory.List(nodes).CreateRed();
    }

    public static SyntaxList<TNode> List<TNode>(IEnumerable<TNode> nodes) where TNode : SyntaxNode
    {
        return SyntaxList<TNode>.CreateNodes(nodes);
    }

    public static SyntaxTokenList TokenList(IEnumerable<SyntaxToken> tokens)
    {
        return SyntaxTokenList.CreateNodes(tokens);
    }

    public static RootSyntax Root(SyntaxList<SyntaxNode> members, SyntaxToken endOfFile)
    {
        return (RootSyntax)Internal.SyntaxFactory.Root(members.Node?.Node, (Syntax.Internal.SyntaxToken)endOfFile.Node).CreateRed();
    }
}