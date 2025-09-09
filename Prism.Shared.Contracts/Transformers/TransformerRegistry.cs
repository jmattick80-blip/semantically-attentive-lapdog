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
            
            
            return transformers;
        }

        // Legacy fallback
        public static List<IEntityTransformer> ResolveTransformers(PrismSelectorTypes.EntityType entityType, string curatorRole)
        {
            return ResolveBaseTransformers(entityType, curatorRole);
        }
    }

    #region TransformerRegistry Summary 2025.08.28
    // TransformerRegistry resolves IEntityTransformer instances based on entity type and curator role.
    // ResolveBaseTransformers provides foundational transformer sets for mood, trait, and overlay logic.
    // These transformers support narratable consequence, contributor-safe mutation, and multiplayer-safe flows.
    // ResolveTransformers currently routes to the base set, serving as a legacy fallback.
    // Together, these systems enable legacy-grade emotional mesh routing and curator-sensitive overlays across Prism.
    #endregion
}