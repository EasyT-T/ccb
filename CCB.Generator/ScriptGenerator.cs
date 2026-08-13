namespace CCB.Generator;

using CCB.Syntax;
using CCB.Syntax.Visitor;

public class ScriptGenerator : SimpleVisitor
{
    private readonly RootSyntax _root;

    private readonly DefinitionsGenerator _definitionGenerator;

    private readonly AngelScriptGenerator _angelScriptGenerator;

    private readonly AngelPluginGenerator _angelPluginGenerator;

    private readonly CSharpScriptGenerator _csharpScriptGenerator;

    public ScriptGenerator(RootSyntax root, TextWriter scriptWriter, TextWriter pluginWriter, TextWriter csharpWriter, GenerateConfig config)
    {
        this._root = root;
        var scriptIndentedWriter = new IndentedTextWriter(scriptWriter);
        var pluginIndentedWriter = new IndentedTextWriter(pluginWriter);
        var csharpIndentedWriter = new IndentedTextWriter(csharpWriter);

        var context = new GeneratorContext([], [], config);

        this._definitionGenerator = new DefinitionsGenerator(context);
        this._angelScriptGenerator = new AngelScriptGenerator(scriptIndentedWriter);
        this._angelPluginGenerator = new AngelPluginGenerator(pluginIndentedWriter, context);
        this._csharpScriptGenerator = new CSharpScriptGenerator(csharpIndentedWriter, context);
    }

    public void Generate()
    {
        this._root.Accept(this);
    }

    public override void VisitRoot(RootSyntax root)
    {
        root.Accept(this._definitionGenerator);
        root.Accept(this._angelPluginGenerator);
        root.Accept(this._angelScriptGenerator);
        root.Accept(this._csharpScriptGenerator);
    }
}

internal record GeneratorContext(
    HashSet<FunctionDefinition> FunctionDefinitions,
    HashSet<MethodMetadata> FunctionMetadatas,
    GenerateConfig Config);