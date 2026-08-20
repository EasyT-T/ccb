namespace CCB.Generator.Model;

internal sealed record PropertyType(string Name, ValueType Type, bool IsConst)
{
    public string Name { get; } = Name;

    public ValueType Type { get; } = Type;

    public bool IsConst { get; } = IsConst;
}