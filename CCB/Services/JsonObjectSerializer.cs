namespace CCB.Services;

using System.Text.Json;
using CCB.Abstractions;
using CommunityToolkit.Diagnostics;

internal class JsonObjectSerializer : IObjectSerializer
{
    private JsonSerializerOptions _options = new JsonSerializerOptions(JsonSerializerDefaults.General)
    {
        WriteIndented = true,
    };

    public void Configure(JsonSerializerOptions options)
    {
        this._options = options;
    }

    public void Serialize<T>(Stream output, T config)
    {
        JsonSerializer.Serialize(output, config, this._options);
    }

    public Task SerializeAsync<T>(Stream output, T config, CancellationToken cancellationToken = default)
    {
        return JsonSerializer.SerializeAsync(output, config, this._options, cancellationToken);
    }

    public T Deserialize<T>(Stream input)
    {
        var result = JsonSerializer.Deserialize<T>(input, this._options);

        Guard.IsNotNull(result);

        return result;
    }

    public async Task<T> DeserializeAsync<T>(Stream input, CancellationToken cancellationToken = default)
    {
        var result = await JsonSerializer.DeserializeAsync<T>(input, this._options, cancellationToken);

        Guard.IsNotNull(result);

        return result;
    }

    public bool SupportType(ConfigFileType fileType)
    {
        return fileType == ConfigFileType.Json;
    }
}