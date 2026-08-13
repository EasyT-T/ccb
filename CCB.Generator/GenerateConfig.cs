namespace CCB.Generator;

public record GenerateConfig(
    string ExternalAssemblyPath,
    int ConvType,
    string[] InternalClasses,
    (string ReturnType, string DefName, (string, string)[] Parameters)[] FuncDefs);