namespace CCB.Services;

using CCB.Abstractions;

internal class PathProvider : IPathProvider
{
    private static string BaseDirectory { get; } = Path.Combine(Directory.GetCurrentDirectory(), "ccb");

    private static string ConfigDirectory { get; } = Path.Combine(BaseDirectory, "config");

    private static string PluginsDirectory { get; } = Path.Combine(BaseDirectory, "plugins");

    public string GetConfigDirectory()
    {
        Directory.CreateDirectory(ConfigDirectory);

        return ConfigDirectory;
    }

    public string GetPluginsDirectory()
    {
        Directory.CreateDirectory(PluginsDirectory);

        return PluginsDirectory;
    }
}