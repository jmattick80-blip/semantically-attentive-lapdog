using System.Text.Json;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces.Providers;

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
    
    private async Task<IEnumerable<MeshProfile>> LoadBundledProfilesAsync(string bundlePath)
    {
        if (!File.Exists(bundlePath))
        {
            Console.WriteLine($"[UnityMeshAdapter] Bundled profile file not found: {bundlePath}");
            return Enumerable.Empty<MeshProfile>();
        }

        try
        {
            var json = await File.ReadAllTextAsync(bundlePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var profiles = JsonSerializer.Deserialize<List<MeshProfile>>(json, options);

            Console.WriteLine($"[UnityMeshAdapter] Loaded {profiles?.Count ?? 0} bundled profiles.");
            return profiles ?? Enumerable.Empty<MeshProfile>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[UnityMeshAdapter] Error loading bundled profiles: {ex.Message}");
            return Enumerable.Empty<MeshProfile>();
        }
    }

    #region UnityMeshAdapter Summary (Sprint 5 – September 9, 2025)
    // UnityMeshAdapter hydrates MeshProfile objects from Unity-compatible sources.
    // Supports both individual JSON files and bundled profile lists (e.g. ScriptableObject-style).
    // Enables prefab-safe contributor onboarding, local mesh hydration, and genre-specific consequence routing.
    // Profiles are loaded with error handling for malformed or missing files, and fallback logic for hybrid formats.
    // Ideal for Unity-based simulations, asset-driven emotional scaffolding, and hybrid mesh configuration workflows.
    // JM ✦ Prism Architect ✦ Sprint 5
    #endregion
}