namespace CCB.Abstractions;

public interface IPluginMetadata
{
    string Name { get; }

    string Description { get; }

    string Author { get; }
}