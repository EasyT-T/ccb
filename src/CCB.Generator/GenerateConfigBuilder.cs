namespace CCB.Generator;

public class GenerateConfigBuilder
{
    private string _externalAssemblyPath = string.Empty;

    private int _convType;

    private List<string> _internalClasses = [];

    private List<(string ReturnType, string DefName, (string, string)[] Parameters)> _funDefs = [];

    private List<string> _iterables = [];

    public GenerateConfigBuilder WithExternalAssembly(string externalAssemblyPath)
    {
        this._externalAssemblyPath = externalAssemblyPath;

        return this;
    }

    public GenerateConfigBuilder WithConvType(int convType)
    {
        this._convType = convType;

        return this;
    }

    public GenerateConfigBuilder AddInternalClass(string className)
    {
        this._internalClasses.Add(className);

        return this;
    }

    public GenerateConfigBuilder WithInternalClasses(IEnumerable<string> classes)
    {
        this._internalClasses = [..classes];

        return this;
    }

    public GenerateConfigBuilder AddFuncDef(string returnType, string defName, (string, string)[] parameters)
    {
        this._funDefs.Add((returnType, defName, parameters));

        return this;
    }

    public GenerateConfigBuilder WithFunDefs(IEnumerable<(string ReturnType, string DefName, (string, string)[] Parameters)> funcDefs)
    {
        this._funDefs = [..funcDefs];

        return this;
    }

    public GenerateConfigBuilder AddIterable(string className)
    {
        this._iterables.Add(className);

        return this;
    }

    public GenerateConfigBuilder WithIterables(IEnumerable<string> classes)
    {
        this._iterables = [..classes];

        return this;
    }

    public GenerateConfig Build()
    {
        return new GenerateConfig
        (
            ExternalAssemblyPath: this._externalAssemblyPath,
            ConvType: this._convType,
            InternalClasses: [.. this._internalClasses],
            FuncDefs: [.. this._funDefs],
            Iterables: [.. this._iterables]
        );
    }
}