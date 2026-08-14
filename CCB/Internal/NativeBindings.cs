namespace CCB.Internal;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal static partial class NativeBindings
{
    private const string DllName = "uemph.dll";

    [LibraryImport(DllName, EntryPoint = "_InitAngelScript@0")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void InitAngelScript();

    [LibraryImport(DllName, EntryPoint = "_LoadAngelScriptModule@12", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial IntPtr LoadAngelScriptModule(string name, string filename, int memory);

    [LibraryImport(DllName, EntryPoint = "_LoadAngelScriptModuleCompiled@8", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial IntPtr LoadAngelScriptModuleCompiled(string name, string filename);

    [LibraryImport(DllName, EntryPoint = "_RemoveAngelScriptModule@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RemoveAngelScriptModule(ModuleHandle module);

    [LibraryImport(DllName, EntryPoint = "_RegisterMessageCallback@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RegisterMessageCallback(IntPtr funcptr);

    [LibraryImport(DllName, EntryPoint = "_RegisterGlobalFunction@8", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RegisterGlobalFunction(string declaration, IntPtr funcptr);

    [LibraryImport(DllName, EntryPoint = "_RegisterLibraryFunction@12", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RegisterLibraryFunction(string declaration, IntPtr procaddress, int calltype);

    [LibraryImport(DllName, EntryPoint = "_RegisterLibraryMethod@16", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RegisterLibraryMethod(string declaration, string func, IntPtr procaddress, int calltype);

    [LibraryImport(DllName, EntryPoint = "_RegisterGlobalProperty@8", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RegisterGlobalProperty(string declaration, IntPtr pointer);

    [LibraryImport(DllName, EntryPoint = "_RegisterTypedef@8", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RegisterTypedef(string type, string declaration);

    [LibraryImport(DllName, EntryPoint = "_RegisterFuncdef@4", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RegisterFuncdef(string declaration);

    [LibraryImport(DllName, EntryPoint = "_RegisterObjectType@4", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RegisterObjectType(string declaration);

    [LibraryImport(DllName, EntryPoint = "_RegisterObjectFunction@12", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RegisterObjectFunction(string declaration, string func, IntPtr funcptr);

    [LibraryImport(DllName, EntryPoint = "_RegisterObjectProperty@12", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RegisterObjectProperty(string declaration, string func, int byteOffset);

    [LibraryImport(DllName, EntryPoint = "_GetRegisteredSize@8", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial int GetRegisteredSize(string typ, int isobject);

    [LibraryImport(DllName, EntryPoint = "_GetRegisteredObject@12", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial string GetRegisteredObject(string typ, int index, int isobject);

    [LibraryImport(DllName, EntryPoint = "_GetFunctionDeclaration@4", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial string GetFunctionDeclaration(int func);

    [LibraryImport(DllName, EntryPoint = "_GetFunctionModule@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial IntPtr GetFunctionModule(int func);

    [LibraryImport(DllName, EntryPoint = "_GetActiveContext@0")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial IntPtr GetActiveContext();

    [LibraryImport(DllName, EntryPoint = "_PrepareModuleArguments@8")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void PrepareModuleArguments(ModuleHandle module, IntPtr args);

    [LibraryImport(DllName, EntryPoint = "_CreateArguments@0")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial IntPtr CreateArguments();

    [LibraryImport(DllName, EntryPoint = "_PushArgumentsValue@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void PushArgumentsValue(IntPtr args, IntPtr ptr, int tid);

    [LibraryImport(DllName, EntryPoint = "_RemoveArguments@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RemoveArguments(IntPtr args);

    [LibraryImport(DllName, EntryPoint = "_GetArraySize@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial int GetArraySize(IntPtr hndl);

    [LibraryImport(DllName, EntryPoint = "_GetArrayValue@8")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial int GetArrayValue(IntPtr hndl, int index);

    [LibraryImport(DllName, EntryPoint = "_IsRefFunction@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial int IsRefFunction(IntPtr hndl);

    [LibraryImport(DllName, EntryPoint = "_GetRefHandle@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial IntPtr GetRefHandle(IntPtr hndl);

    [LibraryImport(DllName, EntryPoint = "_RefScriptFunction@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void RefScriptFunction(IntPtr hndl);

    [LibraryImport(DllName, EntryPoint = "_ReleaseScriptFunction@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void ReleaseScriptFunction(IntPtr hndl);

    [LibraryImport(DllName, EntryPoint = "_FindModuleFunction@12", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial int FindModuleFunction(ModuleHandle module, string declaration, [MarshalAs(UnmanagedType.Bool)] bool arguments);

    [LibraryImport(DllName, EntryPoint = "_PrepareModuleFunction@8")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial int PrepareModuleFunction(ModuleHandle module, int functionIndex);

    [LibraryImport(DllName, EntryPoint = "_ExecuteModuleFunction@8")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial int ExecuteModuleFunction(ModuleHandle module, IntPtr statePtr = 0);

    [LibraryImport(DllName, EntryPoint = "_ClearModuleState@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void ClearModuleState(ModuleHandle module);

    [LibraryImport(DllName, EntryPoint = "_GetExecutedModule@0")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial ModuleHandle GetExecutedModule();

    [LibraryImport(DllName, EntryPoint = "_GetModuleException@4", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial string GetModuleException(ModuleHandle module);

    [LibraryImport(DllName, EntryPoint = "_SaveModuleByteCode@8", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial int SaveModuleByteCode(ModuleHandle module, string file);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgByte@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgByte(ModuleHandle module, int arg, int value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgShort@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgShort(ModuleHandle module, int arg, int value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgInt@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgInt(ModuleHandle module, int arg, int value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgInt@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgUInt(ModuleHandle module, int arg, uint value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgInt@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgUInt(ModuleHandle module, int arg, out uint value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgInt@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgBoolean(ModuleHandle module, int arg, [MarshalAs(UnmanagedType.Bool)] bool value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgAddress@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgBoolean(ModuleHandle module, int arg, [MarshalAs(UnmanagedType.Bool)] out bool value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgAddress@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgInt(ModuleHandle module, int arg, out int value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgInt64@16")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgInt64(ModuleHandle module, int arg, int high, int low);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgFloat@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgFloat(ModuleHandle module, int arg, float value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgAddress@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgFloat(ModuleHandle module, int arg, out float value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgAddress@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgAddress(ModuleHandle module, int arg, IntPtr value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgObject@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgObject(ModuleHandle module, int arg, ObjectHandle value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgAddress@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgObject(ModuleHandle module, int arg, out ObjectHandle value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgString@12", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgString(ModuleHandle module, int arg, string value);

    [LibraryImport(DllName, EntryPoint = "_SetModuleArgAddress@12", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void SetModuleArgString(ModuleHandle module, int arg, out string value);

    [LibraryImport(DllName, EntryPoint = "_GetModuleReturnByte@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial byte GetModuleReturnByte(ModuleHandle module);

    [LibraryImport(DllName, EntryPoint = "_GetModuleReturnShort@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial short GetModuleReturnShort(ModuleHandle module);

    [LibraryImport(DllName, EntryPoint = "_GetModuleReturnInt@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial int GetModuleReturnInt(ModuleHandle module);

    [LibraryImport(DllName, EntryPoint = "_GetModuleReturnInt@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial uint GetModuleReturnUInt(ModuleHandle module);

    [LibraryImport(DllName, EntryPoint = "_GetModuleReturnInt@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GetModuleReturnBoolean(ModuleHandle module);

    [LibraryImport(DllName, EntryPoint = "_GetModuleReturnInt64@12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial void GetModuleReturnInt64(ModuleHandle module, out int upptr, out int lowptr);

    [LibraryImport(DllName, EntryPoint = "_GetModuleReturnFloat@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial float GetModuleReturnFloat(ModuleHandle module);

    [LibraryImport(DllName, EntryPoint = "_GetModuleReturnAddress@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial IntPtr GetModuleReturnAddress(ModuleHandle module);

    [LibraryImport(DllName, EntryPoint = "_GetModuleReturnObject@4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial ObjectHandle GetModuleReturnObject(ModuleHandle module);

    [LibraryImport(DllName, EntryPoint = "_GetModuleReturnString@4", StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    public static partial string GetModuleReturnString(ModuleHandle module);
}