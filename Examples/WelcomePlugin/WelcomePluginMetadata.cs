namespace WelcomePlugin;

using CCB.Abstractions;

public class WelcomePluginMetadata : IPluginMetadata
{
    public string Name => "WelcomePlugin";

    public string Description => "Welcome a player when joined in.";

    public string Author => "EasyT_T";
}