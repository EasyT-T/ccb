namespace CCB.Generator.Model;

internal sealed record ParameterType(string Name, ValueType Type, object? DefaultValue)
{
    public string Name { get; } = Name;

    public ValueType Type { get; } = Type;

    public object? DefaultValue { get; } = DefaultValue;
}