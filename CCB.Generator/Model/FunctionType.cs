namespace CCB.Generator.Model;

using System.Collections.Immutable;

internal sealed record FunctionType(ValueType ReturnType, string Name, ImmutableArray<ParameterType> Parameters)
{
    public string Name { get; } = Name;

    public ValueType ReturnType { get; } = ReturnType;

    public ImmutableArray<ParameterType> Parameters { get; } = Parameters;
}