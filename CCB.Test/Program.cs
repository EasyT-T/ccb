using CCB;
using CCB.Generator;

Console.WriteLine("Hello, World!");

var compilation = new Compilation("all.h");
var root = compilation.Parse();

using var output = new StreamWriter(File.OpenWrite("output.as"));
var generator = new ScriptGenerator(root, output, new GenerateConfigBuilder());
generator.Generate();