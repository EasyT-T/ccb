namespace CCB.Syntax.Internal;

internal class RootSyntax : GreenNode
{
    public RootSyntax(SyntaxKind kind, GreenNode? members, SyntaxToken endOfFile) : base(kind)
    {
        if (members is not null)
        {
            this.AdjustFullWidth(members);
            this.Members = members;
        }
        this.EndOfFile = endOfFile;

        this.SlotCount = 2;
    }

    public GreenNode? Members { get; }

    public SyntaxToken EndOfFile { get; }

    public override GreenNode? GetSlot(int index)
    {
        return index switch
        {
            0 => this.Members,
            1 => this.EndOfFile,
            _ => null,
        };
    }

    internal override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        return new Syntax.RootSyntax(this, parent, position);
    }

    protected internal override void WriteTo(TextWriter writer)
    {
        base.WriteTo(writer);

        this.Members?.WriteTo(writer);
        this.EndOfFile.WriteTo(writer);
    }
}