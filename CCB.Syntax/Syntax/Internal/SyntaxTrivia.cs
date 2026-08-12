namespace CCB.Syntax.Internal;

using System.Diagnostics;

internal class SyntaxTrivia : GreenNode
{
    public SyntaxTrivia(SyntaxKind kind, string text) : base(kind)
    {
        this.Text = text;
        this.FullWidth = text.Length;
    }

    public string Text { get; }

    public override GreenNode GetSlot(int index)
    {
        throw new UnreachableException();
    }

    internal override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        throw new UnreachableException();
    }

    protected internal override void WriteTo(TextWriter writer)
    {
        base.WriteTo(writer);

        writer.Write(this.Text);
    }
}