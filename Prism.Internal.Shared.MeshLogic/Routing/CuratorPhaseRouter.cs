using Prism.Internal.Shared.MeshLogic.Interfaces;
using Prism.Internal.Shared.MeshLogic.Transformers;

namespace Prism.Internal.Shared.MeshLogic.Routing
{
    public static class CuratorPhaseRouter
    {
        public static List<IEntityTransformer> Route(string entityType, string curatorRole, string phase)
        {
            var baseTransformers = TransformerRegistry.ResolveBaseTransformers(entityType, curatorRole);

            var phaseSpecific = phase switch
            {
                "Preview" => new List<IEntityTransformer> { new OverlayTransformer() },
                "Annotation" => new List<IEntityTransformer> { new TraitTransformer() },
                "Archival" => new List<IEntityTransformer> { new MoodTransformer(), new TraitTransformer() },
                "LivePlay" => new List<IEntityTransformer> { new MoodTransformer(), new OverlayTransformer() },
                _ => new()
            };

            return baseTransformers.Concat(phaseSpecific).ToList();
        }
    }
}