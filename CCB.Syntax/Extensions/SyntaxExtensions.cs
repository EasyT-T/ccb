namespace CCB.Extensions;

using CCB.Syntax;

public static class SyntaxExtensions
{
    extension(TypeSyntax typeSyntax)
    {
        public string ToStructuredString()
        {
            return typeSyntax.Identifier.Text + typeSyntax.RefHandle.Text + typeSyntax.Inout.Text;
        }
    }

    extension(FieldDeclarationSyntax fieldSyntax)
    {
        public string ToStructuredString()
        {
            return fieldSyntax.Modifiers.Count > 0
                ? string.Join(' ', fieldSyntax.Modifiers) + ' ' + fieldSyntax.Type.ToStructuredString()
                : fieldSyntax.Type.ToStructuredString();
        }
    }

    extension(GlobalPropertySyntax fieldSyntax)
    {
        public string ToStructuredString()
        {
            return fieldSyntax.Modifiers.Count > 0
                ? string.Join(' ', fieldSyntax.Modifiers) + ' ' + fieldSyntax.Type.ToStructuredString()
                : fieldSyntax.Type.ToStructuredString();
        }
    }
}