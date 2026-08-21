namespace CCB.Syntax;

public partial class TypeSyntax
{
    public bool IsRef => this.RefHandle.Kind == SyntaxKind.Ampersand;

    public bool IsHandle => this.RefHandle.Kind == SyntaxKind.Handle;

    public bool IsVoid => this.Identifier.Kind == SyntaxKind.Void;

    public bool IsIn => this.Inout.Kind == SyntaxKind.In;

    public bool IsOut => this.Inout.Kind == SyntaxKind.Out;

    public new SyntaxKind Kind => this.Identifier.Kind;
}