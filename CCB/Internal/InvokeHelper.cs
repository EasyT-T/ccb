namespace CCB.Internal;

public static class InvokeHelper
{
    private static readonly Dictionary<string, int> FunctionCache = [];

    public static int PrepareFunction(string declarationOrName, bool isDecl = true)
    {
        InvokeGuard.IsOnMainThread(); // TODO Add an option to force invoke

        if (!FunctionCache.TryGetValue(declarationOrName, out var functionIndex))
        {
            functionIndex = NativeBindings.FindModuleFunction(ScriptFunctions.ModuleHandle, declarationOrName, isDecl);

            InvokeGuard.IsFunctionExists(functionIndex);

            FunctionCache.Add(declarationOrName, functionIndex);
        }

        var errCode = NativeBindings.PrepareModuleFunction(ScriptFunctions.ModuleHandle, functionIndex);

        InvokeGuard.IsSuccess(errCode);

        return functionIndex;
    }
}