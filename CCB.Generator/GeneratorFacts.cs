namespace CCB.Generator;

using CCB.Syntax;

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

    public const string RegisterAllFunctionsName = "register_all_functions";

    public const string RegisterAllFunctionDefsName = "register_all_funcdef()";

    public const string LoadCcbName = "load_ccb";

    public const string LoadCcbDef = $"bool {LoadCcbName}()";

    public const string RegisterMethodName = "register_method";

    public const string RegisterFuncdefName = "RegisterFuncdef";

    public const string RegisterFunctionName = "RegisterFunction";

    public const string OnInitializeName = "OnInitialize";

    public static string RegisterMethodDef(string funcDef)
    {
        return $"void {RegisterMethodName}(int index, const char class_name, const char method_name, {funcDef} @def)";
    }

    public static string GetFuncDefName(int index)
    {
        return $"_FUNC_DEF_{index}";
    }

    public static string GetReturnTypeName(FieldDeclarationSyntax node)
    {
        return node.Modifiers.Count > 0
            ? string.Join(' ', node.Modifiers) + ' ' + node.Type.Identifier.Text + node.Type.RefHandle.Text
            : node.Type.Identifier.Text + node.Type.RefHandle.Text;
    }

    public static string GetTypeName(TypeSyntax type)
    {
        return type.Inout.Kind == SyntaxKind.None
            ? type.Identifier.Text + type.RefHandle.Text
            : type.Identifier.Text + type.RefHandle.Text + ' ' + type.Inout.Text;
    }
}