using System.Reflection;
using System.Text.Json;
using Prism.Internals.DataManager.Factories;
using Prism.Internals.DataManager.MeshConfig.Audit;
using Prism.Internals.DataManager.Persistence;
using Prism.Internals.Orchestration.Coordinators;
using Prism.Internals.Orchestration.Registries;

namespace Prism.Internals.DataManager.MeshConfig
{
    public static class MeshConfigLoader
    {
        public static MeshConfigLoaderResult Load(string configPath)
        {
            try
            {
                var loaderDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var path = Path.Combine(loaderDir ?? string.Empty, "MeshConfig", configPath);

                if (!File.Exists(path))
                    throw new FileNotFoundException($"Mesh config file not found at {path}");

                Console.WriteLine($"[MeshLoader] Web config dependency loaded. Loading config from: {path}");

                var json = File.ReadAllText(path);
                var config = JsonSerializer.Deserialize<MeshConfigDocument>(json)
                             ?? throw new InvalidOperationException("Failed to parse meshConfig.json");

                Console.WriteLine($"[MeshLoader] Web config properly created from {path}");

                if (config.MeshComponents == null)
                    throw new InvalidOperationException("MeshComponents missing from meshConfig.json");

                if (config.MeshLayers == null)
                    throw new InvalidOperationException("MeshLayers missing from meshConfig.json");

                Console.WriteLine($"[MeshLoader] Components: {config.MeshComponents.Count}, Layers: {config.MeshLayers.Count}");

                var managers = ManagerFactory.CreateFromConfig(config.MeshComponents);
                var adapters = AdapterFactory.CreateFromConfig(config.MeshComponents); // ✅ Adapter hydration restored
                var layerRegistry = MeshLayerRegistry.CreateFromConfig(config.MeshLayers);

                var coordinator = new MeshCoordinator(managers, adapters, layerRegistry);
                var cache = new LiteMeshCache();

                return new MeshConfigLoaderResult(coordinator, layerRegistry, cache);
            }
            catch (FileNotFoundException e)
            {
                return new MeshConfigLoaderResult(null, null, null, $"Strand rupture detected: {e.Message}", e);
            }
            catch (InvalidOperationException e)
            {
                return new MeshConfigLoaderResult(null, null, null, $"Emotional mesh misconfiguration: {e.Message}", e);
            }
            catch (JsonException e)
            {
                return new MeshConfigLoaderResult(null, null, null, $"Malformed meshConfig.json: {e.Message}", e);
            }
            catch (Exception e)
            {
                return new MeshConfigLoaderResult(null, null, null, $"Unexpected error loading mesh config: {e.Message}", e);
            }
        }

        public static async Task HydrateAndPersistAsync(MeshCoordinator coordinator, LiteMeshCache cache)
        {
            var profiles = await coordinator.OrchestrateMeshAsync();
            cache.SaveProfiles(profiles);
        }
    }

    #region MeshConfigLoader Summary (Sprint 5 – September 07, 2025)
        // MeshConfigLoader hydrates emotional mesh components from meshConfig.json.
        // Deserializes managers, adapters, and layers, then constructs a MeshCoordinator and cache.
        // Adapter hydration was restored to ensure full orchestration integrity.
        // All exceptions are narratable and propagate emotional consequence for contributor-safe debugging.
        // JM ✦ Prism Architect ✦ September 07, 2025
    #endregion
}