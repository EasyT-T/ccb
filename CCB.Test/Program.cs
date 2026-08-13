using CCB;
using CCB.Generator;

Console.WriteLine("Hello, World!");

var compilation = new Compilation("all.h");
var root = compilation.Parse();

using var scriptOutput = new StringWriter();
using var pluginOutput = new StringWriter();
using var csharpOutput = new StringWriter();

var generator = new ScriptGenerator(root,
    scriptOutput,
    pluginOutput,
    csharpOutput,
    new GenerateConfigBuilder()
        .WithExternalAssembly("ccb_rust.dll")
        .WithConvType(0)
        .AddFuncDef("void", "DIALOGCALLBACK", [("Player", string.Empty), ("bool", string.Empty), ("string", string.Empty), ("int", string.Empty)])
        .AddFuncDef("void", "GUICALLBACK", [("Player", "p"), ("GUIElement", "gui")])
        .AddFuncDef("void", "OBJECTCALLBACK", [("Player", string.Empty), ("Object", string.Empty)])
        .Build());
generator.Generate();

File.WriteAllText("script.as", scriptOutput.ToString());
File.WriteAllText("plugin.as", pluginOutput.ToString());
File.WriteAllText("csharp.cs", csharpOutput.ToString());