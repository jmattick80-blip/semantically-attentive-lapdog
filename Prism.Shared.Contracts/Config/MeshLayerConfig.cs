namespace Prism.Shared.Contracts.Config
{
    public class MeshLayerConfig
    {
        public string LayerId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public float Weight { get; set; } = 1.0f;
        public float Threshold { get; set; } = 0.0f;
        /// <summary>
        /// Returns the effective name for registration, falling back to LayerId if Name is empty.
        /// </summary>
        public string EffectiveName => string.IsNullOrWhiteSpace(Name) ? LayerId : Name;

    }    
}

