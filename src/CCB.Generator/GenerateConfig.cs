namespace CCB.Generator;

using System.Collections.Immutable;

public record GenerateConfig(
    string ExternalAssemblyPath,
    int ConvType,
    ImmutableArray<string> InternalClasses,
    (string ReturnType, string DefName, (string, string)[] Parameters)[] FuncDefs,
    ImmutableArray<string> Iterables);