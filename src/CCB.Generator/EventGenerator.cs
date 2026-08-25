namespace CCB.Generator;

using System.Collections.Immutable;
using CCB.Generator.Extensions;
using CCB.Syntax;
using CCB.Syntax.Visitor;

public class EventGenerator : SimpleVisitor, IDisposable
{
    private readonly ScriptEventGenerator _scriptEventGenerator;
    private readonly CSharpEventGenerator _csharpEventGenerator;

    private readonly RootSyntax _rootSyntax;

    public EventGenerator(RootSyntax rootSyntax, TextWriter scriptWriter, TextWriter csharpWriter)
    {
        this._rootSyntax = rootSyntax;

        var indentedScriptWriter = new IndentedTextWriter(scriptWriter);
        var indentedCSharpWriter = new IndentedTextWriter(csharpWriter);

        this._scriptEventGenerator = new ScriptEventGenerator(indentedScriptWriter);
        this._csharpEventGenerator = new CSharpEventGenerator(indentedCSharpWriter);
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

    public void Dispose()
    {
        this._csharpEventGenerator.Dispose();
        this._scriptEventGenerator.Dispose();
    }
}

internal class ScriptEventGenerator(IndentedTextWriter writer) : SimpleVisitor, IDisposable
{
    private readonly List<string> _events = [];

    public override void VisitRoot(RootSyntax root)
    {
        writer.WriteLine("#include \"uerm.as\"");

        writer.WriteLine();

        writer.WriteLine("namespace ccb");
        writer.WriteLine("{");

        using (writer.Scope())
        {
            writer.WriteLine("namespace event");
            writer.WriteLine("{");

            using (writer.Scope())
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

        writer.WriteLine();

        GenerateOnInitialize();

        return;

        void GenerateOnInitialize()
        {
            writer.WriteLine("void OnInitialize()");
            writer.WriteLine("{");

            using (writer.Scope())
            {
                writer.WriteLine("RegisterAllCallbacks();");

                foreach (var eventName in this._events)
                {
                    writer.WriteLine($"RegisterCallback({eventName}_c, ccb::event::On{eventName});");
                }
            }

            writer.WriteLine("}");
        }
    }

    public override void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
    {
        var eventName = node.Identifier.Text;
        var isVoid = node.ReturnType.IsVoid;
        var returnType = node.ReturnType.Identifier.Text;
        var parametersText = node.ParameterList.ToString();
        var argumentsText = string.Join(", ", node.ParameterList.Parameters.Select(p => p.Element.Identifier.Text));
        var handlerName = $"ccb_internal_invoke_{eventName}";

        writer.WriteLine($"{returnType} On{eventName}{parametersText}");
        writer.WriteLine("{");

        using (writer.Scope())
        {
            writer.WriteLine(isVoid
                ? $"{handlerName}({argumentsText});"
                : $"return {handlerName}({argumentsText});");
        }

        writer.WriteLine("}");

        this._events.Add(eventName);
    }

    public void Dispose()
    {
        writer.Dispose();
    }
}

internal class CSharpEventGenerator(IndentedTextWriter writer) : SimpleVisitor, IDisposable
{
    private readonly List<(string Declaration, string EventName, IEnumerable<(string Type, string Name)> Parameters, IEnumerable<(string Type, string Name)> RawParameters, string ReturnType, string HandlerName)> _events = [];

    public override void VisitRoot(RootSyntax root)
    {
        writer.WriteLine("namespace CCB.Internal;");
        writer.WriteLine();
        writer.WriteLine("using System.Runtime.CompilerServices;");
        writer.WriteLine("using System.Runtime.InteropServices;");
        writer.WriteLine();
        writer.WriteLine("public static class EventRegistry");
        writer.WriteLine("{");

        using (writer.Scope())
        {
            foreach (var member in root.Members)
            {
                writer.WriteLine();
                member.Accept(this);
            }

            writer.WriteLine();

            writer.WriteLine("internal static unsafe void RegisterEventFunctions()");
            writer.WriteLine("{");

            using (writer.Scope())
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

                    returnType = returnType == "bool" ? "int" : returnType;

                    writer.WriteLine($"{GeneratorFacts.NativeBindingsName}.RegisterGlobalFunction(\"{declaration}\", (IntPtr)(delegate* unmanaged[Stdcall]<{rawParameterTypesText}{returnType}>)(&{handlerName}));");
                }
            }

            writer.WriteLine("}");

            for (var i = 0; i < this._events.Count; i++)
            {
                if (i > 0)
                {
                    writer.WriteLine();
                }

                var eventInfo = this._events[i];
                var handlerName = GeneratorFacts.GetHandlerName(eventInfo.EventName);
                var parameters = eventInfo.Parameters.ToImmutableArray();
                var parametersText = string.Join(", ", parameters.Select(p => $"{p.Type} {p.Name}"));
                var hasEventArgs = parameters.Length > 0;

                if (hasEventArgs)
                {
                    writer.WriteLine($"public class {GeneratorFacts.GetEventArgName(eventInfo.EventName)}({parametersText})");
                    writer.WriteLine("{");

                    using (writer.Scope())
                    {
                        foreach (var parameter in eventInfo.Parameters)
                        {
                            writer.WriteLine($"public {parameter.Type} {parameter.Name.ToUpperCamelCase()} {{ get; }} = {parameter.Name};");
                            writer.WriteLine();
                        }

                        if (eventInfo.ReturnType != "void")
                        {
                            writer.WriteLine($"public {eventInfo.ReturnType} EventResult {{ get; set; }} = true;");
                        }
                    }

                    writer.WriteLine("}");
                    writer.WriteLine();
                    writer.WriteLine($"public delegate void {handlerName}({GeneratorFacts.GetEventArgName(eventInfo.EventName)} args);");
                }
                else
                {
                    writer.WriteLine($"public delegate void {handlerName}();");
                }

                writer.WriteLine();
                writer.WriteLine($"public static event {handlerName}? {eventInfo.EventName};");
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
                SyntaxKind.Identifier => "ObjectOpaque",
                SyntaxKind.String => "IntPtr",
                SyntaxKind.Bool => "int",
                _ => type,
            };
            var declarationType = element.Type.Identifier.Kind == SyntaxKind.String ? "const char" : type;

            var argument = element.Type.Identifier.Kind switch
            {
                SyntaxKind.Identifier => $"new {element.Type.Identifier.Text}({name})",
                SyntaxKind.String => $"Marshal.PtrToStringUTF8({name})!",
                SyntaxKind.Bool => $"{name} != 0",
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
        var hasEventArgs = arguments.Count > 0;

        var handlerName = GeneratorFacts.GetHandlerName(eventName) + "Internal";

        var isReturnBool = node.ReturnType.Identifier.Kind == SyntaxKind.Bool;
        var returnTypeConverted = isReturnBool ? "int" : returnTypeName;

        writer.WriteLine("[UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]");
        writer.WriteLine($"private static {returnTypeConverted} {handlerName}({rawParametersText})");
        writer.WriteLine("{");

        using (writer.Scope())
        {
            writer.WriteLine("try");
            writer.WriteLine("{");

            using (writer.Scope())
            {
                if (hasEventArgs)
                {
                    writer.WriteLine($"var args = new {GeneratorFacts.GetEventArgName(eventName)}({argumentsText});");

                    writer.WriteLine(node.ReturnType.Identifier.Kind switch
                    {
                        SyntaxKind.Void => $"{eventName}?.Invoke(args);",
                        SyntaxKind.Bool => $"{eventName}?.Invoke(args); return args.EventResult ? 1 : 0;",
                        _ => throw new NotSupportedException(),
                    });
                }
                else
                {
                    writer.WriteLine($"{eventName}?.Invoke();");
                }
            }

            writer.WriteLine("}");
            writer.WriteLine("catch(Exception e)");
            writer.WriteLine("{");

            using (writer.Scope())
            {
                writer.WriteLine("ScriptFunctions.print(e.ToString());");

                if (!node.ReturnType.IsVoid)
                {
                    writer.WriteLine("return 1;");
                }
            }

            writer.WriteLine("}");
        }

        writer.WriteLine("}");

        this._events.Add(($"{returnTypeName} ccb_internal_invoke_{eventName}({declarationParametersText})", eventName, parameters, rawParameters, returnTypeName, handlerName));
    }

    public void Dispose()
    {
        writer.Dispose();
    }
}