namespace CCB.Internal;

public static class ExecuteHelper
{
    public static ModuleHandle ModuleHandle { get; internal set; }

    private static readonly Dictionary<string, int> FunctionCache = [];

    public static int PrepareFunction(string declarationOrName, bool isDecl = true)
    {
        ExecuteGuard.IsOnMainThread(); // TODO Add an option to force invoke

        if (!FunctionCache.TryGetValue(declarationOrName, out var functionIndex))
        {
            functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, declarationOrName, isDecl);

            ExecuteGuard.IsFunctionExists(functionIndex);

            FunctionCache.Add(declarationOrName, functionIndex);
        }

        var errCode = NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        ExecuteGuard.IsSuccess(errCode);

        return functionIndex;
    }
}