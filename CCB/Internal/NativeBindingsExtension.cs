namespace CCB.Internal;

internal static class NativeBindingsExtension
{
    extension(NativeBindings)
    {
        public static unsafe T GetModuleReturnObject<T>(ModuleHandle module, bool returnHandle) where T : IScriptObject
        {
            return returnHandle
                ? (T)T.Create(new ObjectHandle(NativeBindings.GetModuleReturnAddress(module)))
                : (T)T.Create(new ObjectHandle(*(IntPtr*)NativeBindings.GetModuleReturnAddress(module)));
        }

        public static int SetModuleArgObject<T>(ModuleHandle module, int arg, T value) where T : IScriptObject
        {
            return NativeBindings.SetModuleArgObject(module, arg, value.Handle);
        }

        public static int SetModuleArgObject<T>(ModuleHandle module, int arg, out T value) where T : IScriptObject
        {
            var result = NativeBindings.SetModuleArgObject(module, arg, out var handle);

            value = (T)T.Create(handle);

            return result;
        }
    }
}