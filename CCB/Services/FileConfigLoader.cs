namespace CCB.Services;

using CCB.Abstractions;
using CommunityToolkit.Diagnostics;

internal class FileConfigLoader(IPathProvider pathProvider, IEnumerable<IObjectSerializer> serializers) : IConfigLoader
{
    public T LoadConfig<T>(string name, ConfigFileType fileType, Func<T> defaultValueFactory)
    {
        var serializer = serializers.FirstOrDefault(s => s.SupportType(fileType));

        Guard.IsNotNull(serializer);

        var configPath = Path.Combine(pathProvider.GetConfigDirectory(), name);

        return File.Exists(configPath)
            ? GetConfigFromExistedFile(configPath, serializer)
            : CreateDefaultConfig(configPath, defaultValueFactory, serializer);

        static T GetConfigFromExistedFile(string configPath, IObjectSerializer serializer)
        {
            using var stream = File.OpenRead(configPath);
            return serializer.Deserialize<T>(stream);
        }

        static T CreateDefaultConfig(string configPath, Func<T> defaultValueFactory, IObjectSerializer serializer)
        {
            using var stream = File.OpenWrite(configPath);
            var config = defaultValueFactory();
            serializer.Serialize(stream, config);

            return config;
        }
    }

    public Task<T> LoadConfigAsync<T>(string name, ConfigFileType fileType, Func<T> defaultValueFactory, CancellationToken cancellationToken = default)
    {
        var serializer = serializers.FirstOrDefault(s => s.SupportType(fileType));

        Guard.IsNotNull(serializer);

        var configPath = Path.Combine(pathProvider.GetConfigDirectory(), name);

        return File.Exists(configPath)
            ? GetConfigFromExistedFileAsync(configPath,  serializer, cancellationToken)
            : CreateDefaultConfigAsync(configPath,  defaultValueFactory, serializer, cancellationToken);

        static async Task<T> GetConfigFromExistedFileAsync(string configPath, IObjectSerializer serializer, CancellationToken cancellationToken = default)
        {
            await using var stream = File.OpenRead(configPath);
            return await serializer.DeserializeAsync<T>(stream);
        }

        static async Task<T> CreateDefaultConfigAsync(string configPath, Func<T> defaultValueFactory, IObjectSerializer serializer, CancellationToken cancellationToken = default)
        {
            await using var stream = File.OpenWrite(configPath);
            var config = defaultValueFactory();
            await serializer.SerializeAsync(stream, config);

            return config;
        }
    }
}