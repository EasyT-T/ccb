namespace CCB.Generator;

public static class GeneratorFacts
{
    public const string PluginCode = """
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
                                     """;

    public const string ThisVarName = "_this";
}