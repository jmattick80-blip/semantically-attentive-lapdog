using System.Collections.Generic;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Interfaces.MeshLogic;

namespace Prism.Shared.Contracts.Transformers
{
    public static class TransformerRegistry
    {
        public static List<IEntityTransformer> ResolveBaseTransformers(PrismSelectorTypes.EntityType entityType, string curatorRole)
        {
            var transformers = new List<IEntityTransformer>();

            // Mood is always required
            transformers.Add(new MoodTransformer());

            // Traits may be curator-sensitive
            if (curatorRole == "Archivist" || curatorRole == "Curator")
                transformers.Add(new TraitTransformer());

            // Overlays may be optional unless in annotation phase
            if (entityType == PrismSelectorTypes.EntityType.Exhibit || curatorRole == "Annotator")
                transformers.Add(new OverlayTransformer());

            return transformers;
        }

        // Legacy fallback if phase is not used
        public static List<IEntityTransformer> ResolveTransformers(PrismSelectorTypes.EntityType entityType, string curatorRole)
        {
            return ResolveBaseTransformers(entityType, curatorRole);
        }
    }

    #region TransformerRegistry Summary 2025.08.28
    // TransformerRegistry resolves IEntityTransformer instances based on entity type and curator role.
    // ResolveBaseTransformers provides foundational transformer sets for mood, trait, and overlay logic.
    // These transformers support narratable consequence, contributor-safe mutation, and multiplayer-safe flows.
    // CuratorPhaseRouter may layer phase-specific logic on top of this registry to support session-aware transformation.
    // Together, these systems enable legacy-grade emotional mesh routing and curator-sensitive overlays across Prism.
    #endregion
}