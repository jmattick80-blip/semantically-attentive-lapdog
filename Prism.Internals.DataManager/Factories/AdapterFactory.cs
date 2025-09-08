using System.Text.Json;
using Prism.Shared.Contracts.Config;
using Prism.Internals.DataManager.Adapters;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces.Providers;

namespace Prism.Internals.DataManager.Factories;

public static class AdapterFactory
{
    public static List<IMeshProfileProvider> CreateFromConfig(List<MeshComponentConfig> configMeshComponents)
    {
        var adapters = new List<IMeshProfileProvider>();

        foreach (var component in configMeshComponents)
        {
            foreach (var adapterConfig in component.Adapters)
            {
                var adapter = CreateAdapter(adapterConfig);
                adapters.Add(adapter);
            }
        }

        return adapters;
    }

    private static IMeshProfileProvider CreateAdapter(AdapterConfig config)
    {
        return config.Type switch
        {
            "JsonMeshAdapter" => new JsonMeshAdapter(config.Source),
            "SignalMeshAdapter" => new SignalMeshAdapter(config.Source),
            "UnityMeshAdapter" => new UnityMeshAdapter(config.Source),
            _ => throw new NotSupportedException($"Unknown adapter type: {config.Type}")
        };
    }
    
    #region AdapterFactory Summary (Sprint 5 – September 9, 2025)
        // AdapterFactory orchestrates the creation of IMeshProfileProvider instances from configuration.
        // It supports modular mesh hydration via JsonMeshAdapter, SignalMeshAdapter, and UnityMeshAdapter.
        // Enables prefab-safe contributor onboarding from local files, remote endpoints, or Unity-compatible sources.
        // This factory centralizes adapter instantiation for processors, registries, and mesh-aware systems.
        // Ideal for dynamic mesh configuration, multiplayer consequence routing, and genre-safe simulation scaffolding.
        // JM ✦ Prism Architect ✦ 2025-09-07
    #endregion
}