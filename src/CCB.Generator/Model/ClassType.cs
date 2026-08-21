namespace CCB.Generator.Model;

using System.Collections.Immutable;

internal record ClassType(string ClassName, ImmutableArray<PropertyType> PropertyTypes, ImmutableArray<FunctionType> Methods)
{
    public string ClassName { get; } = ClassName;

    public ImmutableArray<PropertyType> Properties { get; } = PropertyTypes;

    public ImmutableArray<FunctionType> Methods { get; } = Methods;
}