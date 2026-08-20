namespace CCB.Generator.Model;

using System.Collections.Immutable;

internal sealed record Tree(ImmutableArray<FunctionType> Functions, ImmutableArray<PropertyType> Properties, ImmutableArray<ClassType> Classes)
{
    public ImmutableArray<FunctionType> Functions { get; } = Functions;

    public ImmutableArray<PropertyType> Properties { get; } = Properties;

    public ImmutableArray<ClassType> Classes { get; } = Classes;
}