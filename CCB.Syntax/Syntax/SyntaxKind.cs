namespace CCB.Syntax;

public enum SyntaxKind
{
    None,
    Identifier,
    Class,
    Public,
    Const,
    Void,
    Int,
    UInt,
    Float,
    Bool,
    String,
    Ref,
    In,
    Out,
    Comma,
    Semicolon,
    OpenParen,
    CloseParen,
    OpenBrace,
    CloseBrace,
    EqualTo,
    Ampersand,
    Handle,
    QuestionMark,
    StringLiteral,
    NumberLiteral,

    WhiteSpace,
    NewLine,
    Comment,

    Root,
    ClassDeclaration,
    FunctionDeclaration,
    MethodDeclaration,
    FieldDeclaration,
    Parameter,
    ParameterList,
    ParameterSeparatedElement,
    SyntaxList,

    Type,

    EndOfFile,
}