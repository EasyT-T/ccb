namespace CCB.Syntax;

public partial class TypeSyntax
{
    public bool IsRef => this.RefHandle.Kind == SyntaxKind.Ref;

    public bool IsHandle => this.RefHandle.Kind == SyntaxKind.Handle;

    public bool IsVoid => this.Identifier.Kind == SyntaxKind.Void;
}