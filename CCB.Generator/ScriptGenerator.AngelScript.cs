namespace CCB.Generator;

using CCB.Extensions;
using CCB.Syntax;
using CCB.Syntax.Visitor;

internal class AngelScriptGenerator(IndentedTextWriter writer, GeneratorContext context) : SimpleVisitor
{
    public override void VisitRoot(RootSyntax root)
    {
        GenerateOnInitialize();

        writer.WriteLine();

        writer.WriteLine("namespace ccb");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            for (var i = 0; i < root.Members.Count; i++)
            {
                if (i > 0)
                {
                    writer.WriteLine();
                }

                var member = root.Members[i];
                member.Accept(this);
            }
        }

        writer.WriteLine("}");

        return;

        void GenerateOnInitialize()
        {
            writer.WriteLine("void OnInitialize()");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine("load_ccb();");
            }

            writer.WriteLine("}");
            writer.WriteLine();
        }
    }

    public override void VisitGlobalProperty(GlobalPropertySyntax node)
    {
        var propertyName = node.Identifier.Text;
        var isString = node.Type.Identifier.Kind == SyntaxKind.String;
        var returnTypeName = isString ? "char" : node.ToStructuredString();

        GenerateGet();

        return;

        void GenerateGet()
        {
            writer.WriteLine($"{returnTypeName} Get{propertyName}()");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine($"return {propertyName};");
            }

            writer.WriteLine("}");
        }
    }

    public override void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
    {
        var isVoid = node.ReturnType.IsVoid;
        var returnTypeName = node.ReturnType.Identifier.Kind == SyntaxKind.String
            ? "char"
            : node.ReturnType.ToStructuredString();

        var methodName = node.Identifier.Text;

        var parameters = new List<(string Type, string Name)>();

        for (var i = 0; i < node.ParameterList.Parameters.Count; i++)
        {
            var parameter = node.ParameterList.Parameters[i];
            var element = parameter.Element;

            var typeName = element.Type.Identifier.Kind == SyntaxKind.String
                ? "const char"
                : element.Type.ToStructuredString();

            var paramName = element.Unnamed ? $"unname{i}" : element.Identifier.Text;

            parameters.Add((typeName, paramName));
        }

        var parametersText = string.Join(", ", parameters.Select(p => $"{p.Type} {p.Name}"));

        var argumentsText = string.Join(", ", parameters.Select(p => p.Name));

        writer.WriteLine($"{returnTypeName} {methodName}({parametersText})");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine(isVoid
                ? $"::{methodName}({argumentsText});"
                : $"return ::{methodName}({argumentsText});");
        }

        writer.WriteLine("}");
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        var className = node.Identifier.Text;

        writer.WriteLine($"namespace _{className}");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            for (var i = 0; i < node.Members.Count; i++)
            {
                if (i > 0)
                {
                    writer.WriteLine();
                }

                var member = node.Members[i];
                member.Accept(this);
            }

            WriteIterator();
        }

        writer.WriteLine("}");

        return;

        void WriteIterator()
        {
            var iterables = context.Config.Iterables;

            if (!iterables.Contains(className))
            {
                return;
            }

            var iteratorName = $"{className}Iterator";

            writer.WriteLine();

            writer.WriteLine($"{iteratorName} create_iterator()");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine($"return {className}::Iterator();");
            }

            writer.WriteLine("}");

            writer.WriteLine();

            writer.WriteLine($"void iterator_advance({iteratorName} iterator)");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine("iterator++;");
            }

            writer.WriteLine("}");

            writer.WriteLine();

            writer.WriteLine($"{className} iterator_get({iteratorName} iterator)");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine("return iterator.Get();");
            }

            writer.WriteLine("}");

            writer.WriteLine();

            writer.WriteLine($"bool iterator_is_null({iteratorName} iterator)");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine("return iterator == NULL;");
            }

            writer.WriteLine("}");
        }
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var isVoid = node.ReturnType.IsVoid;
        var returnTypeName = node.ReturnType.Identifier.Kind == SyntaxKind.String
            ? "char"
            : node.ReturnType.ToStructuredString();

        var methodName = node.Identifier.Text;

        var parameters = new List<(string Type, string Name)>();

        for (var i = 0; i < node.ParameterList.Parameters.Count; i++)
        {
            var parameter = node.ParameterList.Parameters[i];
            var element = parameter.Element;

            var typeName = element.Type.Identifier.Kind == SyntaxKind.String
                ? "const char"
                :element.Type.ToStructuredString();

            var paramName = element.Unnamed ? $"unname{i}" : element.Identifier.Text;

            parameters.Add((typeName, paramName));
        }

        var parametersWithThisText = string.Join(
            ", ",
            parameters
                .Select(p => $"{p.Type} {p.Name}")
                .Prepend($"{className} {GeneratorFacts.ThisVarName}"));

        var argumentsText = string.Join(", ", parameters.Select(p => p.Name));

        writer.WriteLine($"{returnTypeName} {methodName}({parametersWithThisText})");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine(isVoid
                ? $"{GeneratorFacts.ThisVarName}.{methodName}({argumentsText});"
                : $"return {GeneratorFacts.ThisVarName}.{methodName}({argumentsText});");
        }

        writer.WriteLine("}");
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var fieldName = node.Identifier.Text;
        var isString = node.Type.Identifier.Kind == SyntaxKind.String;
        var returnTypeName = isString ? "char" : node.ToStructuredString();
        var valueTypeName = isString ? "const char" : returnTypeName;

        GenerateGet();

        if (node.Modifiers.Any(SyntaxKind.Const))
        {
            return;
        }

        writer.WriteLine();
        GenerateSet();

        return;

        void GenerateGet()
        {
            writer.WriteLine($"{returnTypeName} Get{fieldName}({className} {GeneratorFacts.ThisVarName})");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine($"return {GeneratorFacts.ThisVarName}.{fieldName};");
            }

            writer.WriteLine("}");
        }

        void GenerateSet()
        {
            writer.WriteLine($"void Set{fieldName}({className} {GeneratorFacts.ThisVarName}, {valueTypeName} value)");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                string targetVar;

                if (isString)
                {
                    targetVar = "strValue";
                    writer.WriteLine("string strValue = string(value);");
                }
                else
                {
                    targetVar = "value";
                }

                writer.WriteLine($"{GeneratorFacts.ThisVarName}.{fieldName} = {targetVar};");
            }

            writer.WriteLine("}");
        }
    }
}