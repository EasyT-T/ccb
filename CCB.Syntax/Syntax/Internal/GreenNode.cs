namespace CCB.Syntax.Internal;

using CCB.Syntax.Factory.Internal;

internal abstract class GreenNode(SyntaxKind kind)
{
    public SyntaxKind Kind { get; } = kind;

    public int SlotCount { get; protected set; }

    public int FullWidth { get; protected set; }

    public abstract GreenNode? GetSlot(int index);

    internal abstract SyntaxNode CreateRed(SyntaxNode? parent, int position);

    public virtual bool IsToken => false;

    public virtual bool IsList => false;

    public SyntaxNode CreateRed()
    {
        return this.CreateRed(null, 0);
    }

    public int GetSlotOffset(int index)
    {
        var offset = 0;

        for (var i = 0; i < index; i++)
        {
            var child = this.GetSlot(i);

            if (child is null)
            {
                continue;
            }

            offset += child.FullWidth;
        }

        return offset;
    }

    public virtual SyntaxList<SyntaxTrivia> GetLeadingTrivia()
    {
        var token = this.GetFirstToken();

        return token?.GetLeadingTrivia() ?? new SyntaxList<SyntaxTrivia>(SyntaxFactory.EmptyList);
    }

    public virtual SyntaxList<SyntaxTrivia> GetTrailingTrivia()
    {
        var token = this.GetLastToken();

        return token?.GetTrailingTrivia() ?? new SyntaxList<SyntaxTrivia>(SyntaxFactory.EmptyList);
    }

    internal GreenNode? GetFirstToken()
    {
        if (this.IsToken)
        {
            return this;
        }

        for (var i = 0; i < this.SlotCount; i++)
        {
            var slot = this.GetSlot(i);

            var subToken = slot?.GetFirstToken();

            if (subToken != null)
            {
                return subToken;
            }
        }

        return null;
    }

    internal GreenNode? GetLastToken()
    {
        if (this.IsToken)
        {
            return this;
        }

        for (var i = this.SlotCount - 1; i > 0; i--)
        {
            var slot = this.GetSlot(i);

            var subToken = slot?.GetFirstToken();

            if (subToken != null)
            {
                return subToken;
            }
        }

        return null;
    }

    protected void AdjustFullWidth(GreenNode node)
    {
        this.FullWidth += node.FullWidth;
    }

    protected internal virtual void WriteTo(TextWriter writer)
    {
    }

    public override string ToString()
    {
        using var writer = new StringWriter();

        this.WriteTo(writer);

        return writer.ToString();
    }
}