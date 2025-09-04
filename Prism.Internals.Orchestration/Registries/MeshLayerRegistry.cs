using Prism.Shared.Contracts.Config;
using Prism.Shared.Contracts.Orchestration;

namespace Prism.Internals.Orchestration.Registries;

public class MeshLayerRegistry : IPrismRegistry
{
    private readonly Dictionary<string, MeshLayerState> _layers = new();

    public void RegisterLayer(string name, bool active, float weight = 1.0f, float threshold = 0.0f)
    {
        _layers[name.ToLower()] = new MeshLayerState
        {
            Name = name,
            IsActive = active,
            Weight = weight,
            Threshold = threshold
        };
    }

    public bool IsActive(string name) =>
        _layers.TryGetValue(name.ToLower(), out var layer) && layer.IsActive;

    public float GetWeight(string name) =>
        _layers.TryGetValue(name.ToLower(), out var layer) ? layer.Weight : 0f;

    public float GetThreshold(string name) =>
        _layers.TryGetValue(name.ToLower(), out var layer) ? layer.Threshold : 0f;

    public IEnumerable<MeshLayerState> GetAllLayers() => _layers.Values;

    public static MeshLayerRegistry CreateFromConfig(List<MeshLayerConfig> configMeshLayers)
    {
        throw new NotImplementedException();
    }
}

public class MeshLayerState
{
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public float Weight { get; set; }
    public float Threshold { get; set; }
}