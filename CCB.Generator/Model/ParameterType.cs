namespace CCB.Generator.Model;

internal sealed class ParameterType(string name, string type, object? defaultValue, bool isHandle, bool isRef, bool isIn, bool isOut)
{
    public string Name { get; } = name;

    public string Type { get; } = type;

    public object? DefaultValue { get; } = defaultValue;

    public bool IsHandle { get; } = isHandle;

    public bool IsRef { get; } = isRef;

    public bool IsIn { get; } = isIn;

    public bool IsOut { get; } = isOut;
}