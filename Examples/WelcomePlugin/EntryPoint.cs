namespace WelcomePlugin;

using CCB.Abstractions;
using CCB.Attributes;
using CCB.Internal;
using Microsoft.Extensions.Logging;

[Injectable]
internal partial class EntryPoint(ILogger<WelcomePluginMetadata> logger, IConfigProvider<WelcomePluginConfig> configProvider) : ILoad, IUnload
{
    private readonly WelcomePluginConfig _config = configProvider.GetConfig();

    public void Load()
    {
        EventRegistry.PlayerConnect += this.OnPlayerConnect;

        logger.LogInformation("Welcome plugin loaded");
    }

    public void Unload()
    {
        EventRegistry.PlayerConnect -= this.OnPlayerConnect;
    }

    private void OnPlayerConnect(EventRegistry.PlayerConnectEventArg ev)
    {
        var player = ev.Player;

        this.LogPlayerJoinedTheServer(player.GetName());

        player.SendMessage(this._config.WelcomeMessage, this._config.Duration, false);

        var c = GlobalProperties.Chat;

        c.Send($"Hello {player.GetName()}!");
    }

    [LoggerMessage(LogLevel.Information, "{player} Joined the server.")]
    partial void LogPlayerJoinedTheServer(string player);
}