namespace CCB.Abstractions;

public interface IConfigProvider<T>
{
    T Cache(string name, ConfigFileType fileType, Func<T> defaultValueFactory);

    Task<T> CacheAsync(string name, ConfigFileType fileType, Func<T> defaultValueFactory, CancellationToken cancellationToken = default);

    T GetConfig();

    T Cache(string name, ConfigFileType fileType, T defaultValue)
    {
        return this.Cache(name, fileType, () => defaultValue);
    }

    Task<T> CacheAsync(
        string name,
        ConfigFileType fileType,
        T defaultValue,
        CancellationToken cancellationToken = default)
    {
        return this.CacheAsync(name, fileType, () => defaultValue, cancellationToken);
    }
}