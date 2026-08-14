namespace CCB.Generator;

using CCB.Syntax;
using CCB.Syntax.Visitor;

public class PluginGenerator(RootSyntax root, TextWriter writer, GenerateConfig config) : SimpleVisitor
{
    private readonly IndentedTextWriter _writer = new IndentedTextWriter(writer);

    public void Generate()
    {
        root.Accept(this);
    }

    public override void VisitRoot(RootSyntax root)
    {
        GenerateOnInitialize();

        this._writer.WriteLine();

        GenerateRegisterAllFunctions();

        return;

        void GenerateOnInitialize()
        {
            this._writer.WriteLine($"void {GeneratorFacts.OnInitializeName}()");
            this._writer.WriteLine("{");

            using (this._writer.Indent())
            {
                this._writer.WriteLine($"SetLibrary(LoadLibrary(\"{config.ExternalAssemblyPath}\"));");
                this._writer.WriteLine($"SetConvType({config.ConvType});");

                this._writer.WriteLine($"{GeneratorFacts.RegisterAllFunctionsName}();");
            }

            this._writer.WriteLine("}");
        }

        void GenerateRegisterAllFunctions()
        {
            this._writer.WriteLine($"void {GeneratorFacts.RegisterAllFunctionsName}()");
            this._writer.WriteLine("{");

            using (this._writer.Indent())
            {
                GenerateRegisterFunction(GeneratorFacts.LoadCcbDef, GeneratorFacts.LoadCcbName);
            }

            this._writer.WriteLine("}");

            return;

            void GenerateRegisterFunction(string definition, string funcName)
            {
                this._writer.WriteLine($"{GeneratorFacts.RegisterFunctionName}(\"{definition}\", \"{funcName}\");");
            }
        }
    }
}