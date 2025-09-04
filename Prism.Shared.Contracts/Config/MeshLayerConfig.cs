namespace Prism.Shared.Contracts.Config;

public class MeshLayerConfig
{
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public float Weight { get; set; } = 1.0f;
    public float Threshold { get; set; } = 0.0f;
}