using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Transformers.Base;

namespace Prism.Shared.Contracts.Transformers
{
    public class TraitTransformer : SessionEntityTransformerBase
    {
        public TraitTransformer() : base(true) { }

        public override string TransformerType => "Trait";

        public override ISessionEntity Transform(ISessionEntity entity, Dictionary<string, object> parameters)
        {
            if (entity is not SessionEntityState state)
                throw new InvalidOperationException("Unsupported entity type.");

            if (!parameters.TryGetValue("Traits", out var traitsObj) || traitsObj is not List<string> traitsToApply)
                throw new ArgumentException("Missing or invalid Traits payload.");

            var existingTraits = state.Metadata.TryGetValue("Traits", out var existingObj) && existingObj is List<string> existingList
                ? new List<string>(existingList)
                : new List<string>();

            foreach (var trait in traitsToApply)
            {
                if (!existingTraits.Contains(trait))
                    existingTraits.Add(trait);
            }

            var updatedMetadata = MergeMetadata(state.Metadata, new()
            {
                { "Traits", existingTraits }
            });

            return new SessionEntityState
            {
                EntityId = state.EntityId,
                EntityType = state.EntityType,
                SessionId = state.SessionId,
                MoodVector = state.MoodVector,
                Metadata = updatedMetadata,
                IsDraft = state.IsDraft,
                Timestamp = GetTimestamp()
            };
        }
    }
    #region TraitTransformer Summary 2025.08.28
    // TraitTransformer applies semantic tags to session-scoped entities.
    // Traits are stored in metadata and used for mesh resonance, curator overlays, and scenario triggers.
    // This transformer supports dynamic trait injection and contributor-safe mutation.
    // It enables narratable consequence, role-sensitive overlays, and legacy-grade emotional logic.
    #endregion

}