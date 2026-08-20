using CCB.Generator;

Console.WriteLine("Hello, World!");

//var scriptCompilation = new Compilation("all.h");
//var scriptRoot = scriptCompilation.Parse();

//using var scriptOutput = new StringWriter();
//using var pluginOutput = new StringWriter();
//using var csharpOutput = new StringWriter();
//using var eventScriptOutput = new StringWriter();
//using var eventCSharpOutput = new StringWriter();

var config = new GenerateConfigBuilder()
    .WithExternalAssembly("ccb_rust.dll")
    .WithConvType(0)
    .AddFuncDef("void", "DIALOGCALLBACK", [("Player", string.Empty), ("bool", string.Empty), ("string", string.Empty), ("int", string.Empty)])
    .AddFuncDef("void", "GUICALLBACK", [("Player", "p"), ("GUIElement", "gui")])
    .AddFuncDef("void", "OBJECTCALLBACK", [("Player", string.Empty), ("Object", string.Empty)])
    .WithIterables([
        "Room",
        "Items",
        "Player",
        "GUIElement",
        "Corpse",
        "Door",
        "Event",
        "Object",
        "NPC",
        "Config",
        "ModelPreset",
        "Connection",
        "Shell",
        "Sound",
        "Light",
        "Waypoint",
    ])
    .Build();

Directory.CreateDirectory("./output");
using var generator = new ScriptGenerator("all.h", "./output", config);
generator.Generate();