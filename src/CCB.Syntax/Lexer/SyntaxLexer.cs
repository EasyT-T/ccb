namespace CCB.Lexer;

using System.Text;
using CCB.IO;
using CCB.Syntax.Factory.Internal;
using CCB.Syntax.Internal;
using SyntaxToken = CCB.Syntax.Internal.SyntaxToken;
using SyntaxKind = CCB.Syntax.SyntaxKind;
using SyntaxFacts = CCB.Syntax.SyntaxFacts;

internal partial class SyntaxLexer(TextWindow textWindow)
{
    private enum BeginCharType
    {
        Letter,
        Digit,
        DoubleQuote,
        Slash,
        EndOfFile,
        Other,
    }

    public SyntaxList<SyntaxToken> LexToEnd()
    {
        var tokenList = new List<SyntaxToken>();

        SyntaxToken token;

        while ((token = this.Lex()).Kind is not SyntaxKind.EndOfFile)
        {
            tokenList.Add(token);
        }

        return new SyntaxList<SyntaxToken>(SyntaxFactory.List(tokenList));
    }

    public SyntaxToken Lex()
    {
        var triviaBuilder = new TriviaBuilder();

        while (true)
        {
            char c;

            while ((c = textWindow.PeekChar()) is ' ' or '\r' or '\n')
            {
                triviaBuilder.AddChar(c);

                textWindow.AdvanceChar();
            }

            var type = GetBeginCharType(c);

            if (type == BeginCharType.Slash)
            {
                var comment = this.LexSlash();

                triviaBuilder.AddComment(comment);

                continue;
            }

            return type switch
            {
                BeginCharType.Letter => this.LexLetter(triviaBuilder.Build()),
                BeginCharType.Digit => this.LexDigit(triviaBuilder.Build()),
                BeginCharType.DoubleQuote => this.LexDoubleQuote(triviaBuilder.Build()),
                BeginCharType.EndOfFile => BuildToken(SyntaxKind.EndOfFile, string.Empty, triviaBuilder.Build()),
                BeginCharType.Other => this.LexPunctuation(triviaBuilder.Build()),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }

    private static BeginCharType GetBeginCharType(char c)
    {
        return c switch
        {
            (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') => BeginCharType.Letter,
            '+' or '-' or (>= '0' and <= '9') => BeginCharType.Digit,
            '"' => BeginCharType.DoubleQuote,
            '/' => BeginCharType.Slash,
            '\0' => BeginCharType.EndOfFile,
            _ => BeginCharType.Other,
        };
    }

    private static SyntaxToken BuildToken(SyntaxKind kind, string text, SyntaxList<SyntaxTrivia>? trivia)
    {
        return trivia is null ? new SyntaxToken(kind, text) : new SyntaxToken(kind, text, trivia.Value);
    }

    private class TriviaBuilder
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        private SyntaxKind _currentKind = SyntaxKind.None;

        private readonly List<SyntaxTrivia> _trivia = [];

        public void AddChar(char c)
        {
            if (!SyntaxFacts.TryGetTokenType([c], out var kind))
            {
                throw new InvalidOperationException();
            }

            if(this._currentKind != SyntaxKind.None && this._currentKind != kind)
            {
                this._trivia.Add(this.BuildTrivia());
            }

            this._stringBuilder.Append(c);
            this._currentKind = kind;
        }

        public void AddComment(string comment)
        {
            if(this._currentKind != SyntaxKind.None && this._currentKind != SyntaxKind.Comment)
            {
                this._trivia.Add(this.BuildTrivia());
            }

            this._stringBuilder.Append(comment);
            this._currentKind = SyntaxKind.Comment;
        }

        public SyntaxList<SyntaxTrivia>? Build()
        {
            if (this._stringBuilder.Length > 0)
            {
                this._trivia.Add(this.BuildTrivia());
            }

            if (this._trivia.Count == 0)
            {
                return null;
            }

            var result = new SyntaxList<SyntaxTrivia>(SyntaxFactory.List(this._trivia));

            this._trivia.Clear();

            return result;
        }

        private SyntaxTrivia BuildTrivia()
        {
            var result = SyntaxFactory.Trivia(this._currentKind, this._stringBuilder.ToString());

            this._stringBuilder.Clear();
            this._currentKind = SyntaxKind.None;

            return result;
        }
    }
}