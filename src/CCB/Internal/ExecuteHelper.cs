namespace CCB.Internal;

public static class ExecuteHelper
{
    private record struct FunctionMetadata(ModuleHandle Handle, string DeclarationOrName);

    public static ModuleHandle ScriptHandle { get; internal set; }

    private static readonly Dictionary<FunctionMetadata, int> FunctionCache = [];

    public static int PrepareFunction(string declarationOrName, ModuleHandle handle, bool isDecl = true)
    {
        ExecuteGuard.IsOnMainThread(); // TODO Add an option to force invoke

        var metadata = new FunctionMetadata(handle, declarationOrName);

        if (!FunctionCache.TryGetValue(metadata, out var functionIndex))
        {
            functionIndex = NativeBindings.FindModuleFunction(handle, declarationOrName, isDecl);

            ExecuteGuard.IsFunctionExists(functionIndex);

            FunctionCache.Add(metadata, functionIndex);
        }

        var errCode = NativeBindings.PrepareModuleFunction(handle, functionIndex);

        ExecuteGuard.IsSuccess(errCode);

        return functionIndex;
    }

    public static int PrepareFunction(string declarationOrName, bool isDecl = true)
    {
        return PrepareFunction(declarationOrName, ScriptHandle, isDecl);
    }
}