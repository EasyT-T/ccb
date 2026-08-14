namespace CCB.Generator;

using System.Collections.Immutable;
using CCB.Syntax;
using CCB.Syntax.Visitor;

internal class CSharpScriptGenerator(IndentedTextWriter writer, GeneratorContext context) : SimpleVisitor
{
    private readonly ScriptFunctionsGenerator _scriptFunctionsGenerator = new ScriptFunctionsGenerator(writer, context);

    public override void VisitRoot(RootSyntax root)
    {
        writer.WriteLine("namespace CCB.Internal;");
        writer.WriteLine();
        writer.WriteLine("using System.Diagnostics;");
        writer.WriteLine("using System.Runtime.InteropServices;");
        writer.WriteLine();

        root.Accept(this._scriptFunctionsGenerator);

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

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        var className = node.Identifier.Text;

        writer.WriteLine($"internal struct {className}(ObjectHandle handle) : IScriptObject");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine(context.Config.InternalClasses.Contains(className)
                ? "[StructLayout(LayoutKind.Sequential, Size = 4)]"
                : "[StructLayout(LayoutKind.Sequential)]");

            writer.WriteLine("private readonly struct Opaque");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                // TODO Fields
            }

            writer.WriteLine("}");

            writer.WriteLine();

            writer.WriteLine("public ObjectHandle Handle { get; } = handle;");
            writer.WriteLine();
            writer.WriteLine("public static IScriptObject Create(ObjectHandle handle)");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine($"return new {className}(handle);");
            }

            writer.WriteLine("}");

            writer.WriteLine();

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

        var methodName = node.Identifier.Text;

        if (node.ParameterList.Parameters.Any(parameter => context.Config.FuncDefs.Any(d => d.DefName == parameter.Element.Type.Identifier.Text)))
        {
            // TODO FuncDef fix
            return;
        }

        var parameters = node.ParameterList.Parameters
            .Select((p, i) =>
            {
                var element = p.Element;
                var typeName = GeneratorFacts.GetCSharpTypeName(element.Type);
                var identifierName = element.Identifier.Kind == SyntaxKind.None
                    ? $"unnamed{i}"
                    : element.Identifier.Text;

                return $"{typeName} {identifierName}";
            });

        var parametersText = string.Join(", ", parameters);

        var argumentsWithThis = node.ParameterList.Parameters
            .Select((p, i) =>
            {
                var element = p.Element;
                var outText = element.Type.Inout.Kind == SyntaxKind.Out ? "out " : string.Empty;
                var identifier = element.Identifier.Kind == SyntaxKind.None ? $"unnamed{i}" : element.Identifier.Text;

                return $"{outText}{identifier}";
            })
            .Prepend("this");

        var argumentsWithThisText = string.Join(", ", argumentsWithThis);

        writer.WriteLine($"public {node.ReturnType.Identifier.Text} {methodName}({parametersText})"); // Not GetCSharpTypeName because we don't need 'ref&'
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine(node.ReturnType.IsVoid
                ? $"{GeneratorFacts.ScriptFunctionsName}.As{className}.{methodName}({argumentsWithThisText});"
                : $"return {GeneratorFacts.ScriptFunctionsName}.As{className}.{methodName}({argumentsWithThisText});");
        }

        writer.WriteLine("}");
    }
}

internal class ScriptFunctionsGenerator(IndentedTextWriter writer, GeneratorContext context) : SimpleVisitor
{
    public override void VisitRoot(RootSyntax root)
    {
        writer.WriteLine("internal static class ScriptFunctions");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine($"public static ModuleHandle {GeneratorFacts.ModuleHandleName} {{ get; internal set; }}");

            foreach (var member in root.Members)
            {
                writer.WriteLine();

                member.Accept(this);
            }
        }

        writer.WriteLine("}");
    }

    public override void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
    {
        var methodName = node.Identifier.Text;

        var parameters = node.ParameterList.Parameters
            .Select((p, i) =>
            {
                var element = p.Element;
                var typeName = GeneratorFacts.GetCSharpTypeName(element.Type);
                var identifierName = element.Identifier.Kind == SyntaxKind.None
                    ? $"unnamed{i}"
                    : element.Identifier.Text;

                var hasFuncDef = context.Config.FuncDefs.Any(d => d.DefName == element.Type.Identifier.Text);

                return (
                    TypeKind: element.Type.Kind,
                    TypeName: typeName,
                    Out: element.Type.Inout.Kind == SyntaxKind.Out ? "out " : string.Empty,
                    IdentifierName: identifierName,
                    HasFuncDef: hasFuncDef
                );
            }).ToImmutableArray();

        if (parameters.Any(p => p.HasFuncDef))
        {
            // TODO FuncDef fix
            return;
        }

        var parametersText = string.Join(", ", parameters.Select(p => $"{p.TypeName} {p.IdentifierName}"));

        var declarationParameters = node.ParameterList.Parameters
            .Select(p =>
            {
                var element = p.Element;
                var typeName = GeneratorFacts.GetTypeName(element.Type);
                var identifierName = element.Identifier.Text;

                return $"{typeName} {identifierName}";
            });

        var declarationParametersWithThisText = string.Join(", ", declarationParameters);

        var declaration = $"{GeneratorFacts.GetTypeName(node.ReturnType)} {methodName}({declarationParametersWithThisText})";

        writer.WriteLine($"public static {node.ReturnType.Identifier.Text} {methodName}({parametersText})");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            const string functionIndexVar = "functionIndex";

            writer.WriteLine($"var {functionIndexVar} = {GeneratorFacts.NativeBindingsName}.FindModuleFunction({GeneratorFacts.ModuleHandleName}, \"{declaration}\", true);");
#if DEBUG
            writer.WriteLine();
            writer.WriteLine("Debug.Assert(functionIndex >= 0);");
            writer.WriteLine();
#endif
            writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.PrepareModuleFunction({GeneratorFacts.ModuleHandleName}, {functionIndexVar});");
            writer.WriteLine();

            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];

                var value = $"{parameter.Out}{parameter.IdentifierName}";

                switch (parameter.TypeKind)
                {
                    case SyntaxKind.Int:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgInt({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    case SyntaxKind.UInt:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgUInt({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    case SyntaxKind.Bool:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgBoolean({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    case SyntaxKind.Float:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgFloat({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    case SyntaxKind.String:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgString({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    case SyntaxKind.Ref or SyntaxKind.QuestionMark:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgAddress({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    default:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgObject({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                }
            }

            writer.WriteLine();
            writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.ExecuteModuleFunction({GeneratorFacts.ModuleHandleName});");

            if (!node.ReturnType.IsVoid)
            {
                writer.WriteLine();

                switch (node.ReturnType.Kind)
                {
                    case SyntaxKind.Int:
                        writer.WriteLine($"return {GeneratorFacts.NativeBindingsName}.GetModuleReturnInt({GeneratorFacts.ModuleHandleName});");
                        break;
                    case SyntaxKind.UInt:
                        writer.WriteLine($"return {GeneratorFacts.NativeBindingsName}.GetModuleReturnUInt({GeneratorFacts.ModuleHandleName});");
                        break;
                    case SyntaxKind.Bool:
                        writer.WriteLine($"return {GeneratorFacts.NativeBindingsName}.GetModuleReturnBoolean({GeneratorFacts.ModuleHandleName});");
                        break;
                    case SyntaxKind.Float:
                        writer.WriteLine($"return {GeneratorFacts.NativeBindingsName}.GetModuleReturnFloat({GeneratorFacts.ModuleHandleName});");
                        break;
                    case SyntaxKind.String:
                        writer.WriteLine($"return {GeneratorFacts.NativeBindingsName}.GetModuleReturnString({GeneratorFacts.ModuleHandleName});");
                        break;
                    default:
                        writer.WriteLine($"return new {node.ReturnType.Identifier.Text}({GeneratorFacts.NativeBindingsName}.GetModuleReturnObject({GeneratorFacts.ModuleHandleName}));");
                        break;
                }
            }
        }

        writer.WriteLine("}");
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        var className = node.Identifier.Text;

        writer.WriteLine($"internal static class As{className}");
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

        var methodName = node.Identifier.Text;

        var parametersWithThis = node.ParameterList.Parameters
            .Select((p, i) =>
            {
                var element = p.Element;
                var typeName = GeneratorFacts.GetCSharpTypeName(element.Type);
                var identifierName = element.Identifier.Kind == SyntaxKind.None
                    ? $"unnamed{i}"
                    : element.Identifier.Text;

                var hasFuncDef = context.Config.FuncDefs.Any(d => d.DefName == element.Type.Identifier.Text);

                return (
                    TypeKind: element.Type.Kind,
                    TypeName: typeName,
                    Out: element.Type.Inout.Kind == SyntaxKind.Out ? "out " : string.Empty,
                    IdentifierName: identifierName,
                    HasFuncDef: hasFuncDef
                );
            })
            .Prepend((
                TypeKind: SyntaxKind.Identifier,
                TypeName: className,
                Out: string.Empty,
                IdentifierName: "@this",
                HasFuncDef: false)).ToImmutableArray();

        if (parametersWithThis.Any(p => p.HasFuncDef))
        {
            // TODO FuncDef fix
            return;
        }

        var parametersWithThisText = string.Join(", ", parametersWithThis.Select(p => $"{p.TypeName} {p.IdentifierName}"));

        var declarationParametersWithThis = node.ParameterList.Parameters
            .Select(p =>
            {
                var element = p.Element;
                var typeName = GeneratorFacts.GetTypeName(element.Type);
                var identifierName = element.Identifier.Text;

                return $"{typeName} {identifierName}";
            })
            .Prepend($"{className} _this");

        var declarationParametersWithThisText = string.Join(", ", declarationParametersWithThis);

        var declaration = $"{GeneratorFacts.GetTypeName(node.ReturnType)} ccb::_{className}::{methodName}({declarationParametersWithThisText})";

        writer.WriteLine($"public static {node.ReturnType.Identifier.Text} {methodName}({parametersWithThisText})");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            const string functionIndexVar = "functionIndex";

            writer.WriteLine($"var {functionIndexVar} = {GeneratorFacts.NativeBindingsName}.FindModuleFunction({GeneratorFacts.ModuleHandleName}, \"{declaration}\", true);");
#if DEBUG
            writer.WriteLine();
            writer.WriteLine("Debug.Assert(functionIndex >= 0);");
            writer.WriteLine();
#endif
            writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.PrepareModuleFunction({GeneratorFacts.ModuleHandleName}, {functionIndexVar});");
            writer.WriteLine();

            for (var i = 0; i < parametersWithThis.Length; i++)
            {
                var parameter = parametersWithThis[i];

                var value = $"{parameter.Out}{parameter.IdentifierName}";

                switch (parameter.TypeKind)
                {
                    case SyntaxKind.Int:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgInt({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    case SyntaxKind.UInt:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgUInt({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    case SyntaxKind.Bool:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgBoolean({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    case SyntaxKind.Float:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgFloat({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    case SyntaxKind.String:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgString({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    case SyntaxKind.Ref:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgAddress({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                    default:
                        writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.SetModuleArgObject({GeneratorFacts.ModuleHandleName}, {i}, {value});");
                        break;
                }
            }

            writer.WriteLine();
            writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.ExecuteModuleFunction({GeneratorFacts.ModuleHandleName});");

            if (!node.ReturnType.IsVoid)
            {
                writer.WriteLine();

                switch (node.ReturnType.Kind)
                {
                    case SyntaxKind.Int:
                        writer.WriteLine($"return {GeneratorFacts.NativeBindingsName}.GetModuleReturnInt({GeneratorFacts.ModuleHandleName});");
                        break;
                    case SyntaxKind.UInt:
                        writer.WriteLine($"return {GeneratorFacts.NativeBindingsName}.GetModuleReturnUInt({GeneratorFacts.ModuleHandleName});");
                        break;
                    case SyntaxKind.Bool:
                        writer.WriteLine($"return {GeneratorFacts.NativeBindingsName}.GetModuleReturnBoolean({GeneratorFacts.ModuleHandleName});");
                        break;
                    case SyntaxKind.Float:
                        writer.WriteLine($"return {GeneratorFacts.NativeBindingsName}.GetModuleReturnFloat({GeneratorFacts.ModuleHandleName});");
                        break;
                    case SyntaxKind.String:
                        writer.WriteLine($"return {GeneratorFacts.NativeBindingsName}.GetModuleReturnString({GeneratorFacts.ModuleHandleName});");
                        break;
                    default:
                        writer.WriteLine($"return new {node.ReturnType.Identifier.Text}({GeneratorFacts.NativeBindingsName}.GetModuleReturnObject({GeneratorFacts.ModuleHandleName}));");
                        break;
                }
            }
        }

        writer.WriteLine("}");
    }
}