using Prism.Shared.Contracts.Config;
using Prism.Shared.Contracts.Providers;
using Prism.Internals.DataManager.Adapters;

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
            _ => throw new NotSupportedException($"Unknown adapter type: {config.Type}")
        };
    }
}