namespace CCB.Generator;

using CCB.Syntax;
using CCB.Syntax.Visitor;

public class ScriptGenerator : SimpleVisitor
{
    private readonly RootSyntax _root;

    private readonly DefinitionsGenerator _definitionGenerator;

    private readonly AngelScriptGenerator _angelScriptGenerator;

    private readonly AngelPluginGenerator _angelPluginGenerator;

    public ScriptGenerator(RootSyntax root, TextWriter scriptWriter, TextWriter pluginWriter, GenerateConfig config)
    {
        this._root = root;
        var scriptIndentedWriter = new IndentedTextWriter(scriptWriter);
        var pluginIndentedWriter = new IndentedTextWriter(pluginWriter);

        var context = new GeneratorContext([], [], config);

        this._definitionGenerator = new DefinitionsGenerator(context);
        this._angelScriptGenerator = new AngelScriptGenerator(scriptIndentedWriter, context);
        this._angelPluginGenerator = new AngelPluginGenerator(pluginIndentedWriter, context);
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
    }
}

internal record GeneratorContext(
    HashSet<FunctionDefinition> FunctionDefinitions,
    HashSet<MethodMetadata> FunctionMetadatas,
    GenerateConfig Config);