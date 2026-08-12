namespace CCB.Syntax;

using System.Collections;
using System.Diagnostics;
using CCB.Syntax.Factory;
using CCB.Syntax.Internal;
using CCB.Syntax.Visitor;

internal class SyntaxList : SyntaxNode
{
    private readonly Dictionary<int, SyntaxNode?> _cache = new Dictionary<int, SyntaxNode?>();

    internal SyntaxList(GreenNode node, SyntaxNode? parent, int position) : base(node, parent, position)
    {
    }

    public override void Accept(ISyntaxVisitor visitor)
    {
        throw new UnreachableException();
    }

    public override TResult Accept<TResult>(ISyntaxVisitor<TResult> visitor)
    {
        throw new UnreachableException();
    }

    internal override SyntaxNode? GetNodeSlot(int index)
    {
        if (this._cache.TryGetValue(index, out var node))
        {
            return node;
        }

        var slot = this.Node.GetSlot(index);

        node = slot?.CreateRed(this.Parent, this.Position + this.Node.GetSlotOffset(index));

        this._cache.Add(index, node);

        return node;
    }
}

public readonly struct SyntaxList<TNode> : IEnumerable<TNode>, IEquatable<SyntaxList<TNode>> where TNode : SyntaxNode
{
    public SyntaxNode? Parent { get; }

    public int Position { get; }

    public int Index { get; }

    public int Count => this.Node is null ? 0 : (this.Node.Node.IsList ? this.Node.Node.SlotCount : 1);

    internal SyntaxNode? Node { get; }

    internal SyntaxList(SyntaxNode? node, SyntaxNode? parent, int position, int index)
    {
        this.Node = node;
        this.Parent = parent;
        this.Position = position;
        this.Index = index;
    }

    public TNode this[int index]
    {
        get
        {
            if (this.Node is null)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return (TNode?)this.Node.GetNodeSlot(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    internal static SyntaxList<TNode> CreateNodes(IEnumerable<TNode> nodes)
    {
        return new SyntaxList<TNode>(SyntaxFactory.List(nodes.Select(n => n.Node)), null, 0, 0);
    }

    public bool Equals(SyntaxList<TNode> other)
    {
        return Equals(this.Node, other.Node) && Equals(this.Parent, other.Parent) && this.Position == other.Position && this.Index == other.Index;
    }

    public IEnumerator<TNode> GetEnumerator()
    {
        return new Enumerator(this);
    }

    public override bool Equals(object? obj)
    {
        return obj is SyntaxList<TNode> other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Node, this.Parent, this.Position, this.Index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public static bool operator ==(SyntaxList<TNode> left, SyntaxList<TNode> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(SyntaxList<TNode> left, SyntaxList<TNode> right)
    {
        return !left.Equals(right);
    }

    public class Enumerator(SyntaxList<TNode> list) : IEnumerator<TNode>
    {
        private int _index = -1;

        public TNode Current => list[this._index];

        object IEnumerator.Current => this.Current;

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

        public void Reset()
        {
            this._index = -1;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}