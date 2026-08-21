namespace CCB.Generator.Model;

using CCB.Syntax;

internal sealed record ValueType(string Name, SyntaxKind Kind, SyntaxToken RefHandleToken, SyntaxToken InoutToken)
{
    public static ValueType Void { get; } = new ValueType("void", SyntaxKind.Void, SyntaxToken.None, SyntaxToken.None);

    public string Name { get; } = Name;

    public SyntaxKind Kind { get; } = Kind;

    public bool IsHandle { get; } = RefHandleToken.Kind == SyntaxKind.Handle;

    public bool IsRef { get; } = RefHandleToken.Kind == SyntaxKind.Ampersand;

    public bool IsIn { get; } = InoutToken.Kind == SyntaxKind.In;

    public bool IsOut { get; } = InoutToken.Kind == SyntaxKind.Out;

    public SyntaxToken RefHandleToken { get; } = RefHandleToken;

    public SyntaxToken InoutToken { get; } = InoutToken;
}