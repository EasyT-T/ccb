namespace CCB.Generator;

using CCB.Generator.Extensions;
using CCB.Syntax;
using CCB.Syntax.Visitor;

public class EventGenerator : SimpleVisitor
{
    private readonly ScriptEventGenerator _scriptEventGenerator;
    private readonly CSharpEventGenerator _csharpEventGenerator;

    private readonly RootSyntax _rootSyntax;

    public EventGenerator(RootSyntax rootSyntax, TextWriter scriptWriter, TextWriter csharpWriter, GenerateConfig config)
    {
        this._rootSyntax = rootSyntax;

        var indentedScriptWriter = new IndentedTextWriter(scriptWriter);
        var indentedCSharpWriter = new IndentedTextWriter(csharpWriter);

        this._scriptEventGenerator = new ScriptEventGenerator(indentedScriptWriter, config);
        this._csharpEventGenerator = new CSharpEventGenerator(indentedCSharpWriter, config);
    }

    public void Generate()
    {
        this._rootSyntax.Accept(this);
    }

    public override void VisitRoot(RootSyntax root)
    {
        root.Accept(this._scriptEventGenerator);
        root.Accept(this._csharpEventGenerator);
    }
}

internal class ScriptEventGenerator(IndentedTextWriter writer, GenerateConfig config) : SimpleVisitor
{
    public override void VisitRoot(RootSyntax root)
    {
        writer.WriteLine("namespace ccb");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine("namespace event");
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
        }

        writer.WriteLine("}");
    }

    public override void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
    {
        var eventName = node.Identifier.Text;
        var isVoid = node.ReturnType.IsVoid;
        var returnType = node.ReturnType.Identifier.Text;
        var parametersText = node.ParameterList.ToString();
        var argumentsText = string.Join(", ", node.ParameterList.Parameters.Select(p => p.Element.Identifier.Text));

        writer.WriteLine($"{returnType} On{eventName}{parametersText}");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine(isVoid
                ? $"ccb::internal::invoke_{eventName}({argumentsText});"
                : $"return ccb::internal::invoke_{eventName}({argumentsText});");
        }

        writer.WriteLine("}");
    }
}

internal class CSharpEventGenerator(IndentedTextWriter writer, GenerateConfig config) : SimpleVisitor
{
    private readonly List<(string Declaration, string EventName, IEnumerable<(string Type, string Name)> Parameters, IEnumerable<(string Type, string Name)> RawParameters, string ReturnType, string HandlerName)> _events = [];

    public override void VisitRoot(RootSyntax root)
    {
        writer.WriteLine("namespace CCB.Internal;");
        writer.WriteLine();
        writer.WriteLine("using System.Runtime.CompilerServices;");
        writer.WriteLine("using System.Runtime.InteropServices;");
        writer.WriteLine();
        writer.WriteLine("internal static class EventRegistry");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine("public static EventHandler GlobalHandler { get; internal set; }");

            foreach (var member in root.Members)
            {
                writer.WriteLine();
                member.Accept(this);
            }

            writer.WriteLine();

            writer.WriteLine("internal static unsafe void RegisterEventFunctions()");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                for (var i = 0; i < this._events.Count; i++)
                {
                    if (i > 0)
                    {
                        writer.WriteLine();
                    }

                    var (declaration, _, _, rawParameters, returnType, handlerName) = this._events[i];
                    var rawParameterTypesText = string.Join(", ", rawParameters.Select(p => p.Type));

                    if (!string.IsNullOrEmpty(rawParameterTypesText))
                    {
                        rawParameterTypesText += ", ";
                    }

                    writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.RegisterGlobalFunction(\"{declaration}\", (IntPtr)(delegate* unmanaged[Stdcall]<{rawParameterTypesText}{returnType}>)(&{handlerName}));");
                }
            }

            writer.WriteLine("}");
        }

        writer.WriteLine("}");

        writer.WriteLine();

        writer.WriteLine("internal abstract class EventHandler");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            for (var i = 0; i < this._events.Count; i++)
            {
                if (i > 0)
                {
                    writer.WriteLine();
                }

                var eventInfo = this._events[i];
                var handlerName = GeneratorFacts.GetHandlerName(eventInfo.EventName);
                var parametersText = string.Join(", ", eventInfo.Parameters.Select(p => $"{p.Type} {p.Name}"));

                writer.WriteLine($"public abstract {eventInfo.ReturnType} {handlerName}({parametersText});");
            }
        }

        writer.WriteLine("}");
    }

    public override void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
    {
        var eventName = node.Identifier.Text;
        var returnTypeName = node.ReturnType.Identifier.Text;

        var declarationParameters = new List<string>();
        var parameters = new List<(string Type, string Name)>();
        var rawParameters = new List<(string Type, string Name)>();
        var arguments = new List<string>();

        foreach (var parameter in node.ParameterList.Parameters)
        {
            var element = parameter.Element;

            var name = element.Identifier.Text;

            if (name == "object")
            {
                name = "@object";
            }

            var type = element.Type.Identifier.Text;
            var rawType = element.Type.Identifier.Kind switch
            {
                SyntaxKind.Identifier => "ObjectHandle",
                SyntaxKind.String => "IntPtr",
                _ => type,
            };
            var declarationType = element.Type.Identifier.Kind == SyntaxKind.String ? "const char" : type;

            var argument = element.Type.Identifier.Kind switch
            {
                SyntaxKind.Identifier => $"new {element.Type.Identifier.Text}({name})",
                SyntaxKind.String => $"Marshal.PtrToStringUTF8({name})!",
                _ => name,
            };

            declarationParameters.Add(declarationType);
            parameters.Add((element.Type.Identifier.Text, name));
            rawParameters.Add((rawType, name));
            arguments.Add(argument);
        }

        var declarationParametersText = string.Join(", ", declarationParameters);
        var rawParametersText = string.Join(", ", rawParameters.Select(p => $"{p.Type} {p.Name}"));
        var argumentsText = string.Join(", ", arguments);

        var handlerName = GeneratorFacts.GetHandlerName(eventName);

        writer.WriteLine("[UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]");
        writer.WriteLine($"private static {returnTypeName} {handlerName}({rawParametersText})");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine(node.ReturnType.IsVoid
                ? $"GlobalHandler.{handlerName}({argumentsText});"
                : $"return GlobalHandler.{handlerName}({argumentsText});");
        }

        writer.WriteLine("}");

        this._events.Add(($"{returnTypeName} ccb::internal::invoke_{eventName}{declarationParametersText}", eventName, parameters, rawParameters, returnTypeName, handlerName));
    }
}