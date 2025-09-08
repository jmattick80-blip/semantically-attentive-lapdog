using System;
using Prism.Shared.Contracts.Enums;

namespace Prism.Shared.Contracts.Envelopes.Types
{
    [Serializable]
    public class EmotionalIntentEnvelope : IntentEnvelope
    {
        public string EmotionalTag { get; internal set; } = string.Empty;
        public int Strength { get; internal set; }
        public float Range { get; internal set; }
        public float DecayRate { get; internal set; }
        public string TraitAffected { get; internal set; } = string.Empty;
        public string EmitterId { get; internal set; } = string.Empty;

        internal void Initialize(
            string emotionalTag,
            int strength,
            float range,
            float decayRate,
            string traitAffected,
            string emitterId,
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
            EmotionalTag = emotionalTag;
            Strength = strength;
            Range = range;
            DecayRate = decayRate;
            TraitAffected = traitAffected;
            EmitterId = emitterId;

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
            $"[{Timestamp:HH:mm:ss}] Emotion: {EmotionalTag} ({Strength}) → Trait: {TraitAffected} → Emitter: {EmitterId} → Range: {Range} → Decay: {DecayRate} → Role: {RoleContext} → Tags: {string.Join(", ", Tags)}";
    }
    #region Summary
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 🧠 Summary Region: EmotionalIntentEnvelope
//
// Represents an intent envelope carrying emotional modulation data.
// Used to propagate emotional tags, trait effects, and ripple parameters
// across the simulation mesh.
//
// ┌─────────────────────────────────────────────────────────────────────────┐
// │ Responsibilities                                                       │
// ├─────────────────────────────────────────────────────────────────────────┤
// │ • Store emotional tag, strength, range, and decay rate                 │
// │ • Target specific traits for emotional consequence                     │
// │ • Identify emitter and contributor context                             │
// │ • Initialize envelope metadata for replay and audit                    │
// └─────────────────────────────────────────────────────────────────────────┘
//
// 🔗 Dependencies:
// - IntentEnvelope (base class)
// - SystemType, SystemIntent, SystemPhase, SystemState (enums)
//
// 🧩 Emotional Consequence:
// - Enables ripple modulation across emotional mesh
// - Supports contributor-aware feedback and trait targeting
// - Prefab-safe and narratable for replay and dashboards
//
// ✦ Maintainer: Jeremy M.
// ✦ Last Audited: Sprint 5 – 2025-09-07
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    #endregion
}