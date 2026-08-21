namespace CCB.Lexer;

using CCB.Syntax.Internal;
using SyntaxToken = CCB.Syntax.Internal.SyntaxToken;
using SyntaxKind = CCB.Syntax.SyntaxKind;

internal partial class SyntaxLexer
{
    private SyntaxToken LexDoubleQuote(SyntaxList<SyntaxTrivia>? trivia)
    {
        var start = textWindow.Position;

        textWindow.AdvanceChar();

        while (textWindow.PeekChar() != '"')
        {
            textWindow.AdvanceChar();
        }

        textWindow.AdvanceChar();

        var length = textWindow.Position - start;

        var text = textWindow.GetString(start, length);

        return BuildToken(SyntaxKind.StringLiteral, text, trivia);
    }
}