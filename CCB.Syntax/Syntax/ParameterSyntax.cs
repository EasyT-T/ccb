namespace CCB.Syntax;

public partial class ParameterSyntax
{
    public bool Unnamed => this.Identifier.Kind == SyntaxKind.None;
}