namespace CCB.Generator;

public class GenerateConfigBuilder
{
    internal string ExternalAssemblyPath { get; private set; } = string.Empty;

    internal int ConvType { get; private set; }

    public GenerateConfigBuilder WithExternalAssembly(string externalAssemblyPath)
    {
        this.ExternalAssemblyPath = externalAssemblyPath;

        return this;
    }

    public GenerateConfigBuilder WithConvType(int convType)
    {
        this.ConvType = convType;

        return this;
    }
}