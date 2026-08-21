namespace CCB;

using CCB.IO;
using CCB.Lexer;
using CCB.Parser;
using CCB.Syntax;

public class Compilation(string path)
{
    private readonly TextWindow _textWindow = new TextWindow(File.OpenRead(path));

    public RootSyntax Parse()
    {
        var lexer = new SyntaxLexer(this._textWindow);
        var parser = new SyntaxParser(new TokenWindow(lexer.LexToEnd()));

        return (RootSyntax)parser.ParseToEnd().CreateRed();
    }
}