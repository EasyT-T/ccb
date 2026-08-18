namespace CCB.Generator.Model;

using System.Collections.Immutable;

internal sealed class Tree(ImmutableArray<FunctionType> functions, ImmutableArray<PropertyType> properties)
{
    public ImmutableArray<FunctionType> Functions { get; } = functions;

    public ImmutableArray<PropertyType> Properties { get; } = properties;
}