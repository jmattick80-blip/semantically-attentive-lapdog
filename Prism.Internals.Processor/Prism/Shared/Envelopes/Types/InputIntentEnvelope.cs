
using System;
using GalleryDrivers.Prism.Shared.Enums;
using GalleryDrivers.Prism.Shared.Envelopes.Base;

namespace GalleryDrivers.Prism.Shared.Envelopes.Types
{
    [Serializable]
    public class InputIntentEnvelope : IntentEnvelope
    {
     
        internal void Initialize(
            string intentId,
            string displayName,
            string roleContext,
            string[] tags,
            string unityId,
            SystemType type,
            SystemIntent intent,
            SystemPhase phase,
            SystemState state,
            string envelopeId = null,
            string systemHash = null,
            DateTime? timestamp = null)
        {
            IntentId = intentId;
            DisplayName = displayName;
            RoleContext = roleContext;
            Tags = tags;

            InitializeEnvelope(
                envelopeId: envelopeId,
                type: type,
                intent: intent,
                phase: phase,
                state: state,
                unityId: unityId,
                timestamp: timestamp ?? DateTime.UtcNow,
                systemHash: systemHash
            );
        }

        public override string ToNarration() =>
            $"[{Timestamp:HH:mm:ss}] InputIntent: {DisplayName} → Role: {RoleContext} → Tags: {string.Join(", ", Tags)} → Envelope: {EnvelopeId}";
    }
}