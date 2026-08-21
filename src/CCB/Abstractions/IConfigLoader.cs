namespace CCB.Abstractions;

public interface IConfigLoader
{
    T LoadConfig<T>(string name, ConfigFileType fileType, Func<T> defaultValueFactory);

    Task<T> LoadConfigAsync<T>(string name, ConfigFileType fileType, Func<T> defaultValueFactory, CancellationToken cancellationToken = default);
}