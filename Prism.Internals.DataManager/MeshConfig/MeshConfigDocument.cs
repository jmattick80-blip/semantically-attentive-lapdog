using Prism.Shared.Contracts.Config;

namespace Prism.Internals.DataManager.MeshConfig
{
    public class MeshConfigDocument
    {
        public List<MeshLayerConfig> MeshLayers { get; set; } = new();
        public List<MeshComponentConfig> MeshComponents { get; set; } = new();
    }    
    #region MeshConfigDocument Summary (Sprint 5 – September 07, 2025)
        // MeshConfigDocument defines the root structure for Prism’s emotional mesh configuration.
        // Contains lists of MeshLayerConfig and MeshComponentConfig for runtime hydration and orchestration.
        // Supports prefab-safe consequence routing, trait activation, and genre-specific simulation scaffolding.
        // Used by configuration loaders and orchestration layers to initialize Prism’s emotional mesh.
        // JM ✦ Prism Architect ✦ September 07, 2025
    #endregion
}

