using CCB;
using CCB.Generator;

Console.WriteLine("Hello, World!");

var compilation = new Compilation("all.h");
var root = compilation.Parse();

using var scriptOutput = new StringWriter();
using var pluginOutput = new StringWriter();
var generator = new ScriptGenerator(root, scriptOutput, pluginOutput, new GenerateConfigBuilder()
    .WithExternalAssembly("ccb_rust.dll")
    .WithConvType(0));
generator.Generate();

File.WriteAllText("script.as", scriptOutput.ToString());
File.WriteAllText("plugin.as", pluginOutput.ToString());