namespace CCB.Generator.Model.Bounded;

internal sealed record BoundPropertyType(PropertyType Model, BoundFunctionType Getter, BoundFunctionType? Setter);