namespace CCB.Syntax;

using System.Diagnostics;
using CCB.Syntax.Internal;
using CCB.Syntax.Visitor;

public abstract class SyntaxNode
{
    internal SyntaxNode(GreenNode node, SyntaxNode? parent, int position)
    {
        this.Node = node;
        this.Parent = parent;
        this.Position = position;
    }

    public SyntaxNode? Parent { get; }

    public int FullWidth => this.Node.FullWidth;

    public int Position { get; }

    public int EndPosition => this.Position + this.FullWidth;

    public SyntaxKind Kind => this.Node.Kind;

    internal GreenNode Node { get; }

    public abstract void Accept(ISyntaxVisitor visitor);

    public abstract TResult Accept<TResult>(ISyntaxVisitor<TResult> visitor);

    public SyntaxTriviaList GetLeadingTrivia()
    {
        return new SyntaxTriviaList(this.Node.GetLeadingTrivia().Node!, this, this.Position);
    }

    public SyntaxTriviaList GetTrailingTrivia()
    {
        return new SyntaxTriviaList(this.Node.GetTrailingTrivia().Node!, this, this.Position);
    }

    internal virtual SyntaxNode? GetNodeSlot(int index)
    {
        return null;
    }

    protected T? GetRed<T>(int index) where T : SyntaxNode
    {
        var node = this.Node.GetSlot(index);

        return (T?)node?.CreateRed(this, this.GetChildPosition(index));
    }

    protected T? GetRed<T>(ref T? field, int index) where T : SyntaxNode
    {
        if (field is not null)
        {
            return field;
        }

        return field = this.GetRed<T>(index);
    }

    protected SyntaxToken GetToken(int index)
    {
        var slot = this.Node.GetSlot(index);

        Debug.Assert(slot is not null);

        return new SyntaxToken(slot, this, this.GetChildPosition(index), this.GetChildIndex(index));
    }

    protected SyntaxTokenList GetTokenList(int index)
    {
        var slot = this.Node.GetSlot(index);

        Debug.Assert(slot is not null);

        return new SyntaxTokenList(slot, this, this.GetChildPosition(index), this.GetChildIndex(index));
    }

    protected SyntaxList<TNode> GetList<TNode>(int index) where TNode : SyntaxNode
    {
        var slot = this.Node.GetSlot(index);

        Debug.Assert(slot is not null);

        return new SyntaxList<TNode>(this.GetRed<SyntaxNode>(index), this, this.GetChildPosition(index), this.GetChildIndex(index));
    }

    private int GetChildPosition(int index)
    {
        var width = 0;

        for (var i = index - 1; i > 0; i--)
        {
            var node = this.Node.GetSlot(i);

            if (node is null)
            {
                continue;
            }

            width += node.FullWidth;
        }

        return this.Position + width;
    }

    private int GetChildIndex(int slot)
    {
        var childIndex = 0;

        for (var i = slot - 1; i > 0; i--)
        {
            var node = this.Node.GetSlot(i);

            if (node is null)
            {
                continue;
            }

            if (node.IsList)
            {
                childIndex += node.SlotCount;
            }
            else
            {
                childIndex++;
            }
        }

        return childIndex;
    }

    public override string ToString()
    {
        return this.Node.ToString();
    }
}