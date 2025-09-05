using Prism.Internals.DataManager.Persistence;
using Prism.Internals.Orchestration.Coordinators;
using Prism.Internals.Orchestration.Registries;

namespace Prism.Internals.DataManager.MeshConfig.Audit;

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