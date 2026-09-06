namespace WelcomePlugin;

using CCB.Abstractions;
using CCB.Attributes;
using CCB.Internal;
using Microsoft.Extensions.Logging;

[Injectable]
internal class EntryPoint(ILogger<WelcomePluginMetadata> logger, IConfigProvider<WelcomePluginConfig> configProvider) : ILoad, IUnload
{
    private readonly WelcomePluginConfig _config = configProvider.GetConfig();

    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    public void Load()
    {
        EventRegistry.PlayerConnect += this.OnPlayerConnect;
        EventRegistry.WorldLoaded += this.OnWorldLoaded;

        logger.LogInformation("Welcome plugin loaded");
    }

    public void Unload()
    {
        EventRegistry.PlayerConnect -= this.OnPlayerConnect;
        EventRegistry.WorldLoaded -= this.OnWorldLoaded;

        this._cancellationTokenSource.Cancel();
        this._cancellationTokenSource.Dispose();
    }

    private void OnWorldLoaded()
    {
        _ = RunWelcomeMessageHandler(GlobalProperties.Chat);

        return;

        async Task RunWelcomeMessageHandler(Chat chat)
        {
            try
            {
                while (!this._cancellationTokenSource.Token.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromSeconds(300), this._cancellationTokenSource.Token);

                    // SynchronizationContext restored here
                    // We don't need to call RunOnMainThread because we're actually on the main thread

                    chat.Send("Please follow the server rules!");
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }

    private void OnPlayerConnect(EventRegistry.PlayerConnectEventArg ev)
    {
        var player = ev.Player;

        player.SendMessage(this._config.WelcomeMessage, this._config.Duration);

        var chat = GlobalProperties.Chat;

        chat.Send($"Welcome {player.GetName()}!");
    }
}