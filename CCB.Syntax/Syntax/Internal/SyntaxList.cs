namespace CCB.Syntax.Internal;

using System.Diagnostics;
using CCB.Syntax.Factory.Internal;

internal class SyntaxList : GreenNode
{
    private readonly GreenNode[] _nodes;

    public override bool IsList => true;

    internal SyntaxList(GreenNode[] nodes) : base(SyntaxKind.SyntaxList)
    {
        this._nodes = nodes;

        foreach (var node in nodes)
        {
            this.AdjustFullWidth(node);
        }

        this.SlotCount = nodes.Length;
    }

    public override GreenNode? GetSlot(int index)
    {
        return this._nodes.ElementAtOrDefault(index);
    }

    internal override SyntaxNode CreateRed(SyntaxNode? parent, int position)
    {
        return new Syntax.SyntaxList(this, parent, position);
    }

    protected internal override void WriteTo(TextWriter writer)
    {
        base.WriteTo(writer);

        foreach (var node in this._nodes)
        {
            node.WriteTo(writer);
        }
    }
}

internal readonly struct SyntaxList<TNode> : IEquatable<SyntaxList<TNode>> where TNode : GreenNode
{
    public int Count => this.Node is null ? 0 : (this.Node.IsList ? this.Node.SlotCount : 1);

    internal GreenNode? Node { get; }

    internal SyntaxList(GreenNode? node)
    {
        this.Node = node;
    }

    public TNode? this[int index]
    {
        get
        {
            if (this.Node is null)
            {
                return null;
            }

            if (this.Node.IsList)
            {
                return (TNode?)this.Node.GetSlot(index);
            }

            if (index == 0)
            {
                return (TNode?)this.Node;
            }

            throw new UnreachableException();
        }
    }

    internal static SyntaxList<TNode> CreateNodes(IEnumerable<TNode> nodes)
    {
        return new SyntaxList<TNode>(SyntaxFactory.List([..nodes]));
    }

    public bool Equals(SyntaxList<TNode> other)
    {
        return Equals(this.Node, other.Node);
    }

    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    public override bool Equals(object? obj)
    {
        return obj is SyntaxList<TNode> other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return (this.Node != null ? this.Node.GetHashCode() : 0);
    }

    public struct Enumerator(SyntaxList<TNode> list)
    {
        private int _index = -1;

        public TNode Current => list[this._index]!;

        public bool MoveNext()
        {
            var newIndex = this._index + 1;

            if (newIndex >= list.Count)
            {
                return false;
            }

            this._index = newIndex;
            return true;
        }
    }
}