namespace CCB.Abstractions;

using CCB;

public interface IObjectSerializer
{
    void Serialize<T>(Stream output, T config);

    Task SerializeAsync<T>(Stream output, T config, CancellationToken cancellationToken = default);

    T Deserialize<T>(Stream input);

    Task<T> DeserializeAsync<T>(Stream input, CancellationToken cancellationToken = default);

    bool SupportType(ConfigFileType fileType);
}