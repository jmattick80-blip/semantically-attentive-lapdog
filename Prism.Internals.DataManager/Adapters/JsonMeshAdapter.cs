using System.Reflection;
using System.Text.Json;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces.Providers;

namespace Prism.Internals.DataManager.Adapters
{
    public class JsonMeshAdapter : IMeshProfileProvider
    {
        private readonly string _resolvedPath;

        public JsonMeshAdapter(string configSource)
        {
            if (string.IsNullOrWhiteSpace(configSource))
                throw new ArgumentNullException(nameof(configSource));

            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                         ?? throw new InvalidOperationException("Unable to resolve base directory.");

            _resolvedPath = Path.Combine(baseDir, configSource);
            Console.WriteLine($"📁 JsonMeshAdapter: Resolved profile path to {_resolvedPath}");
        }

        public async Task<IEnumerable<MeshProfile>> GetProfilesAsync()
        {
            if (!File.Exists(_resolvedPath))
            {
                Console.WriteLine($"⚠️ JsonMeshAdapter: Source file not found at {_resolvedPath}");
                return Enumerable.Empty<MeshProfile>();
            }

            try
            {
                var json = await File.ReadAllTextAsync(_resolvedPath);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var profiles = JsonSerializer.Deserialize<List<MeshProfile>>(json, options);

                LogProfiles(profiles);
                return profiles ?? Enumerable.Empty<MeshProfile>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ JsonMeshAdapter: Failed to parse {_resolvedPath}: {ex.Message}");
                return Enumerable.Empty<MeshProfile>();
            }
        }

        private void LogProfiles(IEnumerable<MeshProfile>? profiles)
        {
            var count = profiles?.Count() ?? 0;
            Console.WriteLine($"📄 JsonMeshAdapter: Loaded {count} profiles.");

            foreach (var profile in profiles ?? Enumerable.Empty<MeshProfile>())
            {
                var id = string.IsNullOrWhiteSpace(profile.ContributorId) ? "Unnamed" : profile.ContributorId;
                Console.WriteLine($"🧬 Profile loaded: {id}");
            }
        }
    }
    #region Summary
    // JsonMeshAdapter
    // Resolves and hydrates bundles of MeshProfile objects from a single JSON file.
    // Uses runtime path anchoring to ensure consistency across environments.
    // Supports case-insensitive deserialization and narrates contributor presence.
    // Ideal for onboarding contributors in bulk with emotional consequence intact.
    //
    // /// JM ✦ Prism Architect ✦ 2025-09-03
    #endregion
}
