namespace Prism.Internals.Orchestration.Registries;

public class MeshLayerState
{
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public float Weight { get; set; }
    public float Threshold { get; set; }
}