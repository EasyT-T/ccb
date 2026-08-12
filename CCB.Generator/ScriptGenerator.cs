namespace CCB.Generator;

using System.Collections.Immutable;
using System.Text;
using CCB.Syntax;
using CCB.Syntax.Visitor;

public class ScriptGenerator : SimpleVisitor
{
    private readonly RootSyntax _root;
    private readonly IndentedTextWriter _scriptWriter;
    private readonly IndentedTextWriter _pluginWriter;

    private readonly ClassGenerator _classGenerator;
    private readonly ClassFuncDefGenerator _funcDefGenerator;

    private readonly GenerateConfigBuilder _configBuilder;

    public ScriptGenerator(RootSyntax root, TextWriter scriptWriter, TextWriter pluginWriter, GenerateConfigBuilder configBuilder)
    {
        this._root = root;
        this._scriptWriter = new IndentedTextWriter(scriptWriter);
        this._pluginWriter = new IndentedTextWriter(pluginWriter);
        this._classGenerator = new ClassGenerator(this._scriptWriter);
        this._funcDefGenerator = new ClassFuncDefGenerator(this._scriptWriter, this._pluginWriter);
        this._configBuilder = configBuilder;
    }

    public void Generate()
    {
        this._root.Accept(this);

        this._scriptWriter.Flush();
    }

    public override void VisitRoot(RootSyntax root)
    {
        this._pluginWriter.WriteLine("void OnInitialize()");
        this._pluginWriter.WriteLine("{");

        using (this._pluginWriter.Indent())
        {
            this._pluginWriter.WriteLine($"SetLibrary(LoadLibrary(\"{this._configBuilder.ExternalAssemblyPath}\"));");
            this._pluginWriter.WriteLine($"SetConvType({this._configBuilder.ConvType});");

            this._pluginWriter.WriteLine("register_all_funcdef();");
            this._pluginWriter.WriteLine("register_external_functions();");
        }

        this._pluginWriter.WriteLine("}");

        this._pluginWriter.WriteLine();
        this._pluginWriter.WriteLine(GeneratorFacts.PluginCode);
        this._pluginWriter.WriteLine();

        this._scriptWriter.WriteLine("void OnInitialize()");
        this._scriptWriter.WriteLine("{");

        using (this._scriptWriter.Indent())
        {
            this._scriptWriter.WriteLine("load_ccb();");
            this._scriptWriter.WriteLine("ccb::internal::register_all_functions();");
        }

        this._scriptWriter.WriteLine("}");
        this._scriptWriter.WriteLine();

        this._scriptWriter.WriteLine("namespace ccb");
        this._scriptWriter.WriteLine("{");

        using (this._scriptWriter.Indent())
        {
            root.Accept(this._funcDefGenerator);

            for (var i = 0; i < root.Members.Count; i++)
            {
                if (i > 0)
                {
                    this._scriptWriter.WriteLine();
                }

                var member = root.Members[i];
                member.Accept(this);
            }
        }

        this._scriptWriter.WriteLine("}");
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        node.Accept(this._classGenerator);
    }
}

internal class FuncDefList(string returnType, IEnumerable<string> parameters) : IEquatable<FuncDefList>
{
    private readonly string _returnType = returnType;

    private readonly IEnumerable<string> _parameters = parameters;

    public bool Equals(FuncDefList? other)
    {
        return other is not null && other._returnType == this._returnType && this._parameters.SequenceEqual(other._parameters);
    }

    public override bool Equals(object? obj)
    {
        return obj is FuncDefList other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(this._returnType);

        foreach (var param in this._parameters)
        {
            hash.Add(param);
        }

        return hash.ToHashCode();
    }

    public static bool operator ==(FuncDefList? left, FuncDefList? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(FuncDefList? left, FuncDefList? right)
    {
        return !Equals(left, right);
    }
}

internal class ClassFuncDefGenerator(IndentedTextWriter scriptWriter, IndentedTextWriter pluginWriter) : SimpleVisitor
{
    private int _index = 1;

    private readonly Dictionary<FuncDefList, int> _defKeyMap = [];

    private readonly List<(string className, string methodName, int index)> _defList = [];

    public override void VisitRoot(RootSyntax root)
    {
        const string registerMethodName = "register_method";

        scriptWriter.WriteLine("namespace internal");
        scriptWriter.WriteLine("{");

        pluginWriter.WriteLine("void register_all_funcdef()");
        pluginWriter.WriteLine("{");

        using (scriptWriter.Indent())
        using (pluginWriter.Indent())
        {
            foreach (var member in root.Members)
            {
                member.Accept(this);
            }

            scriptWriter.WriteLine("void register_all_functions()");
            scriptWriter.WriteLine("{");

            using (scriptWriter.Indent())
            {
                for (var i = 0; i < this._defList.Count; i++)
                {
                    var (className, methodName, index) = this._defList[i];
                    var funcDef = GeneratorHelper.GetFuncDefName(index);

                    scriptWriter.WriteLine($"{funcDef} @func{i} = @_{className}::{methodName};");
                    scriptWriter.WriteLine(
                        $"{registerMethodName}({index}, \"{className}\", \"{methodName}\", func{i});");
                }
            }

            scriptWriter.WriteLine("}");
        }

        scriptWriter.WriteLine("}");
        scriptWriter.WriteLine();

        pluginWriter.WriteLine("}");
        pluginWriter.WriteLine();
        pluginWriter.WriteLine("void register_external_functions()");
        pluginWriter.WriteLine("{");

        using (pluginWriter.Indent())
        {
            pluginWriter.WriteLine("RegisterFunction(\"bool load_ccb()\", \"load_ccb\");");

            foreach (var funcDef in this._defKeyMap.Values.Select(GeneratorHelper.GetFuncDefName))
            {
                pluginWriter.WriteLine($"RegisterFunction(\"void {registerMethodName}(int index, const char class_name, const char method_name, {funcDef} @def)\", \"{registerMethodName}\");");
            }
        }

        pluginWriter.WriteLine("}");
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

        var list = ConstructMethodDef(node, className, out var parameters);

        if (!this._defKeyMap.TryGetValue(list, out var index))
        {
            var parametersText = string.Join(", ", parameters);

            index = this._index++;

            this._defKeyMap.Add(list, index);

            var returnTypeName = node.ReturnType.Identifier.Text + node.ReturnType.RefHandle.Text;

            // TODO Find a better way to fix TXT_REF_CANT_BE_RETURNED_DEFERRED_PARAM
            if (className == "Config" && methodName == "Get")
            {
                returnTypeName = "string";
            }

            pluginWriter.WriteLine($"RegisterFuncdef(\"{returnTypeName} {GeneratorHelper.GetFuncDefName(index)}({parametersText})\");");
        }

        this._defList.Add((className, methodName, index));

        return;

        static FuncDefList ConstructMethodDef(MethodDeclarationSyntax node, string className, out IEnumerable<string> parameters)
        {
            parameters = node.ParameterList.Parameters
                .Select(p => GeneratorHelper.GetTypeName(p.Element.Type))
                .Prepend(className);

            return new FuncDefList(node.ReturnType.Identifier.Text, parameters);
        }
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var typeName = GeneratorHelper.GetReturnTypeName(node);

        var getDef = new FuncDefList(typeName, [className]);
        var getMethodName = $"Get{node.Identifier.Text}";

        if (!this._defKeyMap.TryGetValue(getDef, out var getIndex))
        {
            getIndex = this._index++;

            this._defKeyMap.Add(getDef, getIndex);

            pluginWriter.WriteLine($"RegisterFuncdef(\"{typeName} {GeneratorHelper.GetFuncDefName(getIndex)}({className})\");");
        }

        this._defList.Add((className, getMethodName, getIndex));

        if (node.Modifiers.Any(SyntaxKind.Const))
        {
            return;
        }

        var setDef = new FuncDefList("void", [className, typeName]);
        var setMethodName = $"Set{node.Identifier.Text}";

        if (!this._defKeyMap.TryGetValue(setDef, out var setIndex))
        {
            setIndex = this._index++;

            this._defKeyMap.Add(setDef, setIndex);

            pluginWriter.WriteLine($"RegisterFuncdef(\"void {GeneratorHelper.GetFuncDefName(setIndex)}({className}, {typeName})\");");
        }

        this._defList.Add((className, setMethodName, setIndex));
    }
}

internal class ClassGenerator(IndentedTextWriter writer) : SimpleVisitor
{
    private readonly ClassImplGenerator _implGenerator = new ClassImplGenerator(writer);

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        writer.WriteLine($"namespace _{node.Identifier.Text}");
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
                member.Accept(this._implGenerator);
            }
        }

        writer.WriteLine("}");
    }
}

internal class ClassImplGenerator(IndentedTextWriter writer) : SimpleVisitor
{
    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var isVoid = node.ReturnType.IsVoid;
        var returnTypeName = GeneratorHelper.GetTypeName(node.ReturnType);
        var leadingModifiersText = node.LeadingModifiers.Count > 0
            ? string.Join(' ', node.LeadingModifiers.Select(m => m.Text))
            : string.Empty;
        var methodName = node.Identifier.Text;

        var parameters = node.ParameterList.Parameters
            .Select((p, i) =>
            {
                var element = p.Element;
                var typeName = GeneratorHelper.GetTypeName(element.Type);
                var paramName = element.Unnamed ? $"unname{i}" : element.Identifier.Text;

                return (TypeName: typeName, ParameterName: paramName);
            })
            .ToImmutableArray();

        var parametersText = string.Join(", ",
            parameters
                .Select(p => $"{p.TypeName} {p.ParameterName}")
                .Prepend($"{className} {GeneratorFacts.ThisVarName}"));
        var argumentsText = string.Join(", ", parameters.Select(p => p.ParameterName));

        // TODO Find a better way to fix TXT_REF_CANT_BE_RETURNED_DEFERRED_PARAM
        if (className == "Config" && methodName == "Get")
        {
            returnTypeName = "string";
        }

        writer.WriteLine($"{leadingModifiersText}{returnTypeName} {methodName}({parametersText})");
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
        var typeName = GeneratorHelper.GetReturnTypeName(node);

        writer.WriteLine($"{typeName} Get{node.Identifier.Text}({className} {GeneratorFacts.ThisVarName})");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine($"return {GeneratorFacts.ThisVarName}.{node.Identifier.Text};");
        }

        writer.WriteLine("}");

        if (node.Modifiers.Any(SyntaxKind.Const))
        {
            return;
        }

        writer.WriteLine();

        writer.WriteLine($"void Set{node.Identifier.Text}({className} {GeneratorFacts.ThisVarName}, {typeName} value)");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine($"{GeneratorFacts.ThisVarName}.{node.Identifier.Text} = value;");
        }

        writer.WriteLine("}");
    }
}

internal class IndentedTextWriter(TextWriter innerWriter, string indentString = "    ") : TextWriter
{
    private int _indentLevel;
    private bool _isAtFirstLine = true;

    public override Encoding Encoding { get; } = innerWriter.Encoding;

    public IndentScope Indent()
    {
        this._indentLevel++;
        return new IndentScope(this);
    }

    public override void Write(char value)
    {
        if (this._isAtFirstLine && value is not '\r' and not '\n')
        {
            this.WriteIndent();
            this._isAtFirstLine = false;
        }

        innerWriter.Write(value);

        if (value is '\n')
        {
            this._isAtFirstLine = true;
        }
    }

    private void WriteIndent()
    {
        for (var i = 0; i < this._indentLevel; i++)
        {
            innerWriter.Write(indentString);
        }
    }

    public readonly ref struct IndentScope(IndentedTextWriter writer)
    {
        public void Dispose()
        {
            writer._indentLevel--;
        }
    }
}

internal static class GeneratorHelper
{
    public static string GetFuncDefName(int index)
    {
        return $"_FUNC_DEF_{index}";
    }

    public static string GetReturnTypeName(FieldDeclarationSyntax node)
    {
        return node.Modifiers.Count > 0
            ? string.Join(' ', node.Modifiers) + ' ' + node.Type.Identifier.Text + node.Type.RefHandle.Text
            : node.Type.Identifier.Text + node.Type.RefHandle.Text;
    }

    public static string GetTypeName(TypeSyntax type)
    {
        return type.Inout.Kind == SyntaxKind.None
            ? type.Identifier.Text + type.RefHandle.Text
            : type.Identifier.Text + type.RefHandle.Text + ' ' + type.Inout.Text;
    }
}