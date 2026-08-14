namespace CCB.Generator;

using CCB.Syntax;

internal static class GeneratorFacts
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

    public const string LoadCcbName = "load_ccb";

    public const string LoadCcbDef = $"bool {LoadCcbName}()";

    public const string RegisterFunctionName = "RegisterFunction";

    public const string OnInitializeName = "OnInitialize";

    public const string ScriptFunctionsName = "ScriptFunctions";

    public const string NativeBindingsName = "NativeBindings";

    public const string ModuleHandleName = "ModuleHandle";

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

    public static string GetCSharpTypeName(TypeSyntax type)
    {
        //Patch ref
        if (type.Kind == SyntaxKind.Ref)
        {
            return "nint";
        }

        var typeName = type.Identifier.Text;

        var refName = type.RefHandle.Kind != SyntaxKind.None ? "ref " : string.Empty;

        var inoutName = type.Inout.Kind switch
        {
            SyntaxKind.In => "in ",
            SyntaxKind.Out => "out ",
            _ => string.Empty,
        };

        return type.Inout.Kind != SyntaxKind.None
            ? inoutName + typeName
            : refName + typeName;
    }

    public static string GetEventArgName(string eventName)
    {
        return $"{eventName}EventArg";
    }

    public static string GetHandlerName(string handlerName)
    {
        return $"On{handlerName}";
    }
}