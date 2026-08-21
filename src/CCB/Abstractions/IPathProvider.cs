namespace CCB.Abstractions;

public interface IPathProvider
{
    string GetConfigDirectory();

    string GetPluginsDirectory();
}