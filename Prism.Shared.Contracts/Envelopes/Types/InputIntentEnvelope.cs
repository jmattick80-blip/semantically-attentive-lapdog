using System;
using Prism.Shared.Contracts.Enums;

namespace Prism.Shared.Contracts.Envelopes.Types
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
                state: state,
                unityId: unityId,
                timestamp: timestamp ?? DateTime.UtcNow,
                systemHash: systemHash
            );
        }

        public override string ToNarration() =>
            $"[{Timestamp:HH:mm:ss}] InputIntent: {DisplayName} → Role: {RoleContext} → Tags: {string.Join(", ", Tags)} → Envelope: {EnvelopeId}";
    }
    #region Summary
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 🧠 Summary Region: InputIntentEnvelope
//
// Represents an intent envelope carrying contributor input metadata.
// Used to route display name, role context, and tags into the simulation mesh,
// enabling prefab-safe narration and contributor-aware feedback.
//
// ┌─────────────────────────────────────────────────────────────────────────┐
// │ Responsibilities                                                       │
// ├─────────────────────────────────────────────────────────────────────────┤
// │ • Store contributor input metadata                                     │
// │ • Initialize envelope with system state and identifiers                │
// │ • Provide narratable output for logging and dashboards                 │
// └─────────────────────────────────────────────────────────────────────────┘
//
// 🔗 Dependencies:
// - IntentEnvelope (base class)
// - SystemType, SystemIntent, SystemState (enums)
//
// 🧩 Emotional Consequence:
// - Enables contributor-aware simulation routing
// - Supports prefab-safe envelope creation and replay
// - Ideal for onboarding flows and UI-driven input capture
//
// ✦ Maintainer: Jeremy M.
// ✦ Last Audited: Sprint 5 – 2025-09-07
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    #endregion
}