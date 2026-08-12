namespace CCB.Syntax;

using CCB.Syntax.Internal;

public readonly struct SyntaxTrivia
{
    internal SyntaxTrivia(GreenNode node, SyntaxNode? parent, int position, int index)
    {
        this.Node = node;
        this.Parent = parent;
        this.Position = position;
        this.Index = index;
    }

    public SyntaxNode? Parent { get; }

    public int Position { get; }

    public int Index { get; }

    public string Text => this.ToString();

    public SyntaxKind Kind => this.Node.Kind;

    internal GreenNode Node { get; }

    public override string ToString()
    {
        return this.Node.ToString();
    }
}