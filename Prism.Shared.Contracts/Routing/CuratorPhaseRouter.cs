using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Interfaces.MeshLogic;
using Prism.Shared.Contracts.Transformers;

namespace Prism.Shared.Contracts.Routing
{
    public static class CuratorPhaseRouter
    {
        public static List<IEntityTransformer> Route(
            PrismSelectorTypes.EntityType entityType,
            string curatorRole,
            string phase)
        {
            var baseTransformers = TransformerRegistry.ResolveBaseTransformers(entityType, curatorRole);

            var phaseSpecific = phase switch
            {
                "Preview" => new List<IEntityTransformer> { new OverlayTransformer() },
                "Annotation" => new List<IEntityTransformer> { new TraitTransformer() },
                "Archival" => new List<IEntityTransformer> { new MoodTransformer(), new TraitTransformer() },
                "LivePlay" => new List<IEntityTransformer> { new MoodTransformer(), new OverlayTransformer() },
                _ => new List<IEntityTransformer>()
            };

            return baseTransformers.Concat(phaseSpecific).ToList();
        }
    }

    #region CuratorPhaseRouter Summary 2025.09.01
    // ✅ Summary: CuratorPhaseRouter now uses enum-based entity type routing and phase-specific transformer logic.
    // It combines base transformers with phase-aware overlays and trait scaffolding to support narratable consequence.
    // This router enables prefab-safe mutation, curator-sensitive flows, and emotional mesh activation across phases.
    // JM ✦ Prism Architect ✦ 2025-09-01
    #endregion
}