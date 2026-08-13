namespace CCB.Generator;

using System.Collections.Immutable;
using CCB.Syntax;
using CCB.Syntax.Visitor;

internal class AngelScriptGenerator(IndentedTextWriter writer) : SimpleVisitor
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
        }

        writer.WriteLine("}");
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var isVoid = node.ReturnType.IsVoid;
        var returnTypeName = GeneratorFacts.GetTypeName(node.ReturnType);

        var leadingModifiersText = node.LeadingModifiers.Count > 0
            ? string.Join(' ', node.LeadingModifiers.Select(m => m.Text))
            : string.Empty;
        var methodName = node.Identifier.Text;

        var parameters = node.ParameterList.Parameters
            .Select((p, i) =>
            {
                var element = p.Element;
                var typeName = GeneratorFacts.GetTypeName(element.Type);
                var paramName = element.Unnamed ? $"unname{i}" : element.Identifier.Text;

                return (TypeName: typeName, ParameterName: paramName);
            })
            .ToImmutableArray();

        var parametersWithThisText = string.Join(", ",
            parameters
                .Select(p => $"{p.TypeName} {p.ParameterName}")
                .Prepend($"{className} {GeneratorFacts.ThisVarName}"));
        var argumentsText = string.Join(", ", parameters.Select(p => p.ParameterName));

        // TODO Find a better way to fix TXT_REF_CANT_BE_RETURNED_DEFERRED_PARAM
        if (className == "Config" && methodName == "Get")
        {
            returnTypeName = "string";
        }

        writer.WriteLine($"{leadingModifiersText}{returnTypeName} {methodName}({parametersWithThisText})");
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
        var typeName = GeneratorFacts.GetReturnTypeName(node);

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
            writer.WriteLine($"{typeName} Get{node.Identifier.Text}({className} {GeneratorFacts.ThisVarName})");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine($"return {GeneratorFacts.ThisVarName}.{node.Identifier.Text};");
            }

            writer.WriteLine("}");
        }

        void GenerateSet()
        {
            writer.WriteLine($"void Set{node.Identifier.Text}({className} {GeneratorFacts.ThisVarName}, {typeName} value)");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine($"{GeneratorFacts.ThisVarName}.{node.Identifier.Text} = value;");
            }

            writer.WriteLine("}");
        }
    }
}

internal class AngelPluginGenerator(IndentedTextWriter writer, GeneratorContext context) : SimpleVisitor
{
    public override void VisitRoot(RootSyntax root)
    {
        GenerateOnInitialize();

        writer.WriteLine();

        GenerateRegisterAllFunctions();

        return;

        void GenerateOnInitialize()
        {
            writer.WriteLine($"void {GeneratorFacts.OnInitializeName}()");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine($"SetLibrary(LoadLibrary(\"{context.Config.ExternalAssemblyPath}\"));");
                writer.WriteLine($"SetConvType({context.Config.ConvType});");

                writer.WriteLine($"{GeneratorFacts.RegisterAllFunctionsName}();");
            }

            writer.WriteLine("}");
        }

        void GenerateRegisterAllFunctions()
        {
            writer.WriteLine($"void {GeneratorFacts.RegisterAllFunctionsName}()");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                GenerateRegisterFunction(GeneratorFacts.LoadCcbDef, GeneratorFacts.LoadCcbName);
            }

            writer.WriteLine("}");

            return;

            void GenerateRegisterFunction(string definition, string funcName)
            {
                writer.WriteLine($"{GeneratorFacts.RegisterFunctionName}(\"{definition}\", \"{funcName}\");");
            }
        }
    }
}

internal class DefinitionsGenerator(GeneratorContext context) : SimpleVisitor
{
    public override void VisitRoot(RootSyntax root)
    {
        foreach (var member in root.Members)
        {
            member.Accept(this);
        }
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        foreach (var member in node.Members)
        {
            member.Accept(this);
        }
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var methodName = node.Identifier.Text;

        var parametersWithThis = node.ParameterList.Parameters
            .Select(p => GeneratorFacts.GetTypeName(p.Element.Type))
            .Prepend(className);

        var parametersWithThisText = string.Join(", ", parametersWithThis);

        var definition = new FunctionDefinition(GeneratorFacts.GetTypeName(node.ReturnType), parametersWithThisText);

        context.FunctionDefinitions.Add(definition);
        context.FunctionMetadatas.Add(new MethodMetadata(definition, className, methodName, $"@ccb::_{className}::{methodName}"));
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var typeName = GeneratorFacts.GetReturnTypeName(node);

        GenerateGet();

        if (!node.Modifiers.Any(SyntaxKind.Const))
        {
            GenerateSet();
        }

        return;

        void GenerateGet()
        {
            var getDefinition = new FunctionDefinition(typeName, className);
            var getMethodName = $"Get{node.Identifier.Text}";

            context.FunctionDefinitions.Add(getDefinition);
            context.FunctionMetadatas.Add(new MethodMetadata(getDefinition, className, getMethodName, $"@ccb::_{className}::{getMethodName}"));
        }

        void GenerateSet()
        {
            var setDefinition = new FunctionDefinition("void", string.Join(", ", className, typeName));
            var setMethodName = $"Set{node.Identifier.Text}";

            context.FunctionDefinitions.Add(setDefinition);
            context.FunctionMetadatas.Add(new MethodMetadata(setDefinition, className, setMethodName, $"@ccb::_{className}::{setMethodName}"));
        }
    }
}