namespace CCB.Syntax;

using System.Collections;

public readonly struct SyntaxTriviaList : IEnumerable<SyntaxTrivia>, IEquatable<SyntaxTriviaList>
{
    public SyntaxNode? Parent { get; }

    public int Position { get; }

    public int Count => this.Node is null ? 0 : (this.Node.IsList ? this.Node.SlotCount : 1);

    internal Internal.GreenNode Node { get; }

    internal SyntaxTriviaList(Internal.GreenNode node, SyntaxNode? parent, int position)
    {
        this.Node = node;
        this.Parent = parent;
        this.Position = position;
    }

    public SyntaxTrivia this[int index]
    {
        get
        {
            var node = this.Node.GetSlot(index);

            return node is not null
                ? new SyntaxTrivia(node, this.Parent, this.Position + this.Node.GetSlotOffset(index), index)
                : throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public bool Any(SyntaxKind kind)
    {
        return this.Any(t => t.Kind == kind);
    }

    public bool Equals(SyntaxTriviaList other)
    {
        return this.Node.Equals(other.Node) && Equals(this.Parent, other.Parent) && this.Position == other.Position;
    }

    public IEnumerator<SyntaxTrivia> GetEnumerator()
    {
        return new Enumerator(this);
    }

    public override bool Equals(object? obj)
    {
        return obj is SyntaxTriviaList other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Node, this.Parent, this.Position);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public static bool operator ==(SyntaxTriviaList left, SyntaxTriviaList right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(SyntaxTriviaList left, SyntaxTriviaList right)
    {
        return !left.Equals(right);
    }

    public class Enumerator(SyntaxTriviaList list) : IEnumerator<SyntaxTrivia>
    {
        private int _index = -1;

        public SyntaxTrivia Current => list[this._index];

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