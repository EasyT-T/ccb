namespace CCB.Generator.Model.Bounded;

using System.Collections.Immutable;

internal sealed record BoundClassType(
    ClassType Model,
    ImmutableArray<BoundPropertyType> Properties,
    ImmutableArray<BoundFunctionType> Methods,
    BoundIteratorType? Iterator);