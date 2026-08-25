namespace CCB.Generator.Model.Bounded;

using System.Collections.Immutable;

internal sealed record BoundTree(
    Tree Model,
    ImmutableArray<BoundPropertyType> Properties,
    ImmutableArray<BoundFunctionType> Functions,
    ImmutableArray<BoundClassType> Classes);