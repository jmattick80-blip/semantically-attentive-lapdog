using Prism.Shared.Contracts.Config;

namespace Prism.Internals.DataManager.MeshConfig;

public class MeshConfigDocument
{
    public List<MeshLayerConfig> MeshLayers { get; set; } = new();
    public List<MeshComponentConfig> MeshComponents { get; set; } = new();
}