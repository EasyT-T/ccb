namespace CCB.Syntax;

using System.Collections;
using CCB.Syntax.Factory;

public readonly struct SyntaxTokenList : IEnumerable<SyntaxToken>, IEquatable<SyntaxTokenList>
{
    public SyntaxNode? Parent { get; }

    public int Position { get; }

    public int Index { get; }

    public int Count => this.Node is null ? 0 : (this.Node.IsList ? this.Node.SlotCount : 1);

    internal Internal.GreenNode Node { get; }

    internal SyntaxTokenList(Internal.GreenNode node, SyntaxNode? parent, int position, int index)
    {
        this.Node = node;
        this.Parent = parent;
        this.Position = position;
        this.Index = index;
    }

    public SyntaxToken this[int index]
    {
        get
        {
            var node = this.Node.GetSlot(index);

            return node is not null
                ? new SyntaxToken(node, this.Parent, this.Position + this.Node.GetSlotOffset(index), this.Index + index)
                : throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    internal static SyntaxTokenList CreateNodes(IEnumerable<SyntaxToken> tokens)
    {
        return new SyntaxTokenList(SyntaxFactory.List(tokens.Select(t => t.Node)).Node, null, 0, 0);
    }

    public bool Any(SyntaxKind kind)
    {
        return this.Any(t => t.Kind == kind);
    }

    public bool Equals(SyntaxTokenList other)
    {
        return this.Node.Equals(other.Node) && Equals(this.Parent, other.Parent) && this.Position == other.Position;
    }

    public IEnumerator<SyntaxToken> GetEnumerator()
    {
        return new Enumerator(this);
    }

    public override bool Equals(object? obj)
    {
        return obj is SyntaxTokenList other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Node, this.Parent, this.Position);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public static bool operator ==(SyntaxTokenList left, SyntaxTokenList right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(SyntaxTokenList left, SyntaxTokenList right)
    {
        return !left.Equals(right);
    }

    public class Enumerator(SyntaxTokenList list) : IEnumerator<SyntaxToken>
    {
        private int _index = -1;

        public SyntaxToken Current => list[this._index];

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