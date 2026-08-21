namespace CCB.Lexer;

using CCB.Syntax.Internal;
using SyntaxToken = CCB.Syntax.Internal.SyntaxToken;
using SyntaxKind = CCB.Syntax.SyntaxKind;
using SyntaxFacts = CCB.Syntax.SyntaxFacts;

internal partial class SyntaxLexer
{
    private SyntaxToken LexLetter(SyntaxList<SyntaxTrivia>? leadingTrivia)
    {
        var start = textWindow.Position;

        while (IsIdentifierLetter(textWindow.PeekChar()))
        {
            textWindow.AdvanceChar();
        }

        var length = textWindow.Position - start;

        var text = textWindow.GetString(start, length);

        if (!SyntaxFacts.TryGetTokenType(text, out var kind))
        {
            kind = SyntaxKind.Identifier;
        }

        return BuildToken(kind, text, leadingTrivia);
    }

    private static bool IsIdentifierLetter(char c)
    {
        return char.IsAsciiLetterOrDigit(c) || c == '_';
    }
}