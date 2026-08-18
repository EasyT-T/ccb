namespace CCB.Generator.Model;

using System.Collections.Immutable;

internal sealed class FunctionType(string? className, string name, ImmutableArray<ParameterType> parameters)
{
    public string? ClassName { get; } = className;

    public string Name { get; } = name;

    public ImmutableArray<ParameterType> Parameters { get; } = parameters;
}