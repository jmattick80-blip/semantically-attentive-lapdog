using Prism.Internals.DataManager.Persistence;
using Prism.Internals.Orchestration.Coordinators;
using Prism.Internals.Orchestration.Registries;

namespace Prism.Internals.DataManager.MeshConfig.Audit
{
    public class MeshConfigLoaderResult
    {
        public bool IsSuccessful { get; }
        public string Message { get; }
        public Exception? Exception { get; }

        public MeshCoordinator? Coordinator { get; }
        public MeshLayerRegistry? LayerRegistry { get; }
        public LiteMeshCache? Cache { get; }

        public (MeshCoordinator? coordinator, MeshLayerRegistry? layerRegistry, LiteMeshCache? cache) Tuple =>
            (Coordinator, LayerRegistry, Cache);

        public MeshConfigLoaderResult(
            MeshCoordinator? coordinator,
            MeshLayerRegistry? layerRegistry,
            LiteMeshCache? cache,
            string message = "Mesh config loaded successfully.",
            Exception? exception = null)
        {
            IsSuccessful = exception == null;
            Message = message;
            Exception = exception;
            Coordinator = coordinator;
            LayerRegistry = layerRegistry;
            Cache = cache;
        }

        public string EmotionalNarration =>
            IsSuccessful
                ? $"[MeshLoader] {Message}"
                : $"[MeshEcho] {Message}. Emotional consequence may not resolve.";
    }    
    #region MeshConfigLoaderResult Summary (Sprint 5 – September 07, 2025)
        // MeshConfigLoaderResult encapsulates the outcome of mesh configuration loading.
        // Contains references to MeshCoordinator, MeshLayerRegistry, and LiteMeshCache.
        // Provides emotional narration for success or failure, supporting audit-safe consequence scaffolding.
        // Ideal for orchestration layers, fallback routing, and narratable mesh initialization flows.
        // JM ✦ Prism Architect ✦ September 07, 2025
    #endregion
}

