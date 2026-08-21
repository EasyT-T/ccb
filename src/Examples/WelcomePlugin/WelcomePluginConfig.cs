namespace WelcomePlugin;

using CCB;

public record WelcomePluginConfig(string WelcomeMessage, float Duration)
{
    public const string Name = "welcome.json";

    public const ConfigFileType Type = ConfigFileType.Json;

    public static WelcomePluginConfig Default { get; } = new WelcomePluginConfig("Welcome!", 10.0f);
}