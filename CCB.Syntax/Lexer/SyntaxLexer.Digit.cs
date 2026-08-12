namespace CCB.Lexer;

using CCB.Syntax.Internal;
using SyntaxToken = CCB.Syntax.Internal.SyntaxToken;
using SyntaxKind = CCB.Syntax.SyntaxKind;

internal partial class SyntaxLexer
{
    private SyntaxToken LexDigit(SyntaxList<SyntaxTrivia>? leadingTrivia)
    {
        var c = textWindow.PeekChar();
        var sign = string.Empty;

        if (c is '+' or '-')
        {
            sign = c.ToString();
            textWindow.AdvanceChar();
        }

        var intPart = this.LexDigitPart();

        if (textWindow.PeekChar() != '.')
        {
            return BuildToken(SyntaxKind.NumberLiteral, sign + intPart, leadingTrivia);
        }

        textWindow.AdvanceChar();

        var fracPart = this.LexDigitPart();

        if (textWindow.PeekChar() == 'f')
        {
            textWindow.AdvanceChar();
        }

        return BuildToken(SyntaxKind.NumberLiteral, sign + intPart + "." + fracPart, leadingTrivia);
    }

    private string LexDigitPart()
    {
        var start = textWindow.Position;

        while (char.IsAsciiDigit(textWindow.PeekChar()))
        {
            textWindow.AdvanceChar();
        }

        var length = textWindow.Position - start;

        var text = textWindow.GetString(start, length);

        return text;
    }
}