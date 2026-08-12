namespace CCB.Syntax.Factory.Internal;

using CCB.Syntax.Internal;

internal static partial class SyntaxFactory
{
    public static SyntaxList EmptyList { get; } = List([]);

    public static SyntaxList List(IEnumerable<GreenNode> nodes)
    {
        return new SyntaxList([..nodes]);
    }

    public static RootSyntax Root(GreenNode? members, SyntaxToken endOfFile)
    {
        return new RootSyntax(SyntaxKind.Root, members, endOfFile);
    }

    public static SyntaxTrivia Trivia(SyntaxKind kind, string text)
    {
        return new SyntaxTrivia(kind, text);
    }
}