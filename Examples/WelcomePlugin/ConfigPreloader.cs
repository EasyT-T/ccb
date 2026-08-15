namespace WelcomePlugin;

using CCB.Abstractions;
using CCB.Attributes;

[Injectable]
public class ConfigPreloader(IConfigProvider<WelcomePluginConfig> configProvider) : IPreload
{
    public void Preload()
    {
        configProvider.Cache(WelcomePluginConfig.Name, WelcomePluginConfig.Type, WelcomePluginConfig.Default);
    }
}