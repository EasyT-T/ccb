namespace CCB.Generator.Model.Bounded;

using System.Collections.Immutable;

internal sealed record BoundTree(
    Tree Model,
    BoundFunctionType OnInitializeFunction,
    ImmutableArray<BoundPropertyType> Properties,
    ImmutableArray<BoundFunctionType> Functions,
    ImmutableArray<BoundClassType> Classes);