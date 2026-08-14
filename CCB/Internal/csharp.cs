namespace CCB.Internal;

using System.Diagnostics;
using System.Runtime.InteropServices;

internal static class ScriptFunctions
{
    public static ModuleHandle ModuleHandle { get; internal set; }

    public static Entity CreatePivot(int parent)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity CreatePivot(int parent)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, parent);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
    }

    public static Entity LinePick(float x, float y, float z, float dx, float dy, float dz, float radius)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity LinePick(float x, float y, float z, float dx, float dy, float dz, float radius)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgFloat(ModuleHandle, 0, x);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 1, y);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 2, z);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 3, dx);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 4, dy);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 5, dz);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 6, radius);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
    }

    public static Player GetPlayer(int index)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Player GetPlayer(int index)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, index);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return new Player(NativeBindings.GetModuleReturnObject(ModuleHandle));
    }

    public static float PeekFloat(int bank, int offset)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float PeekFloat(int bank, int offset)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, offset);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float PickedNX()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float PickedNX()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float PickedNY()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float PickedNY()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float PickedNZ()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float PickedNZ()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float PickedX()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float PickedX()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float PickedY()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float PickedY()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float PickedZ()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float PickedZ()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float TFormedX()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float TFormedX()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float TFormedY()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float TFormedY()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float TFormedZ()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float TFormedZ()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float clamp(float val, float minimal, float maximum)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float clamp(float val, float minimal, float maximum)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgFloat(ModuleHandle, 0, val);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 1, minimal);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 2, maximum);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float frand(float from, float to)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float frand(float from, float to)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgFloat(ModuleHandle, 0, from);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 1, to);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float max(float val, float val2)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float max(float val, float val2)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgFloat(ModuleHandle, 0, val);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 1, val2);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static float min(float val, float val2)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float min(float val, float val2)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgFloat(ModuleHandle, 0, val);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 1, val2);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnFloat(ModuleHandle);
    }

    public static int BankSize(int bank)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int BankSize(int bank)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int BankStringSize(in string unnamed0)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int BankStringSize(string& in )", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgString(ModuleHandle, 0, unnamed0);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int CreateBank(int size)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int CreateBank(int size)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, size);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int CreateTimer(nint callback, int time, bool repeat, int timerdata)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int CreateTimer(ref& in callback, int time, bool repeat, int timerdata)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgAddress(ModuleHandle, 0, callback);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, time);
        NativeBindings.SetModuleArgBoolean(ModuleHandle, 2, repeat);
        NativeBindings.SetModuleArgInt(ModuleHandle, 3, timerdata);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int CreateTimer(in string funcdecl, int time, bool repeat, int timerdata)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int CreateTimer(string& in funcdecl, int time, bool repeat, int timerdata)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgString(ModuleHandle, 0, funcdecl);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, time);
        NativeBindings.SetModuleArgBoolean(ModuleHandle, 2, repeat);
        NativeBindings.SetModuleArgInt(ModuleHandle, 3, timerdata);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int CreateTimerData()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int CreateTimerData()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int CreateTimerEx(nint callback, int time, bool repeat, nint unnamed3, nint unnamed4, nint unnamed5, nint unnamed6, nint unnamed7, nint unnamed8, nint unnamed9, nint unnamed10)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int CreateTimerEx(ref& in callback, int time, bool repeat, ?& in , ?& in , ?& in , ?& in , ?& in , ?& in , ?& in , ?& in )", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgAddress(ModuleHandle, 0, callback);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, time);
        NativeBindings.SetModuleArgBoolean(ModuleHandle, 2, repeat);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 3, unnamed3);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 4, unnamed4);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 5, unnamed5);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 6, unnamed6);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 7, unnamed7);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 8, unnamed8);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 9, unnamed9);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 10, unnamed10);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int CreateTimerEx(in string funcdecl, int time, bool repeat, nint unnamed3, nint unnamed4, nint unnamed5, nint unnamed6, nint unnamed7, nint unnamed8, nint unnamed9, nint unnamed10)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int CreateTimerEx(string& in funcdecl, int time, bool repeat, ?& in , ?& in , ?& in , ?& in , ?& in , ?& in , ?& in , ?& in )", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgString(ModuleHandle, 0, funcdecl);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, time);
        NativeBindings.SetModuleArgBoolean(ModuleHandle, 2, repeat);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 3, unnamed3);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 4, unnamed4);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 5, unnamed5);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 6, unnamed6);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 7, unnamed7);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 8, unnamed8);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 9, unnamed9);
        NativeBindings.SetModuleArgAddress(ModuleHandle, 10, unnamed10);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int GetActiveContext()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int GetActiveContext()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int GetPlayersCount()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int GetPlayersCount()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int GetProcAddress(int unnamed0, in string unnamed1)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int GetProcAddress(int , string& in )", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, unnamed0);
        NativeBindings.SetModuleArgString(ModuleHandle, 1, unnamed1);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int LoadLibrary(in string unnamed0)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int LoadLibrary(string& in )", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgString(ModuleHandle, 0, unnamed0);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int PeekInt(int bank, int offset)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int PeekInt(int bank, int offset)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, offset);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int rand(int from, int to)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int rand(int from, int to)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, from);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, to);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int rndseed()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int rndseed()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int round(bool val)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int round(bool val)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgBoolean(ModuleHandle, 0, val);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int round(float val)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int round(float val)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgFloat(ModuleHandle, 0, val);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static int srand(int val)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int srand(int val)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, val);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnInt(ModuleHandle);
    }

    public static short PeekShort(int bank, int offset)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int16 PeekShort(int bank, int offset)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, offset);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnShort(ModuleHandle);
    }

    public static byte PeekByte(int bank, int offset)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int8 PeekByte(int bank, int offset)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, offset);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnByte(ModuleHandle);
    }

    public static string PeekString(int bank, int offset)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& PeekString(int bank, int offset)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, offset);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnString(ModuleHandle);
    }

    public static string StripFormatting(in string txt)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& StripFormatting(string& in txt)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgString(ModuleHandle, 0, txt);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);

        return NativeBindings.GetModuleReturnString(ModuleHandle);
    }

    public static void Collisions(int src_type, int dest_type, int method, int response)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void Collisions(int src_type, int dest_type, int method, int response)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, src_type);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, dest_type);
        NativeBindings.SetModuleArgInt(ModuleHandle, 2, method);
        NativeBindings.SetModuleArgInt(ModuleHandle, 3, response);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void FreeBank(int bank)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void FreeBank(int bank)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void PokeByte(int bank, int offset, int value)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void PokeByte(int bank, int offset, int value)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, offset);
        NativeBindings.SetModuleArgInt(ModuleHandle, 2, value);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void PokeFloat(int bank, int offset, float value)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void PokeFloat(int bank, int offset, float value)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, offset);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 2, value);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void PokeInt(int bank, int offset, int value)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void PokeInt(int bank, int offset, int value)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, offset);
        NativeBindings.SetModuleArgInt(ModuleHandle, 2, value);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void PokeShort(int bank, int offset, int value)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void PokeShort(int bank, int offset, int value)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, offset);
        NativeBindings.SetModuleArgInt(ModuleHandle, 2, value);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void PokeString(int bank, int offset, in string value)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void PokeString(int bank, int offset, string& in value)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, bank);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, offset);
        NativeBindings.SetModuleArgString(ModuleHandle, 2, value);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void RegisterFuncdef(in string declaration)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void RegisterFuncdef(string& in declaration)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgString(ModuleHandle, 0, declaration);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void RegisterLibraryFunction(in string decl, int procaddress, int convtype)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void RegisterLibraryFunction(string& in decl, int procaddress, int convtype)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgString(ModuleHandle, 0, decl);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, procaddress);
        NativeBindings.SetModuleArgInt(ModuleHandle, 2, convtype);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void RegisterLibraryMethod(in string classname, in string decl, int procaddress, int convtype)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void RegisterLibraryMethod(string& in classname, string& in decl, int procaddress, int convtype)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgString(ModuleHandle, 0, classname);
        NativeBindings.SetModuleArgString(ModuleHandle, 1, decl);
        NativeBindings.SetModuleArgInt(ModuleHandle, 2, procaddress);
        NativeBindings.SetModuleArgInt(ModuleHandle, 3, convtype);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void RegisterLibraryObject(in string classname)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void RegisterLibraryObject(string& in classname)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgString(ModuleHandle, 0, classname);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void RemoveTimer()
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void RemoveTimer()", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);


        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void RemoveTimer(int timer)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void RemoveTimer(int timer)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, timer);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void RemoveTimer(nint callback)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void RemoveTimer(ref& in callback)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgAddress(ModuleHandle, 0, callback);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void SetTimerBool(int timerdata, bool val)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void SetTimerBool(int timerdata, bool val)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, timerdata);
        NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, val);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void SetTimerFloat(int timerdata, float val)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void SetTimerFloat(int timerdata, float val)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, timerdata);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 1, val);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void SetTimerHandle(int timerdata, int handle)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void SetTimerHandle(int timerdata, int handle)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, timerdata);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, handle);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void SetTimerInt(int timerdata, int val)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void SetTimerInt(int timerdata, int val)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, timerdata);
        NativeBindings.SetModuleArgInt(ModuleHandle, 1, val);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void SetTimerString(int timerdata, in string val)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void SetTimerString(int timerdata, string& in val)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, timerdata);
        NativeBindings.SetModuleArgString(ModuleHandle, 1, val);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void TFormNormal(float x, float y, float z, Entity src, Entity dest)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void TFormNormal(float x, float y, float z, Entity src, Entity dest)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgFloat(ModuleHandle, 0, x);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 1, y);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 2, z);
        NativeBindings.SetModuleArgObject(ModuleHandle, 3, src);
        NativeBindings.SetModuleArgObject(ModuleHandle, 4, dest);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void TFormPoint(float x, float y, float z, Entity src, Entity dest)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void TFormPoint(float x, float y, float z, Entity src, Entity dest)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgFloat(ModuleHandle, 0, x);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 1, y);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 2, z);
        NativeBindings.SetModuleArgObject(ModuleHandle, 3, src);
        NativeBindings.SetModuleArgObject(ModuleHandle, 4, dest);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void TFormVector(float x, float y, float z, Entity src, Entity dest)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void TFormVector(float x, float y, float z, Entity src, Entity dest)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgFloat(ModuleHandle, 0, x);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 1, y);
        NativeBindings.SetModuleArgFloat(ModuleHandle, 2, z);
        NativeBindings.SetModuleArgObject(ModuleHandle, 3, src);
        NativeBindings.SetModuleArgObject(ModuleHandle, 4, dest);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void print(in string message)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void print(string& in message)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgString(ModuleHandle, 0, message);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    public static void sleep(int milliseconds)
    {
        var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void sleep(int milliseconds)", true);

        Debug.Assert(functionIndex >= 0);

        NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

        NativeBindings.SetModuleArgInt(ModuleHandle, 0, milliseconds);

        NativeBindings.ExecuteModuleFunction(ModuleHandle);
    }

    internal static class AsAudio
    {
        public static Sound Play3DSound(Audio @this, in string filenameorurl, Player player, float range, float volume, bool norange)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Sound ccb::_Audio::Play3DSound(Audio _this, string& in filenameorurl, Player player, float range, float volume, bool norange)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, filenameorurl);
            NativeBindings.SetModuleArgObject(ModuleHandle, 2, player);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, range);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, volume);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 5, norange);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Sound(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Sound Play3DSound(Audio @this, in string filenameorurl, Entity entity, float range, float volume, bool norange)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Sound ccb::_Audio::Play3DSound(Audio _this, string& in filenameorurl, Entity entity, float range, float volume, bool norange)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, filenameorurl);
            NativeBindings.SetModuleArgObject(ModuleHandle, 2, entity);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, range);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, volume);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 5, norange);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Sound(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Sound Play3DSound(Audio @this, in string filenameorurl, float x, float y, float z, float range, float volume, bool norange)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Sound ccb::_Audio::Play3DSound(Audio _this, string& in filenameorurl, float x, float y, float z, float range, float volume, bool norange)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, filenameorurl);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, z);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, range);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 6, volume);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 7, norange);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Sound(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Sound PlaySound(Audio @this, in string filenameorurl)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Sound ccb::_Audio::PlaySound(Audio _this, string& in filenameorurl)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, filenameorurl);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Sound(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Sound PlaySoundForPlayer(Audio @this, Player player, in string filenameorurl)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Sound ccb::_Audio::PlaySoundForPlayer(Audio _this, Player player, string& in filenameorurl)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgString(ModuleHandle, 2, filenameorurl);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Sound(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Sound Play3DSoundForPlayer(Audio @this, Player player, in string filenameorurl, Entity entity, float range, float volume, bool norange)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Sound ccb::_Audio::Play3DSoundForPlayer(Audio _this, Player player, string& in filenameorurl, Entity entity, float range, float volume, bool norange)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgString(ModuleHandle, 2, filenameorurl);
            NativeBindings.SetModuleArgObject(ModuleHandle, 3, entity);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, range);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, volume);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 6, norange);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Sound(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Sound Play3DSoundForPlayer(Audio @this, Player player, in string filenameorurl, float x, float y, float z, float range, float volume, bool norange)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Sound ccb::_Audio::Play3DSoundForPlayer(Audio _this, Player player, string& in filenameorurl, float x, float y, float z, float range, float volume, bool norange)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgString(ModuleHandle, 2, filenameorurl);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, z);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 6, range);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 7, volume);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 8, norange);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Sound(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Sound Play3DSoundForPlayer(Audio @this, Player player_to, in string filenameorurl, Player player, float range, float volume, bool norange)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Sound ccb::_Audio::Play3DSoundForPlayer(Audio _this, Player player_to, string& in filenameorurl, Player player, float range, float volume, bool norange)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player_to);
            NativeBindings.SetModuleArgString(ModuleHandle, 2, filenameorurl);
            NativeBindings.SetModuleArgObject(ModuleHandle, 3, player);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, range);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, volume);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 6, norange);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Sound(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }
    }

    internal static class AsChat
    {
        public static void Send(Chat @this, in string message)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Chat::Send(Chat _this, string& in message)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, message);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SendPlayer(Chat @this, Player player, in string message)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Chat::SendPlayer(Chat _this, Player player, string& in message)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgString(ModuleHandle, 2, message);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsConfig
    {
        public static bool Exist(Config @this, in string key, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Config::Exist(Config _this, string& in key, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, key);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static string Get(Config @this, in string key, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Config::Get(Config _this, string& in key, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, key);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static void Remove(Config @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Config::Remove(Config _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsConnection
    {
        public static int GetPort(Connection @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Connection::GetPort(Connection _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static string GetName(Connection @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Connection::GetName(Connection _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetLanguage(Connection @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Connection::GetLanguage(Connection _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetHWID(Connection @this, int wmid)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Connection::GetHWID(Connection _this, int wmid)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, wmid);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetIP(Connection @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Connection::GetIP(Connection _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetSteamID(Connection @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Connection::GetSteamID(Connection _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static int GetQueue(Connection @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Connection::GetQueue(Connection _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static bool Join(Connection @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Connection::Join(Connection _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void Accept(Connection @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Connection::Accept(Connection _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Cancel(Connection @this, int code)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Connection::Cancel(Connection _this, int code)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, code);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Cancel(Connection @this, in string custom)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Connection::Cancel(Connection _this, string& in custom)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, custom);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Remove(Connection @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Connection::Remove(Connection _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsCorpse
    {
        public static int GetIndex(Corpse @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Corpse::GetIndex(Corpse _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static Player GetPlayer(Corpse @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Player ccb::_Corpse::GetPlayer(Corpse _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Player(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Entity GetEntity(Corpse @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Corpse::GetEntity(Corpse _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static float GetTimeout(Corpse @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Corpse::GetTimeout(Corpse _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void SetTimeout(Corpse @this, float unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Corpse::SetTimeout(Corpse _this, float )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool PushItem(Corpse @this, Items unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Corpse::PushItem(Corpse _this, Items )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static bool ExploreItem(Corpse @this, int slot)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Corpse::ExploreItem(Corpse _this, int slot)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, slot);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static Items GetItem(Corpse @this, int slot)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Items ccb::_Corpse::GetItem(Corpse _this, int slot)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, slot);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Items(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int GetModel(Corpse @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Corpse::GetModel(Corpse _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static int GetItemsCount(Corpse @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Corpse::GetItemsCount(Corpse _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static bool IsExplored(Corpse @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Corpse::IsExplored(Corpse _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetExplore(Corpse @this, bool explore)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Corpse::SetExplore(Corpse _this, bool explore)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, explore);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool Explore(Corpse @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Corpse::Explore(Corpse _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetData(Corpse @this, in string data)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Corpse::SetData(Corpse _this, string& in data)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, data);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static string GetData(Corpse @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Corpse::GetData(Corpse _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static void Remove(Corpse @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Corpse::Remove(Corpse _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsDoor
    {
        public static void Use(Door @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Door::Use(Door _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetOpen(Door @this, bool unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Door::SetOpen(Door _this, bool )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool IsOpened(Door @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Door::IsOpened(Door _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static bool IsBreak(Door @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Door::IsBreak(Door _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetLockState(Door @this, int unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Door::SetLockState(Door _this, int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static int GetLockState(Door @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Door::GetLockState(Door _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static float GetOpenState(Door @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Door::GetOpenState(Door _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static bool BreakDoor(Door @this, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Door::BreakDoor(Door _this, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void Decompose(Door @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Door::Decompose(Door _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static int GetDoorAccess(Door @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Door::GetDoorAccess(Door _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static int GetDoorType(Door @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Door::GetDoorType(Door _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static void SetKeycard(Door @this, int unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Door::SetKeycard(Door _this, int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static int GetKeycard(Door @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Door::GetKeycard(Door _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static Entity GetEntity(Door @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Door::GetEntity(Door _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Entity GetButton(Door @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Door::GetButton(Door _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int GetIndex(Door @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Door::GetIndex(Door _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }
    }

    internal static class AsEntity
    {
        public static void SetPosition(Entity @this, float x, float y, float z, bool global)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetPosition(Entity _this, float x, float y, float z, bool global)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 4, global);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetRotation(Entity @this, float pitch, float yaw, float roll, bool global)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetRotation(Entity _this, float pitch, float yaw, float roll, bool global)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, pitch);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, yaw);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, roll);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 4, global);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetScale(Entity @this, float x, float y, float z, bool global)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetScale(Entity _this, float x, float y, float z, bool global)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 4, global);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float PositionX(Entity @this, bool global, float tween)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::PositionX(Entity _this, bool global, float tween)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, global);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, tween);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float PositionY(Entity @this, bool global, float tween)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::PositionY(Entity _this, bool global, float tween)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, global);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, tween);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float PositionZ(Entity @this, bool global, float tween)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::PositionZ(Entity _this, bool global, float tween)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, global);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, tween);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void Translate(Entity @this, float x, float y, float z, bool global)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::Translate(Entity _this, float x, float y, float z, bool global)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 4, global);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Move(Entity @this, float x, float y, float z, bool global)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::Move(Entity _this, float x, float y, float z, bool global)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 4, global);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float Pitch(Entity @this, bool global, float tween)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::Pitch(Entity _this, bool global, float tween)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, global);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, tween);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float Yaw(Entity @this, bool global, float tween)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::Yaw(Entity _this, bool global, float tween)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, global);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, tween);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float Roll(Entity @this, bool global, float tween)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::Roll(Entity _this, bool global, float tween)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, global);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, tween);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float Turn(Entity @this, float pitch, float yaw, float roll, bool global)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::Turn(Entity _this, float pitch, float yaw, float roll, bool global)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, pitch);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, yaw);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, roll);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 4, global);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float ScaleX(Entity @this, bool global, float tween)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::ScaleX(Entity _this, bool global, float tween)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, global);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, tween);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float ScaleY(Entity @this, bool global, float tween)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::ScaleY(Entity _this, bool global, float tween)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, global);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, tween);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float ScaleZ(Entity @this, bool global, float tween)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::ScaleZ(Entity _this, bool global, float tween)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, global);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, tween);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void SetAnimTime(Entity @this, float time, int sequence)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetAnimTime(Entity _this, float time, int sequence)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, time);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, sequence);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float GetAnimTime(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::GetAnimTime(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float Point(Entity @this, Entity target, float roll)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::Point(Entity _this, Entity target, float roll)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, target);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, roll);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static Entity Pick(Entity @this, float distance)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Entity::Pick(Entity _this, float distance)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, distance);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static void SetPickMode(Entity @this, int pickmode, bool obscurer)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetPickMode(Entity _this, int pickmode, bool obscurer)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, pickmode);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 2, obscurer);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool Visible(Entity @this, Entity target, float radius)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Entity::Visible(Entity _this, Entity target, float radius)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, target);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, radius);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static float Distance(Entity @this, Entity target)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::Distance(Entity _this, Entity target)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, target);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float DistanceSquared(Entity @this, Entity target)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::DistanceSquared(Entity _this, Entity target)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, target);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void SetParent(Entity @this, Entity target, bool retain)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetParent(Entity _this, Entity target, bool retain)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, target);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 2, retain);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static Entity GetParent(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Entity::GetParent(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int CountChildren(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Entity::CountChildren(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static Entity GetChild(Entity @this, int unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Entity::GetChild(Entity _this, int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static string GetName(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Entity::GetName(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static void SetName(Entity @this, in string name)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetName(Entity _this, string& in name)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, name);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool Collided(Entity @this, int colltype)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Entity::Collided(Entity _this, int colltype)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, colltype);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static int CountCollisions(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Entity::CountCollisions(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static float CollisionX(Entity @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::CollisionX(Entity _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float CollisionY(Entity @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::CollisionY(Entity _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float CollisionZ(Entity @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::CollisionZ(Entity _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float CollisionNX(Entity @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::CollisionNX(Entity _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float CollisionNY(Entity @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::CollisionNY(Entity _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float CollisionNZ(Entity @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::CollisionNZ(Entity _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float CollisionImpulse(Entity @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::CollisionImpulse(Entity _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float CollisionDistance(Entity @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::CollisionDistance(Entity _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float CollisionTime(Entity @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Entity::CollisionTime(Entity _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static Entity CollisionEntity(Entity @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Entity::CollisionEntity(Entity _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int CollisionTriangle(Entity @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Entity::CollisionTriangle(Entity _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static void SetType(Entity @this, int colltype, bool recursive)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetType(Entity _this, int colltype, bool recursive)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, colltype);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 2, recursive);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetRadius(Entity @this, float x, float y)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetRadius(Entity _this, float x, float y)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetCylinder(Entity @this, float x_radius, float y_radius)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetCylinder(Entity _this, float x_radius, float y_radius)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x_radius);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y_radius);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetBox(Entity @this, float x, float y, float z, float w, float h, float d)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetBox(Entity _this, float x, float y, float z, float w, float h, float d)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, w);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, h);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 6, d);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static int GetType(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Entity::GetType(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static int GetShape(Entity @this, out float x, out float y, out float z, out float width, out float height, out float depth)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Entity::GetShape(Entity _this, float& out x, float& out y, float& out z, float& out width, float& out height, float& out depth)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, out x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, out z);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, out width);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, out height);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 6, out depth);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static void Reset(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::Reset(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool InView(Entity @this, Entity target)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Entity::InView(Entity _this, Entity target)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, target);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void Show(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::Show(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Hide(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::Hide(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Remove(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::Remove(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetMass(Entity @this, float mass)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetMass(Entity _this, float mass)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, mass);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetPhysics(Entity @this, bool enable)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetPhysics(Entity _this, bool enable)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, enable);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetKinematic(Entity @this, bool enable)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetKinematic(Entity _this, bool enable)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, enable);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetCenter(Entity @this, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetCenter(Entity _this, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetLinearCast(Entity @this, bool enable)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetLinearCast(Entity _this, bool enable)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, enable);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetFriction(Entity @this, float friction)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetFriction(Entity _this, float friction)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, friction);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetRollFriction(Entity @this, float friction)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetRollFriction(Entity _this, float friction)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, friction);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetRestitution(Entity @this, float res)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetRestitution(Entity _this, float res)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, res);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetGravity(Entity @this, float factor)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetGravity(Entity _this, float factor)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, factor);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetLinearFactor(Entity @this, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetLinearFactor(Entity _this, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetAngularFactor(Entity @this, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetAngularFactor(Entity _this, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetLinearDamping(Entity @this, float damping)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetLinearDamping(Entity _this, float damping)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, damping);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetAngularDamping(Entity @this, float damping)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetAngularDamping(Entity _this, float damping)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, damping);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetConstraint(Entity @this, float normalAngle, float planeAngle, float twistMinAngle, float twistMaxAngle, float torqueFriction)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetConstraint(Entity _this, float normalAngle, float planeAngle, float twistMinAngle, float twistMaxAngle, float torqueFriction)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, normalAngle);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, planeAngle);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, twistMinAngle);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, twistMaxAngle);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, torqueFriction);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Activate(Entity @this, bool enable)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::Activate(Entity _this, bool enable)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, enable);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Sleep(Entity @this, bool enable)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::Sleep(Entity _this, bool enable)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, enable);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Freeze(Entity @this, bool enable)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::Freeze(Entity _this, bool enable)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, enable);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool IsFreezed(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Entity::IsFreezed(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static bool IsActive(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Entity::IsActive(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetLinearVelocity(Entity @this, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetLinearVelocity(Entity _this, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetAngularVelocity(Entity @this, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::SetAngularVelocity(Entity _this, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void GetLinearVelocity(Entity @this, out float x, out float y, out float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::GetLinearVelocity(Entity _this, float& out x, float& out y, float& out z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, out x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, out z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void GetAngularVelocity(Entity @this, out float x, out float y, out float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::GetAngularVelocity(Entity _this, float& out x, float& out y, float& out z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, out x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, out z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Impulse(Entity @this, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::Impulse(Entity _this, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Torque(Entity @this, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::Torque(Entity _this, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void ClearForces(Entity @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Entity::ClearForces(Entity _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsEvent
    {
        public static Room GetRoom(Event @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Room ccb::_Event::GetRoom(Event _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Room(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int GetIndex(Event @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Event::GetIndex(Event _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static int GetIdentifier(Event @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Event::GetIdentifier(Event _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static float GetState(Event @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Event::GetState(Event _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetState2(Event @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Event::GetState2(Event _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetState3(Event @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Event::GetState3(Event _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetState4(Event @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Event::GetState4(Event _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float SetState(Event @this, float state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Event::SetState(Event _this, float state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float SetState2(Event @this, float state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Event::SetState2(Event _this, float state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float SetState3(Event @this, float state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Event::SetState3(Event _this, float state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float SetState4(Event @this, float state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Event::SetState4(Event _this, float state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void Remove(Event @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Event::Remove(Event _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsGUIElement
    {
        public static void GetPosition(GUIElement @this, out float x, out float y)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::GetPosition(GUIElement _this, float& out x, float& out y)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, out x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out y);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetPosition(GUIElement @this, float x, float y)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetPosition(GUIElement _this, float x, float y)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetScale(GUIElement @this, float width, float height)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetScale(GUIElement _this, float width, float height)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, width);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, height);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void GetScale(GUIElement @this, out float width, out float height)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::GetScale(GUIElement _this, float& out width, float& out height)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, out width);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out height);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetRotation(GUIElement @this, int degrees)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetRotation(GUIElement _this, int degrees)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, degrees);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void GetRotation(GUIElement @this, out int degrees)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::GetRotation(GUIElement _this, int& out degrees)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, out degrees);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetData(GUIElement @this, in string data)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetData(GUIElement _this, string& in data)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, data);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetText(GUIElement @this, in string text)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetText(GUIElement _this, string& in text)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, text);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetFont(GUIElement @this, int fontid)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetFont(GUIElement _this, int fontid)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, fontid);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetSelectable(GUIElement @this, bool selectable)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetSelectable(GUIElement _this, bool selectable)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, selectable);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetShadow(GUIElement @this, bool shadowed)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetShadow(GUIElement _this, bool shadowed)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, shadowed);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetAspect(GUIElement @this, bool keep)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetAspect(GUIElement _this, bool keep)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, keep);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetOpacity(GUIElement @this, float target, float lerp)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetOpacity(GUIElement _this, float target, float lerp)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, target);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, lerp);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetColor(GUIElement @this, int r, int g, int b)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetColor(GUIElement _this, int r, int g, int b)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, r);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, g);
            NativeBindings.SetModuleArgInt(ModuleHandle, 3, b);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetTechnique(GUIElement @this, in string technique)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetTechnique(GUIElement _this, string& in technique)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, technique);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static Player GetPlayer(GUIElement @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Player ccb::_GUIElement::GetPlayer(GUIElement _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Player(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static void SetAttach(GUIElement @this, Player player)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetAttach(GUIElement _this, Player player)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetAttach(GUIElement @this, bool enable, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetAttach(GUIElement _this, bool enable, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, enable);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static Player GetAttach(GUIElement @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Player ccb::_GUIElement::GetAttach(GUIElement _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Player(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static bool GetAttach(GUIElement @this, out float x, out float y, out float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_GUIElement::GetAttach(GUIElement _this, float& out x, float& out y, float& out z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, out x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, out z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static int GetFont(GUIElement @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_GUIElement::GetFont(GUIElement _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static string GetText(GUIElement @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_GUIElement::GetText(GUIElement _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetData(GUIElement @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_GUIElement::GetData(GUIElement _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static bool IsSelectable(GUIElement @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_GUIElement::IsSelectable(GUIElement _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static bool IsHidden(GUIElement @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_GUIElement::IsHidden(GUIElement _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetCallback(GUIElement @this, in string funcname)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::SetCallback(GUIElement _this, string& in funcname)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, funcname);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }


        public static void Hide(GUIElement @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::Hide(GUIElement _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Show(GUIElement @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::Show(GUIElement _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Remove(GUIElement @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_GUIElement::Remove(GUIElement _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsGraphics
    {
        public static GUIElement CreateOval(Graphics @this, Player player, float x, float y, float width, float height, bool align)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "GUIElement ccb::_Graphics::CreateOval(Graphics _this, Player player, float x, float y, float width, float height, bool align)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, width);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, height);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 6, align);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new GUIElement(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static GUIElement CreateRect(Graphics @this, Player player, float x, float y, float width, float height, bool align)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "GUIElement ccb::_Graphics::CreateRect(Graphics _this, Player player, float x, float y, float width, float height, bool align)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, width);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, height);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 6, align);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new GUIElement(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static GUIElement CreateProgressBar(Graphics @this, Player player, float time, float x, float y, float width, float height, bool align)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "GUIElement ccb::_Graphics::CreateProgressBar(Graphics _this, Player player, float time, float x, float y, float width, float height, bool align)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, time);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, width);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 6, height);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 7, align);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new GUIElement(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static GUIElement CreateProgressBar(Graphics @this, Player player, float time, float x, float y, float width, float height, bool align, in string callback)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "GUIElement ccb::_Graphics::CreateProgressBar(Graphics _this, Player player, float time, float x, float y, float width, float height, bool align, string& in callback)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, time);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, width);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 6, height);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 7, align);
            NativeBindings.SetModuleArgString(ModuleHandle, 8, callback);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new GUIElement(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static GUIElement CreateProgressBar(Graphics @this, Player player, float time, float x, float y, float width, float height, bool align, nint callback)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "GUIElement ccb::_Graphics::CreateProgressBar(Graphics _this, Player player, float time, float x, float y, float width, float height, bool align, ref& in callback)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, time);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, width);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 6, height);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 7, align);
            NativeBindings.SetModuleArgAddress(ModuleHandle, 8, callback);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new GUIElement(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static GUIElement CreateText(Graphics @this, Player player, int fontid, in string text, float x, float y, bool align)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "GUIElement ccb::_Graphics::CreateText(Graphics _this, Player player, int fontid, string& in text, float x, float y, bool align)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, fontid);
            NativeBindings.SetModuleArgString(ModuleHandle, 3, text);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, y);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 6, align);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new GUIElement(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static GUIElement CreateImage(Graphics @this, Player player, in string filename, float x, float y, float width, float height, bool align)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "GUIElement ccb::_Graphics::CreateImage(Graphics _this, Player player, string& in filename, float x, float y, float width, float height, bool align)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgString(ModuleHandle, 2, filename);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, width);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 6, height);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 7, align);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new GUIElement(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static GUIElement CreatePostEffect(Graphics @this, Player player, in string filename, in string defines)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "GUIElement ccb::_Graphics::CreatePostEffect(Graphics _this, Player player, string& in filename, string& in defines)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgString(ModuleHandle, 2, filename);
            NativeBindings.SetModuleArgString(ModuleHandle, 3, defines);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new GUIElement(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }
    }

    internal static class AsItems
    {
        public static bool IsPicked(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Items::IsPicked(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static Player GetPicker(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Player ccb::_Items::GetPicker(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Player(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static bool SetPicker(Items @this, Player player, float throwforce)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Items::SetPicker(Items _this, Player player, float throwforce)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, throwforce);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static Entity GetEntity(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Items::GetEntity(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int GetIndex(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Items::GetIndex(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static string GetName(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Items::GetName(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetTemplateName(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Items::GetTemplateName(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static int GetTemplateIndex(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Items::GetTemplateIndex(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static bool IsWeapon(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Items::IsWeapon(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetState(Items @this, float state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Items::SetState(Items _this, float state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetState2(Items @this, float state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Items::SetState2(Items _this, float state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetState3(Items @this, float state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Items::SetState3(Items _this, float state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float GetState(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Items::GetState(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetState2(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Items::GetState2(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetState3(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Items::GetState3(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static Items Fine(Items @this, int unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Items ccb::_Items::Fine(Items _this, int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Items(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int GetSlots(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Items::GetSlots(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static Items GetParentItem(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Items ccb::_Items::GetParentItem(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Items(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Items GetSlotItem(Items @this, int unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Items ccb::_Items::GetSlotItem(Items _this, int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Items(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static bool PushItem(Items @this, Items unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Items::PushItem(Items _this, Items )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static bool RemoveSlotItem(Items @this, int unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Items::RemoveSlotItem(Items _this, int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void Remove(Items @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Items::Remove(Items _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsLight
    {
        public static int GetIndex(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Light::GetIndex(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static void SetFOV(Light @this, float fov)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::SetFOV(Light _this, float fov)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, fov);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetRange(Light @this, float range)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::SetRange(Light _this, float range)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, range);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetScattering(Light @this, float scattering)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::SetScattering(Light _this, float scattering)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, scattering);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetColor(Light @this, int r, int g, int b)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::SetColor(Light _this, int r, int g, int b)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, r);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, g);
            NativeBindings.SetModuleArgInt(ModuleHandle, 3, b);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetCastShadows(Light @this, bool shadows)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::SetCastShadows(Light _this, bool shadows)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, shadows);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetIntensity(Light @this, float intensity)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::SetIntensity(Light _this, float intensity)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, intensity);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetLength(Light @this, float length)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::SetLength(Light _this, float length)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, length);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float GetFOV(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Light::GetFOV(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetRange(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Light::GetRange(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetScattering(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Light::GetScattering(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void GetColor(Light @this, out int r, out int g, out int b)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::GetColor(Light _this, int& out r, int& out g, int& out b)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, out r);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, out g);
            NativeBindings.SetModuleArgInt(ModuleHandle, 3, out b);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool GetCastShadows(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Light::GetCastShadows(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static float GetIntensity(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Light::GetIntensity(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetLength(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Light::GetLength(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void SetAttach(Light @this, Player player)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::SetAttach(Light _this, Player player)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static Player GetAttach(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Player ccb::_Light::GetAttach(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Player(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static void SetRoom(Light @this, Room unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::SetRoom(Light _this, Room )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static Room GetRoom(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Room ccb::_Light::GetRoom(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Room(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Entity GetEntity(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Light::GetEntity(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Entity GetLight(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Light::GetLight(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static void SetMovement(Light @this, float speed, float maxdistance)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::SetMovement(Light _this, float speed, float maxdistance)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, speed);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, maxdistance);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Remove(Light @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Light::Remove(Light _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsModelPreset
    {















































    }

    internal static class AsNPC
    {
        public static Entity GetEntity(NPC @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_NPC::GetEntity(NPC _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Entity GetModel(NPC @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_NPC::GetModel(NPC _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static void SetPickable(NPC @this, bool pickable)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_NPC::SetPickable(NPC _this, bool pickable)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, pickable);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetDead(NPC @this, bool state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_NPC::SetDead(NPC _this, bool state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool IsDead(NPC @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_NPC::IsDead(NPC _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetHealth(NPC @this, int health)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_NPC::SetHealth(NPC _this, int health)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, health);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static int GetHealth(NPC @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_NPC::GetHealth(NPC _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static void SetIdle(NPC @this, float state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_NPC::SetIdle(NPC _this, float state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetState1(NPC @this, float state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_NPC::SetState1(NPC _this, float state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetState2(NPC @this, float state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_NPC::SetState2(NPC _this, float state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetState3(NPC @this, float state)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_NPC::SetState3(NPC _this, float state)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, state);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float GetIdle(NPC @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_NPC::GetIdle(NPC _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetState1(NPC @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_NPC::GetState1(NPC _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetState2(NPC @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_NPC::GetState2(NPC _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetState3(NPC @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_NPC::GetState3(NPC _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void Remove(NPC @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_NPC::Remove(NPC _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsObject
    {
        public static void SetAttach(Object @this, Player player)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Object::SetAttach(Object _this, Player player)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static Player GetAttach(Object @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Player ccb::_Object::GetAttach(Object _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Player(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static void SetRoom(Object @this, Room unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Object::SetRoom(Object _this, Room )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static Room GetRoom(Object @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Room ccb::_Object::GetRoom(Object _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Room(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int GetIndex(Object @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Object::GetIndex(Object _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static Entity GetEntity(Object @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Object::GetEntity(Object _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Entity GetModel(Object @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Object::GetModel(Object _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static void SetMovement(Object @this, float speed, float maxdistance)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Object::SetMovement(Object _this, float speed, float maxdistance)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, speed);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, maxdistance);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetTexture(Object @this, int textureid)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Object::SetTexture(Object _this, int textureid)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, textureid);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetTouchable(Object @this, bool val)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Object::SetTouchable(Object _this, bool val)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, val);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }


        public static void Remove(Object @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Object::Remove(Object _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsPlayer
    {
        public static Entity GetHitbox(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Player::GetHitbox(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Entity GetHead(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Player::GetHead(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Entity GetEntity(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Player::GetEntity(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static void GetScreenSize(Player @this, out int width, out int height)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::GetScreenSize(Player _this, int& out width, int& out height)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, out width);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, out height);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static string GetLanguage(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Player::GetLanguage(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetIP(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Player::GetIP(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetSteamID(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Player::GetSteamID(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetHWID(Player @this, int wmid)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Player::GetHWID(Player _this, int wmid)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, wmid);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetName(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Player::GetName(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static void SetSteamID(Player @this, in string steamid64)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetSteamID(Player _this, string& in steamid64)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, steamid64);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetName(Player @this, in string name)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetName(Player _this, string& in name)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, name);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static int GetPing(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Player::GetPing(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static int GetTime(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Player::GetTime(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static int GetIndex(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Player::GetIndex(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static string GetVersion(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Player::GetVersion(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static bool IsInvisible(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::IsInvisible(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static bool IsInvisibleForPlayer(Player @this, Player player)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::IsInvisibleForPlayer(Player _this, Player player)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetInvisible(Player @this, bool inv)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetInvisible(Player _this, bool inv)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, inv);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetLocalInvisible(Player @this, Player player, bool inv)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetLocalInvisible(Player _this, Player player, bool inv)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 2, inv);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Kick(Player @this, int code, in string custom)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::Kick(Player _this, int code, string& in custom)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, code);
            NativeBindings.SetModuleArgString(ModuleHandle, 2, custom);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void ShowDialog(Player @this, int type, int index, in string header, in string message, in string leftbutton, in string rightbutton, bool align)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::ShowDialog(Player _this, int type, int index, string& in header, string& in message, string& in leftbutton, string& in rightbutton, bool align)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, type);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, index);
            NativeBindings.SetModuleArgString(ModuleHandle, 3, header);
            NativeBindings.SetModuleArgString(ModuleHandle, 4, message);
            NativeBindings.SetModuleArgString(ModuleHandle, 5, leftbutton);
            NativeBindings.SetModuleArgString(ModuleHandle, 6, rightbutton);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 7, align);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }


        public static void SetDialogData(Player @this, in string data)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetDialogData(Player _this, string& in data)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, data);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static string GetDialogData(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Player::GetDialogData(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static void HideDialog(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::HideDialog(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SendMessage(Player @this, in string message, float time, bool localized)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SendMessage(Player _this, string& in message, float time, bool localized)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, message);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, time);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 3, localized);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Desync(Player @this, bool value)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::Desync(Player _this, bool value)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, value);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool IsDesync(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::IsDesync(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetSpectatePlayer(Player @this, Player target)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetSpectatePlayer(Player _this, Player target)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, target);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetSpectateMode(Player @this, int mode)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetSpectateMode(Player _this, int mode)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, mode);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static Player GetSpectatePlayer(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Player ccb::_Player::GetSpectatePlayer(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Player(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int GetSpectateMode(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Player::GetSpectateMode(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static bool Kill(Player @this, bool bloody, bool createcorpse)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::Kill(Player _this, bool bloody, bool createcorpse)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, bloody);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 2, createcorpse);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static bool Respawn(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::Respawn(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static bool IsDead(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::IsDead(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetInjuries(Player @this, float val)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetInjuries(Player _this, float val)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, val);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float GetInjuries(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Player::GetInjuries(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void SetBloodloss(Player @this, float val)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetBloodloss(Player _this, float val)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, val);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float GetBloodloss(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Player::GetBloodloss(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static bool GetGodmode(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::GetGodmode(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetGodmode(Player @this, bool val)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetGodmode(Player _this, bool val)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, val);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetColor(Player @this, uint hx)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetColor(Player _this, uint hx)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgUInt(ModuleHandle, 1, hx);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static uint GetColor(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "uint ccb::_Player::GetColor(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnUInt(ModuleHandle);
        }

        public static void GetNetworkPosition(Player @this, out float x, out float y, out float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::GetNetworkPosition(Player _this, float& out x, float& out y, float& out z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, out x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, out z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void GetNetworkRotation(Player @this, out float pitch, out float yaw)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::GetNetworkRotation(Player _this, float& out pitch, float& out yaw)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, out pitch);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out yaw);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetNetworkPosition(Player @this, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetNetworkPosition(Player _this, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetNetworkRotation(Player @this, float pitch, float yaw)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetNetworkRotation(Player _this, float pitch, float yaw)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, pitch);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, yaw);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetPosition(Player @this, float x, float y, float z, Room room, bool updatepivot)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetPosition(Player _this, float x, float y, float z, Room room, bool updatepivot)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);
            NativeBindings.SetModuleArgObject(ModuleHandle, 4, room);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 5, updatepivot);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetRotation(Player @this, float pitch, float yaw)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetRotation(Player _this, float pitch, float yaw)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, pitch);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, yaw);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Teleport(Player @this, Room room, float x, float y, float z, bool updatepivot)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::Teleport(Player _this, Room room, float x, float y, float z, bool updatepivot)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, room);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, z);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 5, updatepivot);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetRoom(Player @this, Room room)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetRoom(Player _this, Room room)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, room);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static Room GetRoom(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Room ccb::_Player::GetRoom(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Room(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static void SetPositionBounds(Player @this, Room room, float x, float y, float z, float distance)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetPositionBounds(Player _this, Room room, float x, float y, float z, float distance)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, room);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, z);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, distance);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Explode(Player @this, bool thrust)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::Explode(Player _this, bool thrust)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, thrust);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void MovePlayer(Player @this, float speedmult, float angle)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::MovePlayer(Player _this, float speedmult, float angle)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, speedmult);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, angle);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void IgnoreProximity(Player @this, bool value)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::IgnoreProximity(Player _this, bool value)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, value);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SendDamage(Player @this, Player player, float force, bool headshot, float offsetx, float offsety, float offsetz)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SendDamage(Player _this, Player player, float force, bool headshot, float offsetx, float offsety, float offsetz)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, force);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 3, headshot);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, offsetx);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, offsety);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 6, offsetz);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetAdmin(Player @this, bool val)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetAdmin(Player _this, bool val)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, val);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool IsAdmin(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::IsAdmin(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetGlobalTransmission(Player @this, bool val)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetGlobalTransmission(Player _this, bool val)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, val);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool IsGlobalTransmission(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::IsGlobalTransmission(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static bool SendVoice(Player @this, int bank, int radio, bool global, Player target)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::SendVoice(Player _this, int bank, int radio, bool global, Player target)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, bank);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, radio);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 3, global);
            NativeBindings.SetModuleArgObject(ModuleHandle, 4, target);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static int GetItemsCount(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Player::GetItemsCount(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static Items GetInventory(Player @this, int unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Items ccb::_Player::GetInventory(Player _this, int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Items(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Items GetSelectedItem(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Items ccb::_Player::GetSelectedItem(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Items(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static float GetBlinkTimer(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Player::GetBlinkTimer(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void SetBlinkTimer(Player @this, float time)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetBlinkTimer(Player _this, float time)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, time);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool IsBlinking(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::IsBlinking(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetBlinkEffect(Player @this, float effectvalue, float time)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetBlinkEffect(Player _this, float effectvalue, float time)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, effectvalue);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, time);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void GetBlinkEffect(Player @this, out float effectvalue, out float time)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::GetBlinkEffect(Player _this, float& out effectvalue, float& out time)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, out effectvalue);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out time);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void EnableBlinking(Player @this, bool blink)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::EnableBlinking(Player _this, bool blink)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, blink);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool IsBlinkingEnabled(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::IsBlinkingEnabled(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static int GetRadio(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Player::GetRadio(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static void PlayAnimation(Player @this, int animid)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::PlayAnimation(Player _this, int animid)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, animid);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetNetworkAnimation(Player @this, int animid)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetNetworkAnimation(Player _this, int animid)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, animid);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetAnimation(Player @this, int animid)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetAnimation(Player _this, int animid)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, animid);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static int GetAnimation(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Player::GetAnimation(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static void SetSpeedMultiplier(Player @this, float multiplier)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetSpeedMultiplier(Player _this, float multiplier)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, multiplier);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetStaminaMultiplier(Player @this, float multiplier)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetStaminaMultiplier(Player _this, float multiplier)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, multiplier);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float GetSpeedMultiplier(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Player::GetSpeedMultiplier(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetStaminaMultiplier(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Player::GetStaminaMultiplier(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void SetAttach(Player @this, int bodyindex, int attachmodelindex, Items item)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetAttach(Player _this, int bodyindex, int attachmodelindex, Items item)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, bodyindex);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, attachmodelindex);
            NativeBindings.SetModuleArgObject(ModuleHandle, 3, item);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static int GetAttach(Player @this, int bodyindex)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Player::GetAttach(Player _this, int bodyindex)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, bodyindex);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static Items GetAttachItem(Player @this, int bodyindex)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Items ccb::_Player::GetAttachItem(Player _this, int bodyindex)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, bodyindex);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Items(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int GetModel(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Player::GetModel(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static void SetModel(Player @this, int modelid, int textureid)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetModel(Player _this, int modelid, int textureid)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, modelid);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, textureid);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetModelSize(Player @this, float unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetModelSize(Player _this, float )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float GetModelSize(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Player::GetModelSize(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void SetModelTexture(Player @this, int textureid)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetModelTexture(Player _this, int textureid)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, textureid);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static int GetModelTexture(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Player::GetModelTexture(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static void SetCollisionRadius(Player @this, float unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetCollisionRadius(Player _this, float )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float GetCollisionRadius(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Player::GetCollisionRadius(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetVolume(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Player::GetVolume(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static bool IsCrouch(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::IsCrouch(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetGravity(Player @this, float multiplier)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetGravity(Player _this, float multiplier)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, multiplier);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float GetGravity(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Player::GetGravity(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void SetTagText(Player @this, int index, in string unnamed1)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetTagText(Player _this, int index, string& in )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);
            NativeBindings.SetModuleArgString(ModuleHandle, 2, unnamed1);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetTagScales(Player @this, int index, float unnamed1, float unnamed2)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetTagScales(Player _this, int index, float , float )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, unnamed1);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, unnamed2);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetTagOffset(Player @this, int index, float unnamed1)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetTagOffset(Player _this, int index, float )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, unnamed1);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetTagColors(Player @this, int index, int unnamed1, int unnamed2)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetTagColors(Player _this, int index, int , int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, unnamed1);
            NativeBindings.SetModuleArgInt(ModuleHandle, 3, unnamed2);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetTagFont(Player @this, int index, in string unnamed1)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetTagFont(Player _this, int index, string& in )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);
            NativeBindings.SetModuleArgString(ModuleHandle, 2, unnamed1);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static string GetTagText(Player @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Player::GetTagText(Player _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static void GetTagScales(Player @this, int index, out float scalex, out float scaley)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::GetTagScales(Player _this, int index, float& out scalex, float& out scaley)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out scalex);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, out scaley);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static float GetTagOffset(Player @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Player::GetTagOffset(Player _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static void GetTagColors(Player @this, int index, out uint start, out uint end)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::GetTagColors(Player _this, int index, uint& out start, uint& out end)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);
            NativeBindings.SetModuleArgUInt(ModuleHandle, 2, out start);
            NativeBindings.SetModuleArgUInt(ModuleHandle, 3, out end);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static string GetTagFont(Player @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Player::GetTagFont(Player _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static int GetShootsCount(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Player::GetShootsCount(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static void SetShootsCount(Player @this, int count)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetShootsCount(Player _this, int count)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, count);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void RedirectMove(Player @this, bool move)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::RedirectMove(Player _this, bool move)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, move);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool IsBot(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::IsBot(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static bool IsAiming(Player @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::IsAiming(Player _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void SetWearData(Player @this, int bodyindex, Items item)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::SetWearData(Player _this, int bodyindex, Items item)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, bodyindex);
            NativeBindings.SetModuleArgObject(ModuleHandle, 2, item);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Console(Player @this, in string message)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::Console(Player _this, string& in message)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, message);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static bool GetKeyState(Player @this, int keytype)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Player::GetKeyState(Player _this, int keytype)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, keytype);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static void GetTeleportData(Player @this, out float x, out float y, out float z, out Room room, out int tick)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Player::GetTeleportData(Player _this, float& out x, float& out y, float& out z, Room& out room, int& out tick)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, out x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, out z);
            NativeBindings.SetModuleArgObject(ModuleHandle, 4, out room);
            NativeBindings.SetModuleArgInt(ModuleHandle, 5, out tick);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsRoom
    {
        public static string GetName(Room @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Room::GetName(Room _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static int GetIndex(Room @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Room::GetIndex(Room _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static int GetIdentifier(Room @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Room::GetIdentifier(Room _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static Entity GetEntity(Room @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Room::GetEntity(Room _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Entity GetObject(Room @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Room::GetObject(Room _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Entity GetLever(Room @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Room::GetLever(Room _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static bool IsAdjacent(Room @this, Room unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Room::IsAdjacent(Room _this, Room )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static Room GetAdjacentRoom(Room @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Room ccb::_Room::GetAdjacentRoom(Room _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Room(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Door GetAdjacentDoor(Room @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Door ccb::_Room::GetAdjacentDoor(Room _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Door(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Door GetDoor(Room @this, int unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Door ccb::_Room::GetDoor(Room _this, int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Door(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static bool IsInside(Room @this, Entity unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Room::IsInside(Room _this, Entity )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }
    }

    internal static class AsServer
    {
        public static void Restart(Server @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Server::Restart(Server _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Console(Server @this, in string unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Server::Console(Server _this, string& in )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static string GetVersion(Server @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Server::GetVersion(Server _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static void AddVersion(Server @this, in string version)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Server::AddVersion(Server _this, string& in version)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, version);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void RemoveVersion(Server @this, in string version)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Server::RemoveVersion(Server _this, string& in version)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, version);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static int GetUPS(Server @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Server::GetUPS(Server _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static Config ParseConfig(Server @this, in string filename)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Config ccb::_Server::ParseConfig(Server _this, string& in filename)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, filename);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Config(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }




































    }

    internal static class AsShell
    {
        public static Entity GetEntity(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Shell::GetEntity(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int GetIndex(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Shell::GetIndex(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static void GetVelocity(Shell @this, out float x, out float y, out float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::GetVelocity(Shell _this, float& out x, float& out y, float& out z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, out x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, out y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, out z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static string GetActionEmitter(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Shell::GetActionEmitter(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static int GetEmitter(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Shell::GetEmitter(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static string GetActionSound(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Shell::GetActionSound(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetCollisionSound(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Shell::GetCollisionSound(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static string GetSound(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "string& ccb::_Shell::GetSound(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnString(ModuleHandle);
        }

        public static float GetSpeed(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Shell::GetSpeed(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetForce(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Shell::GetForce(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetRestitution(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Shell::GetRestitution(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetGravity(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Shell::GetGravity(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetCollisionRadius(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Shell::GetCollisionRadius(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetDamage(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Shell::GetDamage(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetTimeout(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Shell::GetTimeout(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static float GetImpactTime(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Shell::GetImpactTime(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static int GetAction(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Shell::GetAction(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static float GetActionRadius(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "float ccb::_Shell::GetActionRadius(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnFloat(ModuleHandle);
        }

        public static bool IsSticky(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "bool ccb::_Shell::IsSticky(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnBoolean(ModuleHandle);
        }

        public static uint GetStickFlags(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "uint ccb::_Shell::GetStickFlags(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnUInt(ModuleHandle);
        }

        public static int GetStickIndex(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Shell::GetStickIndex(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static int GetWeapon(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_Shell::GetWeapon(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static Player GetShooter(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Player ccb::_Shell::GetShooter(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Player(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static void Unstick(Shell @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::Unstick(Shell _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetSticky(Shell @this, bool sticky)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetSticky(Shell _this, bool sticky)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, sticky);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetVelocity(Shell @this, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetVelocity(Shell _this, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetActionEmitter(Shell @this, in string emitters)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetActionEmitter(Shell _this, string& in emitters)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, emitters);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetEmitter(Shell @this, int id)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetEmitter(Shell _this, int id)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, id);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetActionSound(Shell @this, in string sound)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetActionSound(Shell _this, string& in sound)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, sound);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetCollisionSound(Shell @this, in string sound)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetCollisionSound(Shell _this, string& in sound)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, sound);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetSound(Shell @this, in string sound)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetSound(Shell _this, string& in sound)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, sound);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetSpeed(Shell @this, float speed)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetSpeed(Shell _this, float speed)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, speed);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetForce(Shell @this, float force)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetForce(Shell _this, float force)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, force);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetRestitution(Shell @this, float restitution)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetRestitution(Shell _this, float restitution)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, restitution);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetGravity(Shell @this, float gravity)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetGravity(Shell _this, float gravity)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, gravity);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetCollisionRadius(Shell @this, float radius)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetCollisionRadius(Shell _this, float radius)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, radius);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetTimeout(Shell @this, float time)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetTimeout(Shell _this, float time)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, time);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetImpactTime(Shell @this, float time)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetImpactTime(Shell _this, float time)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, time);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetDamage(Shell @this, float damage)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetDamage(Shell _this, float damage)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, damage);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetAction(Shell @this, int action)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetAction(Shell _this, int action)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, action);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetActionRadius(Shell @this, float radius)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetActionRadius(Shell _this, float radius)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, radius);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void SetShooter(Shell @this, Player player)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::SetShooter(Shell _this, Player player)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, player);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Remove(Shell @this, bool action)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Shell::Remove(Shell _this, bool action)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 1, action);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsSound
    {
        public static void SetVolume(Sound @this, float vol)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Sound::SetVolume(Sound _this, float vol)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, vol);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Seek(Sound @this, float time)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Sound::Seek(Sound _this, float time)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, time);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void Stop(Sound @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_Sound::Stop(Sound _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }
    }

    internal static class AsWaypoint
    {
        public static Entity GetEntity(Waypoint @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Entity ccb::_Waypoint::GetEntity(Waypoint _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Entity(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Door GetDoor(Waypoint @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Door ccb::_Waypoint::GetDoor(Waypoint _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Door(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Room GetRoom(Waypoint @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Room ccb::_Waypoint::GetRoom(Waypoint _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Room(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }
    }

    internal static class AsWorld
    {
        public static void CreateDecal(World @this, int decalid, float x, float y, float z, float pitch, float yaw, float roll, Room room, float lifetime, float alpha, float size, float sizechange, float maxsize, float alphachange, int r, int g, int b, float timer)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_World::CreateDecal(World _this, int decalid, float x, float y, float z, float pitch, float yaw, float roll, Room room, float lifetime, float alpha, float size, float sizechange, float maxsize, float alphachange, int r, int g, int b, float timer)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, decalid);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, z);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, pitch);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 6, yaw);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 7, roll);
            NativeBindings.SetModuleArgObject(ModuleHandle, 8, room);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 9, lifetime);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 10, alpha);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 11, size);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 12, sizechange);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 13, maxsize);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 14, alphachange);
            NativeBindings.SetModuleArgInt(ModuleHandle, 15, r);
            NativeBindings.SetModuleArgInt(ModuleHandle, 16, g);
            NativeBindings.SetModuleArgInt(ModuleHandle, 17, b);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 18, timer);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void CreateEmitter(World @this, Player target, int id, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_World::CreateEmitter(World _this, Player target, int id, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, target);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, id);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void CreateEmitter(World @this, Player target, int id, float x, float y, float z, Player attachPlayer)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_World::CreateEmitter(World _this, Player target, int id, float x, float y, float z, Player attachPlayer)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, target);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, id);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, z);
            NativeBindings.SetModuleArgObject(ModuleHandle, 6, attachPlayer);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static void CreateEmitter(World @this, Player target, int id, float x, float y, float z, Object attachObject)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_World::CreateEmitter(World _this, Player target, int id, float x, float y, float z, Object attachObject)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, target);
            NativeBindings.SetModuleArgInt(ModuleHandle, 2, id);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, z);
            NativeBindings.SetModuleArgObject(ModuleHandle, 6, attachObject);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static Waypoint FindWaypoint(World @this, float fromx, float fromy, float fromz, float targetX, float targetY, float targetZ)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Waypoint ccb::_World::FindWaypoint(World _this, float fromx, float fromy, float fromz, float targetX, float targetY, float targetZ)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, fromx);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, fromy);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, fromz);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, targetX);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, targetY);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 6, targetZ);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Waypoint(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Waypoint FindWaypoint(World @this, Entity from, Entity to)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Waypoint ccb::_World::FindWaypoint(World _this, Entity from, Entity to)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgObject(ModuleHandle, 1, from);
            NativeBindings.SetModuleArgObject(ModuleHandle, 2, to);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Waypoint(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static int GetZone(World @this, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "int ccb::_World::GetZone(World _this, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 1, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return NativeBindings.GetModuleReturnInt(ModuleHandle);
        }

        public static Player CreateBot(World @this, in string unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Player ccb::_World::CreateBot(World _this, string& in )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Player(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static void RaycastItems(World @this)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "void ccb::_World::RaycastItems(World _this)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);
        }

        public static Items FindItem(World @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Items ccb::_World::FindItem(World _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Items(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Items CreateItem(World @this, in string templatename, bool collision, float x, float y, float z, int r, int g, int b, float alpha, int invslots)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Items ccb::_World::CreateItem(World _this, string& in templatename, bool collision, float x, float y, float z, int r, int g, int b, float alpha, int invslots)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, templatename);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 2, collision);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, z);
            NativeBindings.SetModuleArgInt(ModuleHandle, 6, r);
            NativeBindings.SetModuleArgInt(ModuleHandle, 7, g);
            NativeBindings.SetModuleArgInt(ModuleHandle, 8, b);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 9, alpha);
            NativeBindings.SetModuleArgInt(ModuleHandle, 10, invslots);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Items(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Items CreateItem(World @this, int templateindex, bool collision, float x, float y, float z, int r, int g, int b, float alpha, int invslots)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Items ccb::_World::CreateItem(World _this, int templateindex, bool collision, float x, float y, float z, int r, int g, int b, float alpha, int invslots)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, templateindex);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 2, collision);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 5, z);
            NativeBindings.SetModuleArgInt(ModuleHandle, 6, r);
            NativeBindings.SetModuleArgInt(ModuleHandle, 7, g);
            NativeBindings.SetModuleArgInt(ModuleHandle, 8, b);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 9, alpha);
            NativeBindings.SetModuleArgInt(ModuleHandle, 10, invslots);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Items(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Room GetRoomByName(World @this, in string unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Room ccb::_World::GetRoomByName(World _this, string& in )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgString(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Room(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Room GetRoomByIndex(World @this, int unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Room ccb::_World::GetRoomByIndex(World _this, int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Room(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Room GetRoomByIdentifier(World @this, int unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Room ccb::_World::GetRoomByIdentifier(World _this, int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Room(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Corpse FindCorpse(World @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Corpse ccb::_World::FindCorpse(World _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Corpse(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Door GetDoor(World @this, int unnamed0)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Door ccb::_World::GetDoor(World _this, int )", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, unnamed0);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Door(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Event GetEvent(World @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Event ccb::_World::GetEvent(World _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Event(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Event GetEventByIdentifier(World @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Event ccb::_World::GetEventByIdentifier(World _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Event(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Object CreateObject(World @this, int objectid, Room room, bool animated)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Object ccb::_World::CreateObject(World _this, int objectid, Room room, bool animated)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, objectid);
            NativeBindings.SetModuleArgObject(ModuleHandle, 2, room);
            NativeBindings.SetModuleArgBoolean(ModuleHandle, 3, animated);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Object(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Object FindObject(World @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Object ccb::_World::FindObject(World _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Object(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Light CreateLight(World @this, int type, float range, Room room)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Light ccb::_World::CreateLight(World _this, int type, float range, Room room)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, type);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, range);
            NativeBindings.SetModuleArgObject(ModuleHandle, 3, room);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Light(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Light FindLight(World @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Light ccb::_World::FindLight(World _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Light(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static NPC CreateNPC(World @this, int npctype, float x, float y, float z)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "NPC ccb::_World::CreateNPC(World _this, int npctype, float x, float y, float z)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, npctype);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 2, x);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 3, y);
            NativeBindings.SetModuleArgFloat(ModuleHandle, 4, z);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new NPC(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static NPC GetNPC(World @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "NPC ccb::_World::GetNPC(World _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new NPC(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static ModelPreset GetModelPreset(World @this, int modelid)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "ModelPreset ccb::_World::GetModelPreset(World _this, int modelid)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, modelid);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new ModelPreset(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Shell CreateShell(World @this, int weaponid, Player shooter)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Shell ccb::_World::CreateShell(World _this, int weaponid, Player shooter)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, weaponid);
            NativeBindings.SetModuleArgObject(ModuleHandle, 2, shooter);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Shell(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }

        public static Shell FindShell(World @this, int index)
        {
            var functionIndex = NativeBindings.FindModuleFunction(ModuleHandle, "Shell ccb::_World::FindShell(World _this, int index)", true);

            Debug.Assert(functionIndex >= 0);

            NativeBindings.PrepareModuleFunction(ModuleHandle, functionIndex);

            NativeBindings.SetModuleArgObject(ModuleHandle, 0, @this);
            NativeBindings.SetModuleArgInt(ModuleHandle, 1, index);

            NativeBindings.ExecuteModuleFunction(ModuleHandle);

            return new Shell(NativeBindings.GetModuleReturnObject(ModuleHandle));
        }
    }
}

internal struct Audio(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Audio(handle);
    }

    public Sound Play3DSound(in string filenameorurl, Player player, float range, float volume, bool norange)
    {
        return ScriptFunctions.AsAudio.Play3DSound(this, filenameorurl, player, range, volume, norange);
    }

    public Sound Play3DSound(in string filenameorurl, Entity entity, float range, float volume, bool norange)
    {
        return ScriptFunctions.AsAudio.Play3DSound(this, filenameorurl, entity, range, volume, norange);
    }

    public Sound Play3DSound(in string filenameorurl, float x, float y, float z, float range, float volume, bool norange)
    {
        return ScriptFunctions.AsAudio.Play3DSound(this, filenameorurl, x, y, z, range, volume, norange);
    }

    public Sound PlaySound(in string filenameorurl)
    {
        return ScriptFunctions.AsAudio.PlaySound(this, filenameorurl);
    }

    public Sound PlaySoundForPlayer(Player player, in string filenameorurl)
    {
        return ScriptFunctions.AsAudio.PlaySoundForPlayer(this, player, filenameorurl);
    }

    public Sound Play3DSoundForPlayer(Player player, in string filenameorurl, Entity entity, float range, float volume, bool norange)
    {
        return ScriptFunctions.AsAudio.Play3DSoundForPlayer(this, player, filenameorurl, entity, range, volume, norange);
    }

    public Sound Play3DSoundForPlayer(Player player, in string filenameorurl, float x, float y, float z, float range, float volume, bool norange)
    {
        return ScriptFunctions.AsAudio.Play3DSoundForPlayer(this, player, filenameorurl, x, y, z, range, volume, norange);
    }

    public Sound Play3DSoundForPlayer(Player player_to, in string filenameorurl, Player player, float range, float volume, bool norange)
    {
        return ScriptFunctions.AsAudio.Play3DSoundForPlayer(this, player_to, filenameorurl, player, range, volume, norange);
    }
}

internal struct Chat(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Chat(handle);
    }

    public void Send(in string message)
    {
        ScriptFunctions.AsChat.Send(this, message);
    }

    public void SendPlayer(Player player, in string message)
    {
        ScriptFunctions.AsChat.SendPlayer(this, player, message);
    }
}

internal struct Config(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Config(handle);
    }

    public bool Exist(in string key, int index)
    {
        return ScriptFunctions.AsConfig.Exist(this, key, index);
    }

    public string Get(in string key, int index)
    {
        return ScriptFunctions.AsConfig.Get(this, key, index);
    }

    public void Remove()
    {
        ScriptFunctions.AsConfig.Remove(this);
    }
}

internal struct Connection(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Connection(handle);
    }

    public int GetPort()
    {
        return ScriptFunctions.AsConnection.GetPort(this);
    }

    public string GetName()
    {
        return ScriptFunctions.AsConnection.GetName(this);
    }

    public string GetLanguage()
    {
        return ScriptFunctions.AsConnection.GetLanguage(this);
    }

    public string GetHWID(int wmid)
    {
        return ScriptFunctions.AsConnection.GetHWID(this, wmid);
    }

    public string GetIP()
    {
        return ScriptFunctions.AsConnection.GetIP(this);
    }

    public string GetSteamID()
    {
        return ScriptFunctions.AsConnection.GetSteamID(this);
    }

    public int GetQueue()
    {
        return ScriptFunctions.AsConnection.GetQueue(this);
    }

    public bool Join()
    {
        return ScriptFunctions.AsConnection.Join(this);
    }

    public void Accept()
    {
        ScriptFunctions.AsConnection.Accept(this);
    }

    public void Cancel(int code)
    {
        ScriptFunctions.AsConnection.Cancel(this, code);
    }

    public void Cancel(in string custom)
    {
        ScriptFunctions.AsConnection.Cancel(this, custom);
    }

    public void Remove()
    {
        ScriptFunctions.AsConnection.Remove(this);
    }
}

internal struct Corpse(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Corpse(handle);
    }

    public int GetIndex()
    {
        return ScriptFunctions.AsCorpse.GetIndex(this);
    }

    public Player GetPlayer()
    {
        return ScriptFunctions.AsCorpse.GetPlayer(this);
    }

    public Entity GetEntity()
    {
        return ScriptFunctions.AsCorpse.GetEntity(this);
    }

    public float GetTimeout()
    {
        return ScriptFunctions.AsCorpse.GetTimeout(this);
    }

    public void SetTimeout(float unnamed0)
    {
        ScriptFunctions.AsCorpse.SetTimeout(this, unnamed0);
    }

    public bool PushItem(Items unnamed0)
    {
        return ScriptFunctions.AsCorpse.PushItem(this, unnamed0);
    }

    public bool ExploreItem(int slot)
    {
        return ScriptFunctions.AsCorpse.ExploreItem(this, slot);
    }

    public Items GetItem(int slot)
    {
        return ScriptFunctions.AsCorpse.GetItem(this, slot);
    }

    public int GetModel()
    {
        return ScriptFunctions.AsCorpse.GetModel(this);
    }

    public int GetItemsCount()
    {
        return ScriptFunctions.AsCorpse.GetItemsCount(this);
    }

    public bool IsExplored()
    {
        return ScriptFunctions.AsCorpse.IsExplored(this);
    }

    public void SetExplore(bool explore)
    {
        ScriptFunctions.AsCorpse.SetExplore(this, explore);
    }

    public bool Explore()
    {
        return ScriptFunctions.AsCorpse.Explore(this);
    }

    public void SetData(in string data)
    {
        ScriptFunctions.AsCorpse.SetData(this, data);
    }

    public string GetData()
    {
        return ScriptFunctions.AsCorpse.GetData(this);
    }

    public void Remove()
    {
        ScriptFunctions.AsCorpse.Remove(this);
    }
}

internal struct Door(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Door(handle);
    }

    public void Use()
    {
        ScriptFunctions.AsDoor.Use(this);
    }

    public void SetOpen(bool unnamed0)
    {
        ScriptFunctions.AsDoor.SetOpen(this, unnamed0);
    }

    public bool IsOpened()
    {
        return ScriptFunctions.AsDoor.IsOpened(this);
    }

    public bool IsBreak()
    {
        return ScriptFunctions.AsDoor.IsBreak(this);
    }

    public void SetLockState(int unnamed0)
    {
        ScriptFunctions.AsDoor.SetLockState(this, unnamed0);
    }

    public int GetLockState()
    {
        return ScriptFunctions.AsDoor.GetLockState(this);
    }

    public float GetOpenState()
    {
        return ScriptFunctions.AsDoor.GetOpenState(this);
    }

    public bool BreakDoor(float x, float y, float z)
    {
        return ScriptFunctions.AsDoor.BreakDoor(this, x, y, z);
    }

    public void Decompose()
    {
        ScriptFunctions.AsDoor.Decompose(this);
    }

    public int GetDoorAccess()
    {
        return ScriptFunctions.AsDoor.GetDoorAccess(this);
    }

    public int GetDoorType()
    {
        return ScriptFunctions.AsDoor.GetDoorType(this);
    }

    public void SetKeycard(int unnamed0)
    {
        ScriptFunctions.AsDoor.SetKeycard(this, unnamed0);
    }

    public int GetKeycard()
    {
        return ScriptFunctions.AsDoor.GetKeycard(this);
    }

    public Entity GetEntity()
    {
        return ScriptFunctions.AsDoor.GetEntity(this);
    }

    public Entity GetButton(int index)
    {
        return ScriptFunctions.AsDoor.GetButton(this, index);
    }

    public int GetIndex()
    {
        return ScriptFunctions.AsDoor.GetIndex(this);
    }
}

internal struct Entity(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Entity(handle);
    }

    public void SetPosition(float x, float y, float z, bool global)
    {
        ScriptFunctions.AsEntity.SetPosition(this, x, y, z, global);
    }

    public void SetRotation(float pitch, float yaw, float roll, bool global)
    {
        ScriptFunctions.AsEntity.SetRotation(this, pitch, yaw, roll, global);
    }

    public void SetScale(float x, float y, float z, bool global)
    {
        ScriptFunctions.AsEntity.SetScale(this, x, y, z, global);
    }

    public float PositionX(bool global, float tween)
    {
        return ScriptFunctions.AsEntity.PositionX(this, global, tween);
    }

    public float PositionY(bool global, float tween)
    {
        return ScriptFunctions.AsEntity.PositionY(this, global, tween);
    }

    public float PositionZ(bool global, float tween)
    {
        return ScriptFunctions.AsEntity.PositionZ(this, global, tween);
    }

    public void Translate(float x, float y, float z, bool global)
    {
        ScriptFunctions.AsEntity.Translate(this, x, y, z, global);
    }

    public void Move(float x, float y, float z, bool global)
    {
        ScriptFunctions.AsEntity.Move(this, x, y, z, global);
    }

    public float Pitch(bool global, float tween)
    {
        return ScriptFunctions.AsEntity.Pitch(this, global, tween);
    }

    public float Yaw(bool global, float tween)
    {
        return ScriptFunctions.AsEntity.Yaw(this, global, tween);
    }

    public float Roll(bool global, float tween)
    {
        return ScriptFunctions.AsEntity.Roll(this, global, tween);
    }

    public float Turn(float pitch, float yaw, float roll, bool global)
    {
        return ScriptFunctions.AsEntity.Turn(this, pitch, yaw, roll, global);
    }

    public float ScaleX(bool global, float tween)
    {
        return ScriptFunctions.AsEntity.ScaleX(this, global, tween);
    }

    public float ScaleY(bool global, float tween)
    {
        return ScriptFunctions.AsEntity.ScaleY(this, global, tween);
    }

    public float ScaleZ(bool global, float tween)
    {
        return ScriptFunctions.AsEntity.ScaleZ(this, global, tween);
    }

    public void SetAnimTime(float time, int sequence)
    {
        ScriptFunctions.AsEntity.SetAnimTime(this, time, sequence);
    }

    public float GetAnimTime()
    {
        return ScriptFunctions.AsEntity.GetAnimTime(this);
    }

    public float Point(Entity target, float roll)
    {
        return ScriptFunctions.AsEntity.Point(this, target, roll);
    }

    public Entity Pick(float distance)
    {
        return ScriptFunctions.AsEntity.Pick(this, distance);
    }

    public void SetPickMode(int pickmode, bool obscurer)
    {
        ScriptFunctions.AsEntity.SetPickMode(this, pickmode, obscurer);
    }

    public bool Visible(Entity target, float radius)
    {
        return ScriptFunctions.AsEntity.Visible(this, target, radius);
    }

    public float Distance(Entity target)
    {
        return ScriptFunctions.AsEntity.Distance(this, target);
    }

    public float DistanceSquared(Entity target)
    {
        return ScriptFunctions.AsEntity.DistanceSquared(this, target);
    }

    public void SetParent(Entity target, bool retain)
    {
        ScriptFunctions.AsEntity.SetParent(this, target, retain);
    }

    public Entity GetParent()
    {
        return ScriptFunctions.AsEntity.GetParent(this);
    }

    public int CountChildren()
    {
        return ScriptFunctions.AsEntity.CountChildren(this);
    }

    public Entity GetChild(int unnamed0)
    {
        return ScriptFunctions.AsEntity.GetChild(this, unnamed0);
    }

    public string GetName()
    {
        return ScriptFunctions.AsEntity.GetName(this);
    }

    public void SetName(in string name)
    {
        ScriptFunctions.AsEntity.SetName(this, name);
    }

    public bool Collided(int colltype)
    {
        return ScriptFunctions.AsEntity.Collided(this, colltype);
    }

    public int CountCollisions()
    {
        return ScriptFunctions.AsEntity.CountCollisions(this);
    }

    public float CollisionX(int index)
    {
        return ScriptFunctions.AsEntity.CollisionX(this, index);
    }

    public float CollisionY(int index)
    {
        return ScriptFunctions.AsEntity.CollisionY(this, index);
    }

    public float CollisionZ(int index)
    {
        return ScriptFunctions.AsEntity.CollisionZ(this, index);
    }

    public float CollisionNX(int index)
    {
        return ScriptFunctions.AsEntity.CollisionNX(this, index);
    }

    public float CollisionNY(int index)
    {
        return ScriptFunctions.AsEntity.CollisionNY(this, index);
    }

    public float CollisionNZ(int index)
    {
        return ScriptFunctions.AsEntity.CollisionNZ(this, index);
    }

    public float CollisionImpulse(int index)
    {
        return ScriptFunctions.AsEntity.CollisionImpulse(this, index);
    }

    public float CollisionDistance(int index)
    {
        return ScriptFunctions.AsEntity.CollisionDistance(this, index);
    }

    public float CollisionTime(int index)
    {
        return ScriptFunctions.AsEntity.CollisionTime(this, index);
    }

    public Entity CollisionEntity(int index)
    {
        return ScriptFunctions.AsEntity.CollisionEntity(this, index);
    }

    public int CollisionTriangle(int index)
    {
        return ScriptFunctions.AsEntity.CollisionTriangle(this, index);
    }

    public void SetType(int colltype, bool recursive)
    {
        ScriptFunctions.AsEntity.SetType(this, colltype, recursive);
    }

    public void SetRadius(float x, float y)
    {
        ScriptFunctions.AsEntity.SetRadius(this, x, y);
    }

    public void SetCylinder(float x_radius, float y_radius)
    {
        ScriptFunctions.AsEntity.SetCylinder(this, x_radius, y_radius);
    }

    public void SetBox(float x, float y, float z, float w, float h, float d)
    {
        ScriptFunctions.AsEntity.SetBox(this, x, y, z, w, h, d);
    }

    public int GetType()
    {
        return ScriptFunctions.AsEntity.GetType(this);
    }

    public int GetShape(out float x, out float y, out float z, out float width, out float height, out float depth)
    {
        return ScriptFunctions.AsEntity.GetShape(this, out x, out y, out z, out width, out height, out depth);
    }

    public void Reset()
    {
        ScriptFunctions.AsEntity.Reset(this);
    }

    public bool InView(Entity target)
    {
        return ScriptFunctions.AsEntity.InView(this, target);
    }

    public void Show()
    {
        ScriptFunctions.AsEntity.Show(this);
    }

    public void Hide()
    {
        ScriptFunctions.AsEntity.Hide(this);
    }

    public void Remove()
    {
        ScriptFunctions.AsEntity.Remove(this);
    }

    public void SetMass(float mass)
    {
        ScriptFunctions.AsEntity.SetMass(this, mass);
    }

    public void SetPhysics(bool enable)
    {
        ScriptFunctions.AsEntity.SetPhysics(this, enable);
    }

    public void SetKinematic(bool enable)
    {
        ScriptFunctions.AsEntity.SetKinematic(this, enable);
    }

    public void SetCenter(float x, float y, float z)
    {
        ScriptFunctions.AsEntity.SetCenter(this, x, y, z);
    }

    public void SetLinearCast(bool enable)
    {
        ScriptFunctions.AsEntity.SetLinearCast(this, enable);
    }

    public void SetFriction(float friction)
    {
        ScriptFunctions.AsEntity.SetFriction(this, friction);
    }

    public void SetRollFriction(float friction)
    {
        ScriptFunctions.AsEntity.SetRollFriction(this, friction);
    }

    public void SetRestitution(float res)
    {
        ScriptFunctions.AsEntity.SetRestitution(this, res);
    }

    public void SetGravity(float factor)
    {
        ScriptFunctions.AsEntity.SetGravity(this, factor);
    }

    public void SetLinearFactor(float x, float y, float z)
    {
        ScriptFunctions.AsEntity.SetLinearFactor(this, x, y, z);
    }

    public void SetAngularFactor(float x, float y, float z)
    {
        ScriptFunctions.AsEntity.SetAngularFactor(this, x, y, z);
    }

    public void SetLinearDamping(float damping)
    {
        ScriptFunctions.AsEntity.SetLinearDamping(this, damping);
    }

    public void SetAngularDamping(float damping)
    {
        ScriptFunctions.AsEntity.SetAngularDamping(this, damping);
    }

    public void SetConstraint(float normalAngle, float planeAngle, float twistMinAngle, float twistMaxAngle, float torqueFriction)
    {
        ScriptFunctions.AsEntity.SetConstraint(this, normalAngle, planeAngle, twistMinAngle, twistMaxAngle, torqueFriction);
    }

    public void Activate(bool enable)
    {
        ScriptFunctions.AsEntity.Activate(this, enable);
    }

    public void Sleep(bool enable)
    {
        ScriptFunctions.AsEntity.Sleep(this, enable);
    }

    public void Freeze(bool enable)
    {
        ScriptFunctions.AsEntity.Freeze(this, enable);
    }

    public bool IsFreezed()
    {
        return ScriptFunctions.AsEntity.IsFreezed(this);
    }

    public bool IsActive()
    {
        return ScriptFunctions.AsEntity.IsActive(this);
    }

    public void SetLinearVelocity(float x, float y, float z)
    {
        ScriptFunctions.AsEntity.SetLinearVelocity(this, x, y, z);
    }

    public void SetAngularVelocity(float x, float y, float z)
    {
        ScriptFunctions.AsEntity.SetAngularVelocity(this, x, y, z);
    }

    public void GetLinearVelocity(out float x, out float y, out float z)
    {
        ScriptFunctions.AsEntity.GetLinearVelocity(this, out x, out y, out z);
    }

    public void GetAngularVelocity(out float x, out float y, out float z)
    {
        ScriptFunctions.AsEntity.GetAngularVelocity(this, out x, out y, out z);
    }

    public void Impulse(float x, float y, float z)
    {
        ScriptFunctions.AsEntity.Impulse(this, x, y, z);
    }

    public void Torque(float x, float y, float z)
    {
        ScriptFunctions.AsEntity.Torque(this, x, y, z);
    }

    public void ClearForces()
    {
        ScriptFunctions.AsEntity.ClearForces(this);
    }
}

internal struct Event(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Event(handle);
    }

    public Room GetRoom()
    {
        return ScriptFunctions.AsEvent.GetRoom(this);
    }

    public int GetIndex()
    {
        return ScriptFunctions.AsEvent.GetIndex(this);
    }

    public int GetIdentifier()
    {
        return ScriptFunctions.AsEvent.GetIdentifier(this);
    }

    public float GetState()
    {
        return ScriptFunctions.AsEvent.GetState(this);
    }

    public float GetState2()
    {
        return ScriptFunctions.AsEvent.GetState2(this);
    }

    public float GetState3()
    {
        return ScriptFunctions.AsEvent.GetState3(this);
    }

    public float GetState4()
    {
        return ScriptFunctions.AsEvent.GetState4(this);
    }

    public float SetState(float state)
    {
        return ScriptFunctions.AsEvent.SetState(this, state);
    }

    public float SetState2(float state)
    {
        return ScriptFunctions.AsEvent.SetState2(this, state);
    }

    public float SetState3(float state)
    {
        return ScriptFunctions.AsEvent.SetState3(this, state);
    }

    public float SetState4(float state)
    {
        return ScriptFunctions.AsEvent.SetState4(this, state);
    }

    public void Remove()
    {
        ScriptFunctions.AsEvent.Remove(this);
    }
}

internal struct GUIElement(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new GUIElement(handle);
    }

    public void GetPosition(out float x, out float y)
    {
        ScriptFunctions.AsGUIElement.GetPosition(this, out x, out y);
    }

    public void SetPosition(float x, float y)
    {
        ScriptFunctions.AsGUIElement.SetPosition(this, x, y);
    }

    public void SetScale(float width, float height)
    {
        ScriptFunctions.AsGUIElement.SetScale(this, width, height);
    }

    public void GetScale(out float width, out float height)
    {
        ScriptFunctions.AsGUIElement.GetScale(this, out width, out height);
    }

    public void SetRotation(int degrees)
    {
        ScriptFunctions.AsGUIElement.SetRotation(this, degrees);
    }

    public void GetRotation(out int degrees)
    {
        ScriptFunctions.AsGUIElement.GetRotation(this, out degrees);
    }

    public void SetData(in string data)
    {
        ScriptFunctions.AsGUIElement.SetData(this, data);
    }

    public void SetText(in string text)
    {
        ScriptFunctions.AsGUIElement.SetText(this, text);
    }

    public void SetFont(int fontid)
    {
        ScriptFunctions.AsGUIElement.SetFont(this, fontid);
    }

    public void SetSelectable(bool selectable)
    {
        ScriptFunctions.AsGUIElement.SetSelectable(this, selectable);
    }

    public void SetShadow(bool shadowed)
    {
        ScriptFunctions.AsGUIElement.SetShadow(this, shadowed);
    }

    public void SetAspect(bool keep)
    {
        ScriptFunctions.AsGUIElement.SetAspect(this, keep);
    }

    public void SetOpacity(float target, float lerp)
    {
        ScriptFunctions.AsGUIElement.SetOpacity(this, target, lerp);
    }

    public void SetColor(int r, int g, int b)
    {
        ScriptFunctions.AsGUIElement.SetColor(this, r, g, b);
    }

    public void SetTechnique(in string technique)
    {
        ScriptFunctions.AsGUIElement.SetTechnique(this, technique);
    }

    public Player GetPlayer()
    {
        return ScriptFunctions.AsGUIElement.GetPlayer(this);
    }

    public void SetAttach(Player player)
    {
        ScriptFunctions.AsGUIElement.SetAttach(this, player);
    }

    public void SetAttach(bool enable, float x, float y, float z)
    {
        ScriptFunctions.AsGUIElement.SetAttach(this, enable, x, y, z);
    }

    public Player GetAttach()
    {
        return ScriptFunctions.AsGUIElement.GetAttach(this);
    }

    public bool GetAttach(out float x, out float y, out float z)
    {
        return ScriptFunctions.AsGUIElement.GetAttach(this, out x, out y, out z);
    }

    public int GetFont()
    {
        return ScriptFunctions.AsGUIElement.GetFont(this);
    }

    public string GetText()
    {
        return ScriptFunctions.AsGUIElement.GetText(this);
    }

    public string GetData()
    {
        return ScriptFunctions.AsGUIElement.GetData(this);
    }

    public bool IsSelectable()
    {
        return ScriptFunctions.AsGUIElement.IsSelectable(this);
    }

    public bool IsHidden()
    {
        return ScriptFunctions.AsGUIElement.IsHidden(this);
    }

    public void SetCallback(in string funcname)
    {
        ScriptFunctions.AsGUIElement.SetCallback(this, funcname);
    }


    public void Hide()
    {
        ScriptFunctions.AsGUIElement.Hide(this);
    }

    public void Show()
    {
        ScriptFunctions.AsGUIElement.Show(this);
    }

    public void Remove()
    {
        ScriptFunctions.AsGUIElement.Remove(this);
    }
}

internal struct Graphics(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Graphics(handle);
    }

    public GUIElement CreateOval(Player player, float x, float y, float width, float height, bool align)
    {
        return ScriptFunctions.AsGraphics.CreateOval(this, player, x, y, width, height, align);
    }

    public GUIElement CreateRect(Player player, float x, float y, float width, float height, bool align)
    {
        return ScriptFunctions.AsGraphics.CreateRect(this, player, x, y, width, height, align);
    }

    public GUIElement CreateProgressBar(Player player, float time, float x, float y, float width, float height, bool align)
    {
        return ScriptFunctions.AsGraphics.CreateProgressBar(this, player, time, x, y, width, height, align);
    }

    public GUIElement CreateProgressBar(Player player, float time, float x, float y, float width, float height, bool align, in string callback)
    {
        return ScriptFunctions.AsGraphics.CreateProgressBar(this, player, time, x, y, width, height, align, callback);
    }

    public GUIElement CreateProgressBar(Player player, float time, float x, float y, float width, float height, bool align, nint callback)
    {
        return ScriptFunctions.AsGraphics.CreateProgressBar(this, player, time, x, y, width, height, align, callback);
    }

    public GUIElement CreateText(Player player, int fontid, in string text, float x, float y, bool align)
    {
        return ScriptFunctions.AsGraphics.CreateText(this, player, fontid, text, x, y, align);
    }

    public GUIElement CreateImage(Player player, in string filename, float x, float y, float width, float height, bool align)
    {
        return ScriptFunctions.AsGraphics.CreateImage(this, player, filename, x, y, width, height, align);
    }

    public GUIElement CreatePostEffect(Player player, in string filename, in string defines)
    {
        return ScriptFunctions.AsGraphics.CreatePostEffect(this, player, filename, defines);
    }
}

internal struct Items(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Items(handle);
    }

    public bool IsPicked()
    {
        return ScriptFunctions.AsItems.IsPicked(this);
    }

    public Player GetPicker()
    {
        return ScriptFunctions.AsItems.GetPicker(this);
    }

    public bool SetPicker(Player player, float throwforce)
    {
        return ScriptFunctions.AsItems.SetPicker(this, player, throwforce);
    }

    public Entity GetEntity()
    {
        return ScriptFunctions.AsItems.GetEntity(this);
    }

    public int GetIndex()
    {
        return ScriptFunctions.AsItems.GetIndex(this);
    }

    public string GetName()
    {
        return ScriptFunctions.AsItems.GetName(this);
    }

    public string GetTemplateName()
    {
        return ScriptFunctions.AsItems.GetTemplateName(this);
    }

    public int GetTemplateIndex()
    {
        return ScriptFunctions.AsItems.GetTemplateIndex(this);
    }

    public bool IsWeapon()
    {
        return ScriptFunctions.AsItems.IsWeapon(this);
    }

    public void SetState(float state)
    {
        ScriptFunctions.AsItems.SetState(this, state);
    }

    public void SetState2(float state)
    {
        ScriptFunctions.AsItems.SetState2(this, state);
    }

    public void SetState3(float state)
    {
        ScriptFunctions.AsItems.SetState3(this, state);
    }

    public float GetState()
    {
        return ScriptFunctions.AsItems.GetState(this);
    }

    public float GetState2()
    {
        return ScriptFunctions.AsItems.GetState2(this);
    }

    public float GetState3()
    {
        return ScriptFunctions.AsItems.GetState3(this);
    }

    public Items Fine(int unnamed0)
    {
        return ScriptFunctions.AsItems.Fine(this, unnamed0);
    }

    public int GetSlots()
    {
        return ScriptFunctions.AsItems.GetSlots(this);
    }

    public Items GetParentItem()
    {
        return ScriptFunctions.AsItems.GetParentItem(this);
    }

    public Items GetSlotItem(int unnamed0)
    {
        return ScriptFunctions.AsItems.GetSlotItem(this, unnamed0);
    }

    public bool PushItem(Items unnamed0)
    {
        return ScriptFunctions.AsItems.PushItem(this, unnamed0);
    }

    public bool RemoveSlotItem(int unnamed0)
    {
        return ScriptFunctions.AsItems.RemoveSlotItem(this, unnamed0);
    }

    public void Remove()
    {
        ScriptFunctions.AsItems.Remove(this);
    }
}

internal struct Light(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Light(handle);
    }

    public int GetIndex()
    {
        return ScriptFunctions.AsLight.GetIndex(this);
    }

    public void SetFOV(float fov)
    {
        ScriptFunctions.AsLight.SetFOV(this, fov);
    }

    public void SetRange(float range)
    {
        ScriptFunctions.AsLight.SetRange(this, range);
    }

    public void SetScattering(float scattering)
    {
        ScriptFunctions.AsLight.SetScattering(this, scattering);
    }

    public void SetColor(int r, int g, int b)
    {
        ScriptFunctions.AsLight.SetColor(this, r, g, b);
    }

    public void SetCastShadows(bool shadows)
    {
        ScriptFunctions.AsLight.SetCastShadows(this, shadows);
    }

    public void SetIntensity(float intensity)
    {
        ScriptFunctions.AsLight.SetIntensity(this, intensity);
    }

    public void SetLength(float length)
    {
        ScriptFunctions.AsLight.SetLength(this, length);
    }

    public float GetFOV()
    {
        return ScriptFunctions.AsLight.GetFOV(this);
    }

    public float GetRange()
    {
        return ScriptFunctions.AsLight.GetRange(this);
    }

    public float GetScattering()
    {
        return ScriptFunctions.AsLight.GetScattering(this);
    }

    public void GetColor(out int r, out int g, out int b)
    {
        ScriptFunctions.AsLight.GetColor(this, out r, out g, out b);
    }

    public bool GetCastShadows()
    {
        return ScriptFunctions.AsLight.GetCastShadows(this);
    }

    public float GetIntensity()
    {
        return ScriptFunctions.AsLight.GetIntensity(this);
    }

    public float GetLength()
    {
        return ScriptFunctions.AsLight.GetLength(this);
    }

    public void SetAttach(Player player)
    {
        ScriptFunctions.AsLight.SetAttach(this, player);
    }

    public Player GetAttach()
    {
        return ScriptFunctions.AsLight.GetAttach(this);
    }

    public void SetRoom(Room unnamed0)
    {
        ScriptFunctions.AsLight.SetRoom(this, unnamed0);
    }

    public Room GetRoom()
    {
        return ScriptFunctions.AsLight.GetRoom(this);
    }

    public Entity GetEntity()
    {
        return ScriptFunctions.AsLight.GetEntity(this);
    }

    public Entity GetLight()
    {
        return ScriptFunctions.AsLight.GetLight(this);
    }

    public void SetMovement(float speed, float maxdistance)
    {
        ScriptFunctions.AsLight.SetMovement(this, speed, maxdistance);
    }

    public void Remove()
    {
        ScriptFunctions.AsLight.Remove(this);
    }
}

internal struct ModelPreset(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new ModelPreset(handle);
    }
















































}

internal struct NPC(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new NPC(handle);
    }

    public Entity GetEntity()
    {
        return ScriptFunctions.AsNPC.GetEntity(this);
    }

    public Entity GetModel()
    {
        return ScriptFunctions.AsNPC.GetModel(this);
    }

    public void SetPickable(bool pickable)
    {
        ScriptFunctions.AsNPC.SetPickable(this, pickable);
    }

    public void SetDead(bool state)
    {
        ScriptFunctions.AsNPC.SetDead(this, state);
    }

    public bool IsDead()
    {
        return ScriptFunctions.AsNPC.IsDead(this);
    }

    public void SetHealth(int health)
    {
        ScriptFunctions.AsNPC.SetHealth(this, health);
    }

    public int GetHealth()
    {
        return ScriptFunctions.AsNPC.GetHealth(this);
    }

    public void SetIdle(float state)
    {
        ScriptFunctions.AsNPC.SetIdle(this, state);
    }

    public void SetState1(float state)
    {
        ScriptFunctions.AsNPC.SetState1(this, state);
    }

    public void SetState2(float state)
    {
        ScriptFunctions.AsNPC.SetState2(this, state);
    }

    public void SetState3(float state)
    {
        ScriptFunctions.AsNPC.SetState3(this, state);
    }

    public float GetIdle()
    {
        return ScriptFunctions.AsNPC.GetIdle(this);
    }

    public float GetState1()
    {
        return ScriptFunctions.AsNPC.GetState1(this);
    }

    public float GetState2()
    {
        return ScriptFunctions.AsNPC.GetState2(this);
    }

    public float GetState3()
    {
        return ScriptFunctions.AsNPC.GetState3(this);
    }

    public void Remove()
    {
        ScriptFunctions.AsNPC.Remove(this);
    }
}

internal struct Object(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Object(handle);
    }

    public void SetAttach(Player player)
    {
        ScriptFunctions.AsObject.SetAttach(this, player);
    }

    public Player GetAttach()
    {
        return ScriptFunctions.AsObject.GetAttach(this);
    }

    public void SetRoom(Room unnamed0)
    {
        ScriptFunctions.AsObject.SetRoom(this, unnamed0);
    }

    public Room GetRoom()
    {
        return ScriptFunctions.AsObject.GetRoom(this);
    }

    public int GetIndex()
    {
        return ScriptFunctions.AsObject.GetIndex(this);
    }

    public Entity GetEntity()
    {
        return ScriptFunctions.AsObject.GetEntity(this);
    }

    public Entity GetModel()
    {
        return ScriptFunctions.AsObject.GetModel(this);
    }

    public void SetMovement(float speed, float maxdistance)
    {
        ScriptFunctions.AsObject.SetMovement(this, speed, maxdistance);
    }

    public void SetTexture(int textureid)
    {
        ScriptFunctions.AsObject.SetTexture(this, textureid);
    }

    public void SetTouchable(bool val)
    {
        ScriptFunctions.AsObject.SetTouchable(this, val);
    }


    public void Remove()
    {
        ScriptFunctions.AsObject.Remove(this);
    }
}

internal struct Player(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Player(handle);
    }

    public Entity GetHitbox()
    {
        return ScriptFunctions.AsPlayer.GetHitbox(this);
    }

    public Entity GetHead()
    {
        return ScriptFunctions.AsPlayer.GetHead(this);
    }

    public Entity GetEntity()
    {
        return ScriptFunctions.AsPlayer.GetEntity(this);
    }

    public void GetScreenSize(out int width, out int height)
    {
        ScriptFunctions.AsPlayer.GetScreenSize(this, out width, out height);
    }

    public string GetLanguage()
    {
        return ScriptFunctions.AsPlayer.GetLanguage(this);
    }

    public string GetIP()
    {
        return ScriptFunctions.AsPlayer.GetIP(this);
    }

    public string GetSteamID()
    {
        return ScriptFunctions.AsPlayer.GetSteamID(this);
    }

    public string GetHWID(int wmid)
    {
        return ScriptFunctions.AsPlayer.GetHWID(this, wmid);
    }

    public string GetName()
    {
        return ScriptFunctions.AsPlayer.GetName(this);
    }

    public void SetSteamID(in string steamid64)
    {
        ScriptFunctions.AsPlayer.SetSteamID(this, steamid64);
    }

    public void SetName(in string name)
    {
        ScriptFunctions.AsPlayer.SetName(this, name);
    }

    public int GetPing()
    {
        return ScriptFunctions.AsPlayer.GetPing(this);
    }

    public int GetTime()
    {
        return ScriptFunctions.AsPlayer.GetTime(this);
    }

    public int GetIndex()
    {
        return ScriptFunctions.AsPlayer.GetIndex(this);
    }

    public string GetVersion()
    {
        return ScriptFunctions.AsPlayer.GetVersion(this);
    }

    public bool IsInvisible()
    {
        return ScriptFunctions.AsPlayer.IsInvisible(this);
    }

    public bool IsInvisibleForPlayer(Player player)
    {
        return ScriptFunctions.AsPlayer.IsInvisibleForPlayer(this, player);
    }

    public void SetInvisible(bool inv)
    {
        ScriptFunctions.AsPlayer.SetInvisible(this, inv);
    }

    public void SetLocalInvisible(Player player, bool inv)
    {
        ScriptFunctions.AsPlayer.SetLocalInvisible(this, player, inv);
    }

    public void Kick(int code, in string custom)
    {
        ScriptFunctions.AsPlayer.Kick(this, code, custom);
    }

    public void ShowDialog(int type, int index, in string header, in string message, in string leftbutton, in string rightbutton, bool align)
    {
        ScriptFunctions.AsPlayer.ShowDialog(this, type, index, header, message, leftbutton, rightbutton, align);
    }


    public void SetDialogData(in string data)
    {
        ScriptFunctions.AsPlayer.SetDialogData(this, data);
    }

    public string GetDialogData()
    {
        return ScriptFunctions.AsPlayer.GetDialogData(this);
    }

    public void HideDialog()
    {
        ScriptFunctions.AsPlayer.HideDialog(this);
    }

    public void SendMessage(in string message, float time, bool localized)
    {
        ScriptFunctions.AsPlayer.SendMessage(this, message, time, localized);
    }

    public void Desync(bool value)
    {
        ScriptFunctions.AsPlayer.Desync(this, value);
    }

    public bool IsDesync()
    {
        return ScriptFunctions.AsPlayer.IsDesync(this);
    }

    public void SetSpectatePlayer(Player target)
    {
        ScriptFunctions.AsPlayer.SetSpectatePlayer(this, target);
    }

    public void SetSpectateMode(int mode)
    {
        ScriptFunctions.AsPlayer.SetSpectateMode(this, mode);
    }

    public Player GetSpectatePlayer()
    {
        return ScriptFunctions.AsPlayer.GetSpectatePlayer(this);
    }

    public int GetSpectateMode()
    {
        return ScriptFunctions.AsPlayer.GetSpectateMode(this);
    }

    public bool Kill(bool bloody, bool createcorpse)
    {
        return ScriptFunctions.AsPlayer.Kill(this, bloody, createcorpse);
    }

    public bool Respawn()
    {
        return ScriptFunctions.AsPlayer.Respawn(this);
    }

    public bool IsDead()
    {
        return ScriptFunctions.AsPlayer.IsDead(this);
    }

    public void SetInjuries(float val)
    {
        ScriptFunctions.AsPlayer.SetInjuries(this, val);
    }

    public float GetInjuries()
    {
        return ScriptFunctions.AsPlayer.GetInjuries(this);
    }

    public void SetBloodloss(float val)
    {
        ScriptFunctions.AsPlayer.SetBloodloss(this, val);
    }

    public float GetBloodloss()
    {
        return ScriptFunctions.AsPlayer.GetBloodloss(this);
    }

    public bool GetGodmode()
    {
        return ScriptFunctions.AsPlayer.GetGodmode(this);
    }

    public void SetGodmode(bool val)
    {
        ScriptFunctions.AsPlayer.SetGodmode(this, val);
    }

    public void SetColor(uint hx)
    {
        ScriptFunctions.AsPlayer.SetColor(this, hx);
    }

    public uint GetColor()
    {
        return ScriptFunctions.AsPlayer.GetColor(this);
    }

    public void GetNetworkPosition(out float x, out float y, out float z)
    {
        ScriptFunctions.AsPlayer.GetNetworkPosition(this, out x, out y, out z);
    }

    public void GetNetworkRotation(out float pitch, out float yaw)
    {
        ScriptFunctions.AsPlayer.GetNetworkRotation(this, out pitch, out yaw);
    }

    public void SetNetworkPosition(float x, float y, float z)
    {
        ScriptFunctions.AsPlayer.SetNetworkPosition(this, x, y, z);
    }

    public void SetNetworkRotation(float pitch, float yaw)
    {
        ScriptFunctions.AsPlayer.SetNetworkRotation(this, pitch, yaw);
    }

    public void SetPosition(float x, float y, float z, Room room, bool updatepivot)
    {
        ScriptFunctions.AsPlayer.SetPosition(this, x, y, z, room, updatepivot);
    }

    public void SetRotation(float pitch, float yaw)
    {
        ScriptFunctions.AsPlayer.SetRotation(this, pitch, yaw);
    }

    public void Teleport(Room room, float x, float y, float z, bool updatepivot)
    {
        ScriptFunctions.AsPlayer.Teleport(this, room, x, y, z, updatepivot);
    }

    public void SetRoom(Room room)
    {
        ScriptFunctions.AsPlayer.SetRoom(this, room);
    }

    public Room GetRoom()
    {
        return ScriptFunctions.AsPlayer.GetRoom(this);
    }

    public void SetPositionBounds(Room room, float x, float y, float z, float distance)
    {
        ScriptFunctions.AsPlayer.SetPositionBounds(this, room, x, y, z, distance);
    }

    public void Explode(bool thrust)
    {
        ScriptFunctions.AsPlayer.Explode(this, thrust);
    }

    public void MovePlayer(float speedmult, float angle)
    {
        ScriptFunctions.AsPlayer.MovePlayer(this, speedmult, angle);
    }

    public void IgnoreProximity(bool value)
    {
        ScriptFunctions.AsPlayer.IgnoreProximity(this, value);
    }

    public void SendDamage(Player player, float force, bool headshot, float offsetx, float offsety, float offsetz)
    {
        ScriptFunctions.AsPlayer.SendDamage(this, player, force, headshot, offsetx, offsety, offsetz);
    }

    public void SetAdmin(bool val)
    {
        ScriptFunctions.AsPlayer.SetAdmin(this, val);
    }

    public bool IsAdmin()
    {
        return ScriptFunctions.AsPlayer.IsAdmin(this);
    }

    public void SetGlobalTransmission(bool val)
    {
        ScriptFunctions.AsPlayer.SetGlobalTransmission(this, val);
    }

    public bool IsGlobalTransmission()
    {
        return ScriptFunctions.AsPlayer.IsGlobalTransmission(this);
    }

    public bool SendVoice(int bank, int radio, bool global, Player target)
    {
        return ScriptFunctions.AsPlayer.SendVoice(this, bank, radio, global, target);
    }

    public int GetItemsCount()
    {
        return ScriptFunctions.AsPlayer.GetItemsCount(this);
    }

    public Items GetInventory(int unnamed0)
    {
        return ScriptFunctions.AsPlayer.GetInventory(this, unnamed0);
    }

    public Items GetSelectedItem()
    {
        return ScriptFunctions.AsPlayer.GetSelectedItem(this);
    }

    public float GetBlinkTimer()
    {
        return ScriptFunctions.AsPlayer.GetBlinkTimer(this);
    }

    public void SetBlinkTimer(float time)
    {
        ScriptFunctions.AsPlayer.SetBlinkTimer(this, time);
    }

    public bool IsBlinking()
    {
        return ScriptFunctions.AsPlayer.IsBlinking(this);
    }

    public void SetBlinkEffect(float effectvalue, float time)
    {
        ScriptFunctions.AsPlayer.SetBlinkEffect(this, effectvalue, time);
    }

    public void GetBlinkEffect(out float effectvalue, out float time)
    {
        ScriptFunctions.AsPlayer.GetBlinkEffect(this, out effectvalue, out time);
    }

    public void EnableBlinking(bool blink)
    {
        ScriptFunctions.AsPlayer.EnableBlinking(this, blink);
    }

    public bool IsBlinkingEnabled()
    {
        return ScriptFunctions.AsPlayer.IsBlinkingEnabled(this);
    }

    public int GetRadio()
    {
        return ScriptFunctions.AsPlayer.GetRadio(this);
    }

    public void PlayAnimation(int animid)
    {
        ScriptFunctions.AsPlayer.PlayAnimation(this, animid);
    }

    public void SetNetworkAnimation(int animid)
    {
        ScriptFunctions.AsPlayer.SetNetworkAnimation(this, animid);
    }

    public void SetAnimation(int animid)
    {
        ScriptFunctions.AsPlayer.SetAnimation(this, animid);
    }

    public int GetAnimation()
    {
        return ScriptFunctions.AsPlayer.GetAnimation(this);
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        ScriptFunctions.AsPlayer.SetSpeedMultiplier(this, multiplier);
    }

    public void SetStaminaMultiplier(float multiplier)
    {
        ScriptFunctions.AsPlayer.SetStaminaMultiplier(this, multiplier);
    }

    public float GetSpeedMultiplier()
    {
        return ScriptFunctions.AsPlayer.GetSpeedMultiplier(this);
    }

    public float GetStaminaMultiplier()
    {
        return ScriptFunctions.AsPlayer.GetStaminaMultiplier(this);
    }

    public void SetAttach(int bodyindex, int attachmodelindex, Items item)
    {
        ScriptFunctions.AsPlayer.SetAttach(this, bodyindex, attachmodelindex, item);
    }

    public int GetAttach(int bodyindex)
    {
        return ScriptFunctions.AsPlayer.GetAttach(this, bodyindex);
    }

    public Items GetAttachItem(int bodyindex)
    {
        return ScriptFunctions.AsPlayer.GetAttachItem(this, bodyindex);
    }

    public int GetModel()
    {
        return ScriptFunctions.AsPlayer.GetModel(this);
    }

    public void SetModel(int modelid, int textureid)
    {
        ScriptFunctions.AsPlayer.SetModel(this, modelid, textureid);
    }

    public void SetModelSize(float unnamed0)
    {
        ScriptFunctions.AsPlayer.SetModelSize(this, unnamed0);
    }

    public float GetModelSize()
    {
        return ScriptFunctions.AsPlayer.GetModelSize(this);
    }

    public void SetModelTexture(int textureid)
    {
        ScriptFunctions.AsPlayer.SetModelTexture(this, textureid);
    }

    public int GetModelTexture()
    {
        return ScriptFunctions.AsPlayer.GetModelTexture(this);
    }

    public void SetCollisionRadius(float unnamed0)
    {
        ScriptFunctions.AsPlayer.SetCollisionRadius(this, unnamed0);
    }

    public float GetCollisionRadius()
    {
        return ScriptFunctions.AsPlayer.GetCollisionRadius(this);
    }

    public float GetVolume()
    {
        return ScriptFunctions.AsPlayer.GetVolume(this);
    }

    public bool IsCrouch()
    {
        return ScriptFunctions.AsPlayer.IsCrouch(this);
    }

    public void SetGravity(float multiplier)
    {
        ScriptFunctions.AsPlayer.SetGravity(this, multiplier);
    }

    public float GetGravity()
    {
        return ScriptFunctions.AsPlayer.GetGravity(this);
    }

    public void SetTagText(int index, in string unnamed1)
    {
        ScriptFunctions.AsPlayer.SetTagText(this, index, unnamed1);
    }

    public void SetTagScales(int index, float unnamed1, float unnamed2)
    {
        ScriptFunctions.AsPlayer.SetTagScales(this, index, unnamed1, unnamed2);
    }

    public void SetTagOffset(int index, float unnamed1)
    {
        ScriptFunctions.AsPlayer.SetTagOffset(this, index, unnamed1);
    }

    public void SetTagColors(int index, int unnamed1, int unnamed2)
    {
        ScriptFunctions.AsPlayer.SetTagColors(this, index, unnamed1, unnamed2);
    }

    public void SetTagFont(int index, in string unnamed1)
    {
        ScriptFunctions.AsPlayer.SetTagFont(this, index, unnamed1);
    }

    public string GetTagText(int index)
    {
        return ScriptFunctions.AsPlayer.GetTagText(this, index);
    }

    public void GetTagScales(int index, out float scalex, out float scaley)
    {
        ScriptFunctions.AsPlayer.GetTagScales(this, index, out scalex, out scaley);
    }

    public float GetTagOffset(int index)
    {
        return ScriptFunctions.AsPlayer.GetTagOffset(this, index);
    }

    public void GetTagColors(int index, out uint start, out uint end)
    {
        ScriptFunctions.AsPlayer.GetTagColors(this, index, out start, out end);
    }

    public string GetTagFont(int index)
    {
        return ScriptFunctions.AsPlayer.GetTagFont(this, index);
    }

    public int GetShootsCount()
    {
        return ScriptFunctions.AsPlayer.GetShootsCount(this);
    }

    public void SetShootsCount(int count)
    {
        ScriptFunctions.AsPlayer.SetShootsCount(this, count);
    }

    public void RedirectMove(bool move)
    {
        ScriptFunctions.AsPlayer.RedirectMove(this, move);
    }

    public bool IsBot()
    {
        return ScriptFunctions.AsPlayer.IsBot(this);
    }

    public bool IsAiming()
    {
        return ScriptFunctions.AsPlayer.IsAiming(this);
    }

    public void SetWearData(int bodyindex, Items item)
    {
        ScriptFunctions.AsPlayer.SetWearData(this, bodyindex, item);
    }

    public void Console(in string message)
    {
        ScriptFunctions.AsPlayer.Console(this, message);
    }

    public bool GetKeyState(int keytype)
    {
        return ScriptFunctions.AsPlayer.GetKeyState(this, keytype);
    }

    public void GetTeleportData(out float x, out float y, out float z, out Room room, out int tick)
    {
        ScriptFunctions.AsPlayer.GetTeleportData(this, out x, out y, out z, out room, out tick);
    }
}

internal struct Room(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Room(handle);
    }

    public string GetName()
    {
        return ScriptFunctions.AsRoom.GetName(this);
    }

    public int GetIndex()
    {
        return ScriptFunctions.AsRoom.GetIndex(this);
    }

    public int GetIdentifier()
    {
        return ScriptFunctions.AsRoom.GetIdentifier(this);
    }

    public Entity GetEntity()
    {
        return ScriptFunctions.AsRoom.GetEntity(this);
    }

    public Entity GetObject(int index)
    {
        return ScriptFunctions.AsRoom.GetObject(this, index);
    }

    public Entity GetLever(int index)
    {
        return ScriptFunctions.AsRoom.GetLever(this, index);
    }

    public bool IsAdjacent(Room unnamed0)
    {
        return ScriptFunctions.AsRoom.IsAdjacent(this, unnamed0);
    }

    public Room GetAdjacentRoom(int index)
    {
        return ScriptFunctions.AsRoom.GetAdjacentRoom(this, index);
    }

    public Door GetAdjacentDoor(int index)
    {
        return ScriptFunctions.AsRoom.GetAdjacentDoor(this, index);
    }

    public Door GetDoor(int unnamed0)
    {
        return ScriptFunctions.AsRoom.GetDoor(this, unnamed0);
    }

    public bool IsInside(Entity unnamed0)
    {
        return ScriptFunctions.AsRoom.IsInside(this, unnamed0);
    }
}

internal struct Server(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Server(handle);
    }

    public void Restart()
    {
        ScriptFunctions.AsServer.Restart(this);
    }

    public void Console(in string unnamed0)
    {
        ScriptFunctions.AsServer.Console(this, unnamed0);
    }

    public string GetVersion()
    {
        return ScriptFunctions.AsServer.GetVersion(this);
    }

    public void AddVersion(in string version)
    {
        ScriptFunctions.AsServer.AddVersion(this, version);
    }

    public void RemoveVersion(in string version)
    {
        ScriptFunctions.AsServer.RemoveVersion(this, version);
    }

    public int GetUPS()
    {
        return ScriptFunctions.AsServer.GetUPS(this);
    }

    public Config ParseConfig(in string filename)
    {
        return ScriptFunctions.AsServer.ParseConfig(this, filename);
    }




































}

internal struct Shell(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Shell(handle);
    }

    public Entity GetEntity()
    {
        return ScriptFunctions.AsShell.GetEntity(this);
    }

    public int GetIndex()
    {
        return ScriptFunctions.AsShell.GetIndex(this);
    }

    public void GetVelocity(out float x, out float y, out float z)
    {
        ScriptFunctions.AsShell.GetVelocity(this, out x, out y, out z);
    }

    public string GetActionEmitter()
    {
        return ScriptFunctions.AsShell.GetActionEmitter(this);
    }

    public int GetEmitter()
    {
        return ScriptFunctions.AsShell.GetEmitter(this);
    }

    public string GetActionSound()
    {
        return ScriptFunctions.AsShell.GetActionSound(this);
    }

    public string GetCollisionSound()
    {
        return ScriptFunctions.AsShell.GetCollisionSound(this);
    }

    public string GetSound()
    {
        return ScriptFunctions.AsShell.GetSound(this);
    }

    public float GetSpeed()
    {
        return ScriptFunctions.AsShell.GetSpeed(this);
    }

    public float GetForce()
    {
        return ScriptFunctions.AsShell.GetForce(this);
    }

    public float GetRestitution()
    {
        return ScriptFunctions.AsShell.GetRestitution(this);
    }

    public float GetGravity()
    {
        return ScriptFunctions.AsShell.GetGravity(this);
    }

    public float GetCollisionRadius()
    {
        return ScriptFunctions.AsShell.GetCollisionRadius(this);
    }

    public float GetDamage()
    {
        return ScriptFunctions.AsShell.GetDamage(this);
    }

    public float GetTimeout()
    {
        return ScriptFunctions.AsShell.GetTimeout(this);
    }

    public float GetImpactTime()
    {
        return ScriptFunctions.AsShell.GetImpactTime(this);
    }

    public int GetAction()
    {
        return ScriptFunctions.AsShell.GetAction(this);
    }

    public float GetActionRadius()
    {
        return ScriptFunctions.AsShell.GetActionRadius(this);
    }

    public bool IsSticky()
    {
        return ScriptFunctions.AsShell.IsSticky(this);
    }

    public uint GetStickFlags()
    {
        return ScriptFunctions.AsShell.GetStickFlags(this);
    }

    public int GetStickIndex()
    {
        return ScriptFunctions.AsShell.GetStickIndex(this);
    }

    public int GetWeapon()
    {
        return ScriptFunctions.AsShell.GetWeapon(this);
    }

    public Player GetShooter()
    {
        return ScriptFunctions.AsShell.GetShooter(this);
    }

    public void Unstick()
    {
        ScriptFunctions.AsShell.Unstick(this);
    }

    public void SetSticky(bool sticky)
    {
        ScriptFunctions.AsShell.SetSticky(this, sticky);
    }

    public void SetVelocity(float x, float y, float z)
    {
        ScriptFunctions.AsShell.SetVelocity(this, x, y, z);
    }

    public void SetActionEmitter(in string emitters)
    {
        ScriptFunctions.AsShell.SetActionEmitter(this, emitters);
    }

    public void SetEmitter(int id)
    {
        ScriptFunctions.AsShell.SetEmitter(this, id);
    }

    public void SetActionSound(in string sound)
    {
        ScriptFunctions.AsShell.SetActionSound(this, sound);
    }

    public void SetCollisionSound(in string sound)
    {
        ScriptFunctions.AsShell.SetCollisionSound(this, sound);
    }

    public void SetSound(in string sound)
    {
        ScriptFunctions.AsShell.SetSound(this, sound);
    }

    public void SetSpeed(float speed)
    {
        ScriptFunctions.AsShell.SetSpeed(this, speed);
    }

    public void SetForce(float force)
    {
        ScriptFunctions.AsShell.SetForce(this, force);
    }

    public void SetRestitution(float restitution)
    {
        ScriptFunctions.AsShell.SetRestitution(this, restitution);
    }

    public void SetGravity(float gravity)
    {
        ScriptFunctions.AsShell.SetGravity(this, gravity);
    }

    public void SetCollisionRadius(float radius)
    {
        ScriptFunctions.AsShell.SetCollisionRadius(this, radius);
    }

    public void SetTimeout(float time)
    {
        ScriptFunctions.AsShell.SetTimeout(this, time);
    }

    public void SetImpactTime(float time)
    {
        ScriptFunctions.AsShell.SetImpactTime(this, time);
    }

    public void SetDamage(float damage)
    {
        ScriptFunctions.AsShell.SetDamage(this, damage);
    }

    public void SetAction(int action)
    {
        ScriptFunctions.AsShell.SetAction(this, action);
    }

    public void SetActionRadius(float radius)
    {
        ScriptFunctions.AsShell.SetActionRadius(this, radius);
    }

    public void SetShooter(Player player)
    {
        ScriptFunctions.AsShell.SetShooter(this, player);
    }

    public void Remove(bool action)
    {
        ScriptFunctions.AsShell.Remove(this, action);
    }
}

internal struct Sound(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Sound(handle);
    }

    public void SetVolume(float vol)
    {
        ScriptFunctions.AsSound.SetVolume(this, vol);
    }

    public void Seek(float time)
    {
        ScriptFunctions.AsSound.Seek(this, time);
    }

    public void Stop()
    {
        ScriptFunctions.AsSound.Stop(this);
    }
}

internal struct Waypoint(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new Waypoint(handle);
    }

    public Entity GetEntity()
    {
        return ScriptFunctions.AsWaypoint.GetEntity(this);
    }

    public Door GetDoor()
    {
        return ScriptFunctions.AsWaypoint.GetDoor(this);
    }

    public Room GetRoom()
    {
        return ScriptFunctions.AsWaypoint.GetRoom(this);
    }
}

internal struct World(ObjectHandle handle) : IScriptObject
{
    [StructLayout(LayoutKind.Sequential)]
    private readonly struct Opaque
    {
    }

    public ObjectHandle Handle { get; } = handle;

    public static IScriptObject Create(ObjectHandle handle)
    {
        return new World(handle);
    }

    public void CreateDecal(int decalid, float x, float y, float z, float pitch, float yaw, float roll, Room room, float lifetime, float alpha, float size, float sizechange, float maxsize, float alphachange, int r, int g, int b, float timer)
    {
        ScriptFunctions.AsWorld.CreateDecal(this, decalid, x, y, z, pitch, yaw, roll, room, lifetime, alpha, size, sizechange, maxsize, alphachange, r, g, b, timer);
    }

    public void CreateEmitter(Player target, int id, float x, float y, float z)
    {
        ScriptFunctions.AsWorld.CreateEmitter(this, target, id, x, y, z);
    }

    public void CreateEmitter(Player target, int id, float x, float y, float z, Player attachPlayer)
    {
        ScriptFunctions.AsWorld.CreateEmitter(this, target, id, x, y, z, attachPlayer);
    }

    public void CreateEmitter(Player target, int id, float x, float y, float z, Object attachObject)
    {
        ScriptFunctions.AsWorld.CreateEmitter(this, target, id, x, y, z, attachObject);
    }

    public Waypoint FindWaypoint(float fromx, float fromy, float fromz, float targetX, float targetY, float targetZ)
    {
        return ScriptFunctions.AsWorld.FindWaypoint(this, fromx, fromy, fromz, targetX, targetY, targetZ);
    }

    public Waypoint FindWaypoint(Entity from, Entity to)
    {
        return ScriptFunctions.AsWorld.FindWaypoint(this, from, to);
    }

    public int GetZone(float x, float y, float z)
    {
        return ScriptFunctions.AsWorld.GetZone(this, x, y, z);
    }

    public Player CreateBot(in string unnamed0)
    {
        return ScriptFunctions.AsWorld.CreateBot(this, unnamed0);
    }

    public void RaycastItems()
    {
        ScriptFunctions.AsWorld.RaycastItems(this);
    }

    public Items FindItem(int index)
    {
        return ScriptFunctions.AsWorld.FindItem(this, index);
    }

    public Items CreateItem(in string templatename, bool collision, float x, float y, float z, int r, int g, int b, float alpha, int invslots)
    {
        return ScriptFunctions.AsWorld.CreateItem(this, templatename, collision, x, y, z, r, g, b, alpha, invslots);
    }

    public Items CreateItem(int templateindex, bool collision, float x, float y, float z, int r, int g, int b, float alpha, int invslots)
    {
        return ScriptFunctions.AsWorld.CreateItem(this, templateindex, collision, x, y, z, r, g, b, alpha, invslots);
    }

    public Room GetRoomByName(in string unnamed0)
    {
        return ScriptFunctions.AsWorld.GetRoomByName(this, unnamed0);
    }

    public Room GetRoomByIndex(int unnamed0)
    {
        return ScriptFunctions.AsWorld.GetRoomByIndex(this, unnamed0);
    }

    public Room GetRoomByIdentifier(int unnamed0)
    {
        return ScriptFunctions.AsWorld.GetRoomByIdentifier(this, unnamed0);
    }

    public Corpse FindCorpse(int index)
    {
        return ScriptFunctions.AsWorld.FindCorpse(this, index);
    }

    public Door GetDoor(int unnamed0)
    {
        return ScriptFunctions.AsWorld.GetDoor(this, unnamed0);
    }

    public Event GetEvent(int index)
    {
        return ScriptFunctions.AsWorld.GetEvent(this, index);
    }

    public Event GetEventByIdentifier(int index)
    {
        return ScriptFunctions.AsWorld.GetEventByIdentifier(this, index);
    }

    public Object CreateObject(int objectid, Room room, bool animated)
    {
        return ScriptFunctions.AsWorld.CreateObject(this, objectid, room, animated);
    }

    public Object FindObject(int index)
    {
        return ScriptFunctions.AsWorld.FindObject(this, index);
    }

    public Light CreateLight(int type, float range, Room room)
    {
        return ScriptFunctions.AsWorld.CreateLight(this, type, range, room);
    }

    public Light FindLight(int index)
    {
        return ScriptFunctions.AsWorld.FindLight(this, index);
    }

    public NPC CreateNPC(int npctype, float x, float y, float z)
    {
        return ScriptFunctions.AsWorld.CreateNPC(this, npctype, x, y, z);
    }

    public NPC GetNPC(int index)
    {
        return ScriptFunctions.AsWorld.GetNPC(this, index);
    }

    public ModelPreset GetModelPreset(int modelid)
    {
        return ScriptFunctions.AsWorld.GetModelPreset(this, modelid);
    }

    public Shell CreateShell(int weaponid, Player shooter)
    {
        return ScriptFunctions.AsWorld.CreateShell(this, weaponid, shooter);
    }

    public Shell FindShell(int index)
    {
        return ScriptFunctions.AsWorld.FindShell(this, index);
    }
}
