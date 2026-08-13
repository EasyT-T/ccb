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


    private readonly GenerateConfigBuilder _configBuilder;

    private readonly GeneratorContext _context;

    public ScriptGenerator(RootSyntax root, TextWriter scriptWriter, TextWriter pluginWriter, GenerateConfigBuilder configBuilder)
    {
        this._root = root;
        this._scriptWriter = new IndentedTextWriter(scriptWriter);
        this._pluginWriter = new IndentedTextWriter(pluginWriter);

        this._context = new GeneratorContext([], []);

        this._classGenerator = new ClassGenerator(this._scriptWriter);
        this._funcDefGenerator =
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
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        node.Accept(this._classGenerator);
    }
}

internal record GeneratorContext(
    HashSet<FunctionDefinition> FunctionDefinitions,
    HashSet<FunctionMetadata> FunctionMetadatas,
    GenerateConfig Config);