namespace CCB.Generator;

using System.Collections.Immutable;
using System.Text;
using CCB.Syntax;
using CCB.Syntax.Visitor;

internal class AngelScriptGenerator(IndentedTextWriter writer, GeneratorContext context) : SimpleVisitor
{
    private readonly NewClassFuncDefGenerator _funcDefGenerator = new NewClassFuncDefGenerator(context);

    public override void VisitRoot(RootSyntax root)
    {
        root.Accept(this._funcDefGenerator);

        GenerateOnInitialize();

        writer.WriteLine();

        GenerateInternal();

        writer.WriteLine();

        writer.WriteLine("namespace ccb");
        writer.WriteLine("{");

        using (writer.Indent())
        {
            root.Accept(this._funcDefGenerator);

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
                writer.WriteLine("ccb::internal::register_all_functions();");
            }

            writer.WriteLine("}");
            writer.WriteLine();
        }

        void GenerateInternal()
        {
            writer.WriteLine($"void {GeneratorFacts.RegisterAllFunctionsName}()");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                foreach (var (className, methodName, index) in context.DefList)
                {
                    var funcDef = GeneratorFacts.GetFuncDefName(index);

                    writer.WriteLine($"{GeneratorFacts.RegisterMethodName}({index}, \"{className}\", \"{methodName}\", cast<{funcDef}>(@ccb::_{className}::{methodName}))");
                }
            }

            writer.WriteLine("}");
        }
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;

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
        GenerateRegisterAllFuncDefs();
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

                writer.WriteLine($"{GeneratorFacts.RegisterAllFunctionDefsName}();");
                writer.WriteLine($"{GeneratorFacts.RegisterAllFunctionsName}();");
            }

            writer.WriteLine("}");
        }

        void GenerateRegisterAllFuncDefs()
        {
            writer.WriteLine($"void {GeneratorFacts.RegisterAllFunctionDefsName}()");
            writer.WriteLine("{");

            using (writer.Indent())
            {
                foreach (var (defList, index) in context.FunctionDefinitions)
                {
                    var returnTypeName = defList.ReturnType;
                    var funcDefName = GeneratorFacts.GetFuncDefName(index);
                    var parametersWithThisText = string.Join(", ", defList.Parameters);

                    writer.WriteLine($"{GeneratorFacts.RegisterFuncdefName}(\"{returnTypeName} {funcDefName}({parametersWithThisText})\");");
                }
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

                foreach (var funcDef in context.FunctionDefinitions.Values.Select(GeneratorFacts.GetFuncDefName))
                {
                    GenerateRegisterFunction(GeneratorFacts.RegisterMethodDef(funcDef), GeneratorFacts.RegisterMethodName);
                }
            }

            writer.WriteLine("}");

            return;

            void GenerateRegisterFunction(string funcDef, string funcName)
            {
                writer.WriteLine($"{GeneratorFacts.RegisterFunctionName}(\"{funcDef}\", \"{funcName}\");");
            }
        }
    }
}

internal class NewClassFuncDefGenerator(GeneratorContext context) : SimpleVisitor
{
    private int _index = 1;

    public override void VisitRoot(RootSyntax root)
    {
        foreach (var member in root.Members)
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

        if (!this._defKeyMap.TryGetValue(definition, out var index))
        {
            index = this._index++;

            this._defKeyMap.Add(definition, index);
        }

        this._defList.Add((className, methodName, index));
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
            var getDef = new FunctionDefinition(typeName, [className]);
            var getMethodName = $"Get{node.Identifier.Text}";

            if (!this._defKeyMap.TryGetValue(getDef, out var getIndex))
            {
                getIndex = this._index++;

                this._defKeyMap.Add(getDef, getIndex);
            }


            this._defList.Add((className, getMethodName, getIndex));
        }

        void GenerateSet()
        {
            var setDef = new FunctionDefinition("void", [className, typeName]);
            var setMethodName = $"Set{node.Identifier.Text}";

            if (!this._defKeyMap.TryGetValue(setDef, out var setIndex))
            {
                setIndex = this._index++;

                this._defKeyMap.Add(setDef, setIndex);
            }

            this._defList.Add((className, setMethodName, setIndex));
        }
    }
}

internal class ClassFuncDefGenerator(IndentedTextWriter scriptWriter, IndentedTextWriter pluginWriter, GeneratorContext context) : SimpleVisitor
{
    private int _index = 1;

    private readonly Dictionary<FunctionDefinition, int> _defKeyMap = context.FunctionDefinitions;

    private readonly List<(string className, string methodName, int index)> _defList = context.DefList;

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
                    var funcDef = GeneratorFacts.GetFuncDefName(index);

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

            foreach (var funcDef in this._defKeyMap.Values.Select(GeneratorFacts.GetFuncDefName))
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

            pluginWriter.WriteLine($"RegisterFuncdef(\"{returnTypeName} {GeneratorFacts.GetFuncDefName(index)}({parametersText})\");");
        }

        this._defList.Add((className, methodName, index));

        return;

        static FunctionDefinition ConstructMethodDef(MethodDeclarationSyntax node, string className, out IEnumerable<string> parameters)
        {
            parameters = node.ParameterList.Parameters
                .Select(p => GeneratorFacts.GetTypeName(p.Element.Type))
                .Prepend(className);

            return new FunctionDefinition(node.ReturnType.Identifier.Text, parameters);
        }
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        var className = ((ClassDeclarationSyntax)node.Parent!).Identifier.Text;
        var typeName = GeneratorFacts.GetReturnTypeName(node);

        var getDef = new FunctionDefinition(typeName, [className]);
        var getMethodName = $"Get{node.Identifier.Text}";

        if (!this._defKeyMap.TryGetValue(getDef, out var getIndex))
        {
            getIndex = this._index++;

            this._defKeyMap.Add(getDef, getIndex);

            pluginWriter.WriteLine($"RegisterFuncdef(\"{typeName} {GeneratorFacts.GetFuncDefName(getIndex)}({className})\");");
        }

        this._defList.Add((className, getMethodName, getIndex));

        if (node.Modifiers.Any(SyntaxKind.Const))
        {
            return;
        }

        var setDef = new FunctionDefinition("void", [className, typeName]);
        var setMethodName = $"Set{node.Identifier.Text}";

        if (!this._defKeyMap.TryGetValue(setDef, out var setIndex))
        {
            setIndex = this._index++;

            this._defKeyMap.Add(setDef, setIndex);

            pluginWriter.WriteLine($"RegisterFuncdef(\"void {GeneratorFacts.GetFuncDefName(setIndex)}({className}, {typeName})\");");
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
        var typeName = GeneratorFacts.GetReturnTypeName(node);

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