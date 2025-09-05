using System.Text.Json;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Providers;

namespace Prism.Internals.DataManager.Adapters;

public class UnityMeshAdapter : IMeshProfileProvider
{
    private readonly string _configSource;

    public UnityMeshAdapter(string configSource)
    {
        _configSource = configSource ?? throw new ArgumentNullException(nameof(configSource));
    }

    public async Task<IEnumerable<MeshProfile>> GetProfilesAsync()
    {
        var profiles = new List<MeshProfile>();

        if (!Directory.Exists(_configSource))
            throw new DirectoryNotFoundException($"Mesh profile source directory not found: {_configSource}");

        var files = Directory.GetFiles(_configSource, "*.json");

        foreach (var file in files)
        {
            try
            {
                var json = await File.ReadAllTextAsync(file);
                var profile = JsonSerializer.Deserialize<MeshProfile>(json);

                if (profile != null)
                    profiles.Add(profile);
                else
                    Console.WriteLine($"[UnityMeshAdapter] Skipped malformed profile: {file}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UnityMeshAdapter] Error loading profile from {file}: {ex.Message}");
            }
        }

        return profiles;
    }
}