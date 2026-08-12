namespace CCB.Lexer;

using CCB.Syntax.Internal;
using SyntaxToken = CCB.Syntax.Internal.SyntaxToken;
using SyntaxFacts = CCB.Syntax.SyntaxFacts;

internal partial class SyntaxLexer
{
    private SyntaxToken LexPunctuation(SyntaxList<SyntaxTrivia>? trivia)
    {
        var c = textWindow.AdvanceChar().ToString();

        if (!SyntaxFacts.TryGetTokenType(c, out var kind))
        {
            throw new InvalidOperationException(); // TODO
        }

        return BuildToken(kind, c, trivia);
    }
}