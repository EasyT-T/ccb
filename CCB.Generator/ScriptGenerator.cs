namespace CCB.Generator;

using System.Collections.Immutable;
using System.Text;
using CCB.Syntax;
using CCB.Syntax.Visitor;

public class ScriptGenerator : SimpleVisitor
{
    private readonly RootSyntax _root;
    private readonly IndentedTextWriter _writer;

    private readonly ClassGenerator _classGenerator;
    private readonly ClassFuncDefGenerator _funcDefGenerator;

    private readonly GenerateConfigBuilder _configBuilder;

    public ScriptGenerator(RootSyntax root, TextWriter writer, GenerateConfigBuilder configBuilder)
    {
        this._root = root;
        this._writer = new IndentedTextWriter(writer);
        this._classGenerator = new ClassGenerator(this._writer);
        this._funcDefGenerator = new ClassFuncDefGenerator(this._writer);
        this._configBuilder = configBuilder;
    }

    public void Generate()
    {
        this._root.Accept(this);

        this._writer.Flush();
    }

    public override void VisitRoot(RootSyntax root)
    {
        this._writer.WriteLine("void OnInitialize()");
        this._writer.WriteLine("{");

        using (this._writer.Indent())
        {
            this._writer.WriteLine($"SetLibrary(LoadLibrary(\"{this._configBuilder.ExternalAssemblyPath}\"));");
            this._writer.WriteLine($"SetConvType({this._configBuilder.ConvType});");

            this._writer.WriteLine("ccb::internal::register_external_functions();");
            this._writer.WriteLine("ccb::internal::register_all_functions();");
        }

        this._writer.WriteLine("}");

        this._writer.WriteLine();

        this._writer.WriteLine("namespace ccb");
        this._writer.WriteLine("{");

        using (this._writer.Indent())
        {
            root.Accept(this._funcDefGenerator);

            for (var i = 0; i < root.Members.Count; i++)
            {
                if (i > 0)
                {
                    this._writer.WriteLine();
                }

                var member = root.Members[i];
                member.Accept(this);
            }
        }

        this._writer.WriteLine("}");
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

internal class ClassGenerator(IndentedTextWriter writer) : SimpleVisitor
{
    private readonly ClassImplGenerator _implGenerator = new ClassImplGenerator(writer);

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        writer.WriteLine($"namespace {node.Identifier.Text}");
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

internal class ClassFuncDefGenerator(IndentedTextWriter writer) : SimpleVisitor
{
    private int _index = 1;

    private readonly Dictionary<FuncDefList, int> _defKeyMap = [];

    private readonly List<(string className, string methodName, int index)> _defList = [];

    public override void VisitRoot(RootSyntax root)
    {
        const string registerMethodName = "register_method";

        writer.WriteLine("namespace Internal");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            foreach (var member in root.Members)
            {
                member.Accept(this);
            }

            writer.WriteLine();

            writer.WriteLine("external shared bool load_ccb();");

            foreach (var funcDef in this._defKeyMap.Values.Select(GeneratorHelper.GetFuncDefName))
            {
                writer.WriteLine($"external shared void {registerMethodName}(int index, const char class_name, const char method_name, {funcDef} @def);");
            }

            writer.WriteLine();

            writer.WriteLine("void register_external_functions()");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                writer.WriteLine("RegisterFunction(\"bool load_ccb()\", \"load_ccb\");");

                foreach (var funcDef in this._defKeyMap.Values.Select(GeneratorHelper.GetFuncDefName))
                {
                    writer.WriteLine($"RegisterFunction(\"{registerMethodName}(int index, const char class_name, const char method_name, {funcDef} @def)\", \"{registerMethodName}\");");
                }
            }

            writer.WriteLine("}");

            writer.WriteLine();

            writer.WriteLine("void register_all_functions()");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                foreach (var (className, methodName, index) in this._defList)
                {
                    var funcDef = GeneratorHelper.GetFuncDefName(index);

                    writer.WriteLine($"{registerMethodName}({index}, \"{className}\", \"{methodName}\", cast<{funcDef}>(@{className}::{methodName}));");
                }
            }

            writer.WriteLine("}");
        }

        writer.WriteLine("}");
        writer.WriteLine();
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
        var list = ConstructMethodDef(node, out var parameterTypeList);

        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var methodName = node.Identifier.Text;

        if (!this._defKeyMap.TryGetValue(list, out var index))
        {
            index = this._index++;

            this._defKeyMap.Add(list, index);

            var returnTypeName = node.ReturnType.Identifier.Text + node.ReturnType.RefHandle.Text;

            writer.WriteLine($"funcdef {returnTypeName} {GeneratorHelper.GetFuncDefName(index)}({string.Join(", ", parameterTypeList)});");
        }

        this._defList.Add((className, methodName, index));

        return;

        static FuncDefList ConstructMethodDef(MethodDeclarationSyntax node, out IEnumerable<string> parameterTypeList)
        {
            var parameters = GeneratorHelper.ExtractParameters(node);

            parameterTypeList = parameters.Select(p => p.TypeName);
            return new FuncDefList(node.ReturnType.Identifier.Text, parameterTypeList);
        }
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var typeName = node.Type.Identifier.Text + node.Type.RefHandle.Text;

        var getDef = new FuncDefList(typeName, [className]);
        var setDef = new FuncDefList("void", [className, typeName]);

        var getMethodName = $"Get{node.Identifier.Text}";
        var setMethodName = $"Set{node.Identifier.Text}";

        if (!this._defKeyMap.TryGetValue(getDef, out var getIndex))
        {
            getIndex = this._index++;

            this._defKeyMap.Add(getDef, getIndex);

            writer.WriteLine($"funcdef {typeName} {GeneratorHelper.GetFuncDefName(getIndex)}({className});");
        }

        if (!this._defKeyMap.TryGetValue(setDef, out var setIndex))
        {
            setIndex = this._index++;

            this._defKeyMap.Add(setDef, setIndex);

            writer.WriteLine($"funcdef void {GeneratorHelper.GetFuncDefName(setIndex)}({className}, {typeName});");
        }

        this._defList.Add((className, getMethodName, getIndex));
        this._defList.Add((className, setMethodName, setIndex));
    }
}

internal class ClassImplGenerator(IndentedTextWriter writer) : SimpleVisitor
{
    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var isVoid = node.ReturnType.IsVoid;
        var returnTypeName = node.ReturnType.Identifier.Text + node.ReturnType.RefHandle.Text;
        var leadingModifiersText = GeneratorHelper.JoinModifiers(node.LeadingModifiers);
        var trailingModifiersText = GeneratorHelper.JoinModifiers(node.TrailingModifiers);
        var methodName = node.Identifier.Text;

        var parameters = GeneratorHelper.ExtractParameters(node);
        var parametersText = GeneratorHelper.BuildParametersText(className, parameters);
        var argumentsText = string.Join(", ", parameters.Select(p => p.ParameterName));

        writer.WriteLine($"{leadingModifiersText}{returnTypeName} {methodName}({parametersText}){trailingModifiersText}");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine(isVoid
                ? $"{GeneratorHelper.ThisVarName}.{methodName}({argumentsText});"
                : $"return {GeneratorHelper.ThisVarName}.{methodName}({argumentsText});");
        }

        writer.WriteLine("}");
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var typeName = node.Type.Identifier.Text + node.Type.RefHandle.Text;

        writer.WriteLine($"{typeName} Get{node.Identifier.Text}({className} {GeneratorHelper.ThisVarName})");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine($"return {GeneratorHelper.ThisVarName}.{node.Identifier.Text};");
        }

        writer.WriteLine("}");

        writer.WriteLine();

        writer.WriteLine($"void Set{node.Identifier.Text}({className} {GeneratorHelper.ThisVarName}, {typeName} value)");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            writer.WriteLine($"{GeneratorHelper.ThisVarName}.{node.Identifier.Text} = value;");
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
    public const string ThisVarName = "_this";

    public static string GetFuncDefName(int index)
    {
        return $"_FUNC_DEF_{index}";
    }

    public static ImmutableArray<(string TypeName, string ParameterName)> ExtractParameters(MethodDeclarationSyntax node)
    {
        return node.ParameterList.Parameters
            .Select((p, i) =>
            {
                var element = p.Element;
                var typeName = element.Type.Identifier.Text + element.Type.RefHandle.Text;
                var paramName = element.Unnamed ? $"unname{i}" : element.Identifier.Text;

                return (TypeName: typeName, ParameterName: paramName);
            })
            .ToImmutableArray();
    }

    public static string BuildParametersText(string className, ImmutableArray<(string TypeName, string ParameterName)> parameters)
    {
        return string.Join(", ",
            parameters
                .Select(p => $"{p.TypeName} {p.ParameterName}")
                .Prepend($"{className} {ThisVarName}"));
    }

    public static string JoinModifiers(SyntaxTokenList modifiers)
    {
        return modifiers.Count > 0
            ? string.Join(' ', modifiers.Select(m => m.Text))
            : string.Empty;
    }
}