namespace CCB.Generator;

internal readonly struct FunctionDefinition(string returnType, string parametersText) : IEquatable<FunctionDefinition>
{
    public string ReturnType { get; } = returnType;

    public string ParametersText { get; } = parametersText;

    public bool Equals(FunctionDefinition other)
    {
        return this.ReturnType == other.ReturnType && this.ParametersText == other.ParametersText;
    }

    public override bool Equals(object? obj)
    {
        return obj is FunctionDefinition other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.ReturnType, this.ParametersText);
    }

    public static bool operator ==(FunctionDefinition left, FunctionDefinition right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(FunctionDefinition left, FunctionDefinition right)
    {
        return !left.Equals(right);
    }
}