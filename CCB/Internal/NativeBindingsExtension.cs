namespace CCB.Internal;

internal static class NativeBindingsExtension
{
    extension(NativeBindings)
    {
        public static void SetModuleArgObject<T>(ModuleHandle module, int arg, T value) where T : IScriptObject
        {
            NativeBindings.SetModuleArgObject(module, arg, value.Handle);
        }

        public static void SetModuleArgObject<T>(ModuleHandle module, int arg, out T value) where T : IScriptObject
        {
            NativeBindings.SetModuleArgObject(module, arg, out var handle);

            value = (T)T.Create(handle);
        }
    }
}