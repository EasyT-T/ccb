namespace CCB.Generator;

public class ScriptGenerator(string scriptHeader, string outputPath, GenerateConfig config) : IDisposable
{
    private readonly TreeParser _treeParser = new TreeParser();

    private readonly AngelScriptGenerator _angelScriptGenerator =
        new AngelScriptGenerator(new IndentedTextWriter(File.CreateText(Path.Combine(outputPath, "script.as"))), config);

    private readonly CSharpScriptGenerator _csharpScriptGenerator =
        new CSharpScriptGenerator(new IndentedTextWriter(File.CreateText(Path.Combine(outputPath, "script.cs"))), config);

    public void Generate()
    {
        var scriptCompilation = new Compilation(scriptHeader);
        var scriptRoot = scriptCompilation.Parse();
        var tree = this._treeParser.Parse(scriptRoot);

        var bondTree = this._angelScriptGenerator.WriteTree(tree);
        this._csharpScriptGenerator.WriteTree(bondTree);

        foreach (var boundClassType in bondTree.Classes)
        {
            using var classGenerator =
                new CSharpClassGenerator(new IndentedTextWriter(File.CreateText(Path.Combine(outputPath, $"{boundClassType.Model.ClassName}.cs"))),
                    config);

            classGenerator.WriteClass(boundClassType);
        }
    }

    public void Dispose()
    {
        this._angelScriptGenerator.Dispose();
        this._csharpScriptGenerator.Dispose();
    }
}