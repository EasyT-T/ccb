namespace CCB.Generator;

internal readonly record struct MethodMetadata(FunctionDefinition Definition, string ClassName, string MethodName, string FunctionPointer)
{
    public FunctionMetadata AsFunctionMetadata()
    {
        return new FunctionMetadata(this.Definition, this.MethodName, this.FunctionPointer);
    }
}