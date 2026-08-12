namespace CCB.Parser;

using CCB.Syntax;
using SyntaxToken = CCB.Syntax.Internal.SyntaxToken;

internal struct TokenWindow(Syntax.Internal.SyntaxList<SyntaxToken> tokens)
{
    public int Position { get; private set; }

    public SyntaxToken this[int index] => tokens[index]!;

    private bool TryPeekToken(out SyntaxToken token)
    {
        if (this.Position >= tokens.Count)
        {
            token = new SyntaxToken(SyntaxKind.EndOfFile, string.Empty);
            return false;
        }

        token = this[this.Position];
        return true;
    }

    public SyntaxToken PeekToken()
    {
        this.TryPeekToken(out var token);

        return token;
    }

    public SyntaxToken AdvanceToken()
    {
        if (this.TryPeekToken(out var token))
        {
            this.Position++;
        }

        return token;
    }
}