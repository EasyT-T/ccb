namespace CCB.Generator.Model;

internal sealed class PropertyType(string? className, string name, string type)
{
    public string? ClassName { get; } = className;

    public string Name { get; } = name;

    public string Type { get; } = type;
}