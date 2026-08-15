namespace CCB.Generator;

using System.Diagnostics;
using System.Text;
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

    public const string IntToConstCharName = "int_to_const_char";

    public const string IntToConstCharDef = $"const char {IntToConstCharName}(int)";

    public const string RegisterFunctionName = "RegisterFunction";

    public const string OnInitializeName = "OnInitialize";

    public const string ScriptFunctionsName = "ScriptFunctions";

    public const string NativeBindingsName = "NativeBindings";

    public const string ModuleHandleName = "ModuleHandle";

    public static void GenerateCSharpSetArgCode(TextWriter writer, SyntaxKind kind, int index, string value)
    {
        switch (kind)
        {
            case SyntaxKind.Int8:
                writer.WriteLine($"{NativeBindingsName}.SetModuleArgByte({ModuleHandleName}, {index}, (int){value});");
                break;
            case SyntaxKind.Int16:
                writer.WriteLine($"{NativeBindingsName}.SetModuleArgShort({ModuleHandleName}, {index}, (int){value});");
                break;
            case SyntaxKind.Int:
                writer.WriteLine($"{NativeBindingsName}.SetModuleArgInt({ModuleHandleName}, {index}, {value});");
                break;
            case SyntaxKind.UInt:
                writer.WriteLine($"{NativeBindingsName}.SetModuleArgUInt({ModuleHandleName}, {index}, {value});");
                break;
            case SyntaxKind.Bool:
                writer.WriteLine($"{NativeBindingsName}.SetModuleArgBoolean({ModuleHandleName}, {index}, {value});");
                break;
            case SyntaxKind.Float:
                writer.WriteLine($"{NativeBindingsName}.SetModuleArgFloat({ModuleHandleName}, {index}, {value});");
                break;
            case SyntaxKind.String:
                writer.WriteLine($"{NativeBindingsName}.SetModuleArgObject({ModuleHandleName}, {index}, new ObjectHandle((IntPtr){value}));");
                break;
            case SyntaxKind.Ref or SyntaxKind.QuestionMark:
                writer.WriteLine($"{NativeBindingsName}.SetModuleArgAddress({ModuleHandleName}, {index}, {value});");
                break;
            default:
                writer.WriteLine($"{NativeBindingsName}.SetModuleArgObject({ModuleHandleName}, {index}, {value});");
                break;
        }
    }

    public static void GenerateCSharpReturnCode(TextWriter writer, SyntaxKind kind, bool returnHandle, string? objectName = null)
    {
        switch (kind)
        {
            case SyntaxKind.Int8:
                writer.WriteLine($"return {NativeBindingsName}.GetModuleReturnByte({ModuleHandleName});");
                break;
            case SyntaxKind.Int16:
                writer.WriteLine($"return {NativeBindingsName}.GetModuleReturnShort({ModuleHandleName});");
                break;
            case SyntaxKind.Int:
                writer.WriteLine($"return {NativeBindingsName}.GetModuleReturnInt({ModuleHandleName});");
                break;
            case SyntaxKind.UInt:
                writer.WriteLine($"return {NativeBindingsName}.GetModuleReturnUInt({ModuleHandleName});");
                break;
            case SyntaxKind.Bool:
                writer.WriteLine($"return {NativeBindingsName}.GetModuleReturnBoolean({ModuleHandleName});");
                break;
            case SyntaxKind.Float:
                writer.WriteLine($"return {NativeBindingsName}.GetModuleReturnFloat({ModuleHandleName});");
                break;
            case SyntaxKind.String:
                writer.WriteLine($"return {NativeBindingsName}.GetModuleReturnCString({ModuleHandleName});");
                break;
            default:
                Debug.Assert(objectName is not null);
                writer.WriteLine($"return {NativeBindingsName}.GetModuleReturnObject<{objectName}>({ModuleHandleName}, {(returnHandle ? "true" : "false")});");
                break;
        }
    }

    public static string GetTypeName(TypeSyntax type)
    {
        return type.Inout.Kind == SyntaxKind.None
            ? type.Identifier.Text + type.RefHandle.Text
            : type.Identifier.Text + type.RefHandle.Text + ' ' + type.Inout.Text;
    }

    public static string GetCSharpTypeName(TypeSyntax type, bool withInOut = true)
    {
        //Patch ref/?
        if (type.Kind is SyntaxKind.Ref or SyntaxKind.QuestionMark)
        {
            return "nint";
        }

        var typeName = type.Identifier.Kind switch
        {
            SyntaxKind.Int8 => "byte",
            SyntaxKind.Int16 => "short",
            _ => type.Identifier.Text,
        };

        if (!withInOut)
        {
            return typeName;
        }

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

    public static void GenerateInvokeCode(IndentedTextWriter writer, IList<(string Name, string InOut, SyntaxKind TypeKind)> parameters, string declaration)
    {
        const string functionIndexVar = "functionIndex";

        writer.WriteLine($"var {functionIndexVar} = {NativeBindingsName}.FindModuleFunction({ModuleHandleName}, \"{declaration}\", true);");
#if DEBUG
        writer.WriteLine();
        writer.WriteLine("Debug.Assert(functionIndex > 0);");
        writer.WriteLine();
#endif
        writer.WriteLine($"{NativeBindingsName}.PrepareModuleFunction({ModuleHandleName}, {functionIndexVar});");
        writer.WriteLine();

        var freeCodeBuilder = new StringBuilder();

        for (var i = 0; i < parameters.Count; i++)
        {
            var parameter = parameters[i];

            var value = $"{parameter.InOut}{parameter.Name}";

            if (parameter.TypeKind == SyntaxKind.String && string.IsNullOrEmpty(parameter.InOut))
            {
                value = $"unmanagedStr{i}";
                writer.WriteLine($"var {value} = System.Runtime.InteropServices.Marshalling.Utf8StringMarshaller.ConvertToUnmanaged({parameter.Name});");
                freeCodeBuilder.AppendLine(
                    $"System.Runtime.InteropServices.Marshalling.Utf8StringMarshaller.Free({value});");
            }

            GenerateCSharpSetArgCode(writer, parameter.TypeKind, i, value);
        }

        writer.WriteLine();
        writer.WriteLine($"{NativeBindingsName}.ExecuteModuleFunction({ModuleHandleName});");
        writer.WriteLine();

        writer.Write(freeCodeBuilder);
    }

    public static void GenerateInvokeCode(
        IndentedTextWriter writer,
        IList<(string Name, string InOut, SyntaxKind TypeKind)> parameters,
        string declaration,
        SyntaxKind returnKind,
        string returnTypeName,
        bool returnHandle)
    {
        GenerateInvokeCode(writer, parameters, declaration);

        if (returnKind == SyntaxKind.Void)
        {
            return;
        }

        writer.WriteLine();

        GenerateCSharpReturnCode(writer, returnKind, returnHandle, returnTypeName);
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