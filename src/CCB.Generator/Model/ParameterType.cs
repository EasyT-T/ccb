namespace CCB.Generator.Model;

using CCB.Syntax;

internal sealed record ParameterType(string Name, ValueType Type, string? DefaultValue)
{
    public string Name { get; } = Name;

    public ValueType Type { get; } = Type;

    public string? DefaultValue { get; } = DefaultValue;
}