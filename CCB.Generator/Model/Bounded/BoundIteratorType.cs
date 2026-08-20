namespace CCB.Generator.Model.Bounded;

internal sealed record BoundIteratorType(
    BoundFunctionType CreateIteratorFunction,
    BoundFunctionType IteratorGetFunction,
    BoundFunctionType IteratorAdvanceFunction,
    BoundFunctionType IteratorIsNullFunction);