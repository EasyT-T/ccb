namespace CCB.Syntax.Internal;

using System.Diagnostics;
using CCB.Syntax.Factory.Internal;

internal class SyntaxToken : GreenNode
{
    public static readonly SyntaxToken None = new SyntaxToken(SyntaxKind.None, string.Empty);

    public string Text { get; }

    public int Width { get; }

    public override bool IsToken => true;

    private readonly SyntaxList<SyntaxTrivia> _leadingTrivia;

    private readonly SyntaxList<SyntaxTrivia> _trailingTrivia;

    public SyntaxToken(SyntaxKind kind) : base(kind)
    {
        if (!SyntaxFacts.TryGetTokenText(kind, out var text))
        {
            throw new InvalidOperationException(); // TODO Exception
        }

        this.Text = text;
        this.Width = text.Length;
        this.FullWidth = text.Length;

        this._leadingTrivia = new SyntaxList<SyntaxTrivia>(SyntaxFactory.EmptyList);
        this._trailingTrivia = new SyntaxList<SyntaxTrivia>(SyntaxFactory.EmptyList);
    }

    public SyntaxToken(SyntaxKind kind, string text) : base(kind)
    {
        this.Text = text;
        this.Width = text.Length;
        this.FullWidth = text.Length;

        this._leadingTrivia = new SyntaxList<SyntaxTrivia>(SyntaxFactory.EmptyList);
        this._trailingTrivia = new SyntaxList<SyntaxTrivia>(SyntaxFactory.EmptyList);
    }

    public SyntaxToken(SyntaxKind kind, string text, SyntaxList<SyntaxTrivia> leadingTrivia) : base(kind)
    {
        this.Text = text;
        this.Width = text.Length;
        this.FullWidth = text.Length;

        this._leadingTrivia = leadingTrivia;
        this._trailingTrivia = new SyntaxList<SyntaxTrivia>(SyntaxFactory.EmptyList);

        if (leadingTrivia.Node is not null)
        {
            this.FullWidth += leadingTrivia.Node.FullWidth;
        }
    }

    public override GreenNode? GetSlot(int index)
    {
        return null;
    }

    public override SyntaxList<SyntaxTrivia> GetLeadingTrivia()
    {
        return this._leadingTrivia;
    }

    public override SyntaxList<SyntaxTrivia> GetTrailingTrivia()
    {
        return this._trailingTrivia;
    }

    internal override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        throw new UnreachableException();
    }

    protected internal override void WriteTo(TextWriter writer)
    {
        this._leadingTrivia.Node?.WriteTo(writer);
        writer.Write(this.Text);
        this._trailingTrivia.Node?.WriteTo(writer);
    }

    public override string ToString()
    {
        return this.Text;
    }
}