using CCB;
using CCB.Generator;

Console.WriteLine("Hello, World!");

var scriptCompilation = new Compilation("all.h");
var scriptRoot = scriptCompilation.Parse();

using var scriptOutput = new StringWriter();
using var pluginOutput = new StringWriter();
using var csharpOutput = new StringWriter();
using var eventScriptOutput = new StringWriter();
using var eventCSharpOutput = new StringWriter();

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

var pluginGenerator = new PluginGenerator(scriptRoot, pluginOutput, config);
pluginGenerator.Generate();

var scriptGenerator = new ScriptGenerator(scriptRoot, scriptOutput, csharpOutput, config);
scriptGenerator.Generate();

var eventCompilation = new Compilation("event.h");
var eventRoot = eventCompilation.Parse();

var eventGenerator = new EventGenerator(eventRoot, eventScriptOutput, eventCSharpOutput);

eventGenerator.Generate();

File.WriteAllText("script.as", scriptOutput.ToString());
File.WriteAllText("plugin.as", pluginOutput.ToString());
File.WriteAllText("csharp.cs", csharpOutput.ToString());
File.WriteAllText("event.as", eventScriptOutput.ToString());
File.WriteAllText("event.cs", eventCSharpOutput.ToString());