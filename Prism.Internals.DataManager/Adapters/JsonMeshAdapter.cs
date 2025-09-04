using System.Text.Json;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Providers;

namespace Prism.Internals.DataManager.Adapters;

public class JsonMeshAdapter : IMeshProfileProvider
{
    private readonly string _configSource;

    public JsonMeshAdapter(string configSource)
    {
        _configSource = configSource ?? throw new ArgumentNullException(nameof(configSource));
    }

    public async Task<IEnumerable<MeshProfile>> GetProfilesAsync()
    {
        if (!File.Exists(_configSource))
        {
            Console.WriteLine($"⚠️ JsonMeshAdapter: Source file not found at {_configSource}");
            return Enumerable.Empty<MeshProfile>();
        }

        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var json = await File.ReadAllTextAsync(_configSource);
            var profiles = JsonSerializer.Deserialize<List<MeshProfile>>(json, options);

            Console.WriteLine($"📄 JsonMeshAdapter: Loaded {profiles?.Count ?? 0} profiles from {_configSource}");
            return profiles ?? Enumerable.Empty<MeshProfile>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ JsonMeshAdapter: Failed to parse {_configSource}: {ex.Message}");
            return Enumerable.Empty<MeshProfile>();
        }
    }
}