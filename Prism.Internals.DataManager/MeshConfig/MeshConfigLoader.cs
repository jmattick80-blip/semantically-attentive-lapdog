using System.Text.Json;
using Prism.Internals.DataManager.Factories;
using Prism.Internals.DataManager.Persistence;
using Prism.Internals.Orchestration.Coordinators;
using Prism.Internals.Orchestration.Registries;

namespace Prism.Internals.DataManager.MeshConfig;

public static class MeshConfigLoader
{
    public static (MeshCoordinator coordinator, MeshLayerRegistry layerRegistry, LiteMeshCache cache) Load(string configPath)
    {
        var json = File.ReadAllText(configPath);
        var config = JsonSerializer.Deserialize<MeshConfigDocument>(json)
                     ?? throw new InvalidOperationException("Failed to parse meshConfig.json");

        var managers = ManagerFactory.CreateFromConfig(config.MeshComponents);
        var adapters = AdapterFactory.CreateFromConfig(config.MeshComponents);
        var layerRegistry = MeshLayerRegistry.CreateFromConfig(config.MeshLayers);

        var coordinator = new MeshCoordinator(managers, adapters, layerRegistry);
        var cache = new LiteMeshCache();

        return (coordinator, layerRegistry, cache);
    }

    public static async Task HydrateAndPersistAsync(MeshCoordinator coordinator, LiteMeshCache cache)
    {
        var profiles = await coordinator.OrchestrateMeshAsync();
        cache.SaveProfiles(profiles);
    }
}