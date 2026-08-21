using CCB;
using CCB.Generator;

Console.WriteLine("Hello, World!");

var config = new GenerateConfigBuilder()
    //.WithExternalAssembly("ccb_rust.dll")
    //.WithConvType(0)
    //.AddFuncDef("void", "DIALOGCALLBACK", [("Player", string.Empty), ("bool", string.Empty), ("string", string.Empty), ("int", string.Empty)])
    //.AddFuncDef("void", "GUICALLBACK", [("Player", "p"), ("GUIElement", "gui")])
    //.AddFuncDef("void", "OBJECTCALLBACK", [("Player", string.Empty), ("Object", string.Empty)])
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
using var scriptGenerator = new ScriptGenerator("all.h", "./output", config);
scriptGenerator.Generate();

var eventRoot = new Compilation("event.h").Parse();
using var eventGenerator = new EventGenerator(eventRoot, File.CreateText("./output/event.as"), File.CreateText("./output/event.cs"));
eventGenerator.Generate();