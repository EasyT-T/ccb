namespace CCB.Services;

using CCB.Abstractions;
using CommunityToolkit.Diagnostics;

public class ConfigProvider<T>(IConfigLoader config) : IConfigProvider<T>
{
    private T? _cache;

    public T Cache(string name, ConfigFileType fileType, Func<T> defaultValueFactory)
    {
        return this._cache = config.LoadConfig(name, fileType, defaultValueFactory);
    }

    public async Task<T> CacheAsync(string name, ConfigFileType fileType, Func<T> defaultValueFactory, CancellationToken cancellationToken = default)
    {
        return this._cache = await config.LoadConfigAsync(name, fileType, defaultValueFactory, cancellationToken);
    }

    public T GetConfig()
    {
        Guard.IsNotNull(this._cache);

        return this._cache;
    }
}