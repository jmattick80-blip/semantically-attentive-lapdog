using Prism.Internal.Shared.MeshLogic.Transformers.Base;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Internal.Shared.MeshLogic
{
    public class OverlayTransformer : SessionEntityTransformerBase
    {
        public OverlayTransformer() : base(true) { }
        
        public override string TransformerType => "Overlay";

        public override ISessionEntity Transform(ISessionEntity entity, Dictionary<string, object> parameters)
        {
            if (entity is not SessionEntityState state)
                throw new InvalidOperationException("Unsupported entity type.");

            if (!parameters.TryGetValue("Overlay", out var overlayObj) || overlayObj is not Dictionary<string, object> overlayData)
                throw new ArgumentException("Missing or invalid Overlay payload.");

            var updatedMetadata = MergeMetadata(state.Metadata, new()
            {
                { "Overlay", overlayData }
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
    #region OverlayTransformer 2025.08.28
    // OverlayTransformer applies curator-specific overlays to session-scoped entities.
    // Overlays may include annotations, visual states, contributor flags, or role-sensitive metadata.
    // This transformer supports narratable consequence, curator empowerment, and replayable simulation logic.
    // It enables contributor-safe mutation and legacy-grade visualization across sessions and roles.
    #endregion
}