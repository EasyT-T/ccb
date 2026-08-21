void OnInitialize()
{
    SetLibrary(LoadLibrary("ccb_rust.dll"));
    SetConvType(0);
    register_all_functions();
}

enum ConvTypes
{
    cdecl       = 0,
    stdcall     = 1
}
 
int currentlib = 0;
int convtype = 0;
string libmethod = "";

void SetLibrary(int lib)
{
    currentlib = lib;
}
 
void SetConvType(int type)
{
    convtype = type;
}
 
void SetLibraryMethod(string method)
{
    libmethod = method;
}
 
void RegisterMethod(string declaration, string proc)
{
    RegisterLibraryMethod(libmethod, declaration, GetProcAddress(currentlib, proc), convtype);
}
 
void RegisterFunction(string declaration, string proc)
{
    RegisterLibraryFunction(declaration, GetProcAddress(currentlib, proc),convtype);
}

void register_all_functions()
{
    RegisterFunction("bool load_ccb()", "load_ccb");
    RegisterFunction("const char int_to_const_char(int)", "int_to_const_char");
}
