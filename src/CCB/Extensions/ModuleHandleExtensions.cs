namespace CCB.Extensions;

using CCB.Internal;

public static class ModuleHandleExtensions
{
    extension(ModuleHandle handle)
    {
        public static ModuleHandle FromScript(string name, string path)
        {
            return NativeBindings.LoadAngelScriptModule(name, path, 0);
        }
    }
}