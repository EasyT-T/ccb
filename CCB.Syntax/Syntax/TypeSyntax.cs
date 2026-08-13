namespace CCB.Syntax;

public partial class TypeSyntax
{
    public bool IsRef => this.RefHandle.Kind == SyntaxKind.Ampersand;

    public bool IsHandle => this.RefHandle.Kind == SyntaxKind.Handle;

    public bool IsVoid => this.Identifier.Kind == SyntaxKind.Void;

    public new SyntaxKind Kind => this.Identifier.Kind;
}