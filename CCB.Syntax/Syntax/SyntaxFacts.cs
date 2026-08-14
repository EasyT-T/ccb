namespace CCB.Syntax;

using System.Diagnostics.CodeAnalysis;

public static class SyntaxFacts
{
    public static bool TryGetTokenText(SyntaxKind kind, [MaybeNullWhen(false)] out string text)
    {
        text = kind switch
        {
            SyntaxKind.Class => "class",
            SyntaxKind.Public => "public",
            SyntaxKind.Const => "const",
            SyntaxKind.Void => "void",
            SyntaxKind.Int => "int",
            SyntaxKind.UInt => "uint",
            SyntaxKind.Float => "float",
            SyntaxKind.Bool => "bool",
            SyntaxKind.String => "string",
            SyntaxKind.Ref => "ref",
            SyntaxKind.In => "in",
            SyntaxKind.Out => "out",
            SyntaxKind.Comma => ",",
            SyntaxKind.Semicolon => ";",
            SyntaxKind.OpenParen => "(",
            SyntaxKind.CloseParen => ")",
            SyntaxKind.OpenBrace => "{",
            SyntaxKind.CloseBrace => "}",
            SyntaxKind.EqualTo => "=",
            SyntaxKind.Ampersand => "&",
            SyntaxKind.Handle => "@",
            SyntaxKind.QuestionMark => "?",
            SyntaxKind.EndOfFile => "\0",
            _ => null,
        };

        return text is not null;
    }

    public static bool TryGetTokenType(ReadOnlySpan<char> text, out SyntaxKind kind)
    {
        kind = text switch
        {
            "class" => SyntaxKind.Class,
            "public" => SyntaxKind.Public,
            "const" => SyntaxKind.Const,
            "void" => SyntaxKind.Void,
            "int" => SyntaxKind.Int,
            "uint" => SyntaxKind.UInt,
            "float" => SyntaxKind.Float,
            "bool" => SyntaxKind.Bool,
            "string" => SyntaxKind.String,
            "ref" => SyntaxKind.Ref,
            "in" => SyntaxKind.In,
            "out" => SyntaxKind.Out,
            "," => SyntaxKind.Comma,
            ";" => SyntaxKind.Semicolon,
            "(" => SyntaxKind.OpenParen,
            ")" => SyntaxKind.CloseParen,
            "{" => SyntaxKind.OpenBrace,
            "}" => SyntaxKind.CloseBrace,
            "=" => SyntaxKind.EqualTo,
            "&" => SyntaxKind.Ampersand,
            "@" => SyntaxKind.Handle,
            "?" => SyntaxKind.QuestionMark,
            "\0" => SyntaxKind.EndOfFile,
            " " => SyntaxKind.WhiteSpace,
            "\r" or "\n" => SyntaxKind.NewLine,
            _ => SyntaxKind.None,
        };

        return kind is not SyntaxKind.None;
    }

    public static bool IsAccessModifier(this SyntaxKind kind)
    {
        return kind is SyntaxKind.Public;
    }
}