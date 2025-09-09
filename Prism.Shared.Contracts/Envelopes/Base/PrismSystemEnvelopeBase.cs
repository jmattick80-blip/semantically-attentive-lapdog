using System;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Interfaces.Envelopes;

namespace Prism.Shared.Contracts.Envelopes.Base
{
    public abstract class PrismSystemEnvelopeBase : IEnvelope
    {
        protected string EnvelopeId { get; set; }
        public string SystemHash { get; protected set; }
        public SystemType Type { get; protected set; }
        public SystemIntent Intent { get; set; }
        public SystemState State { get; protected set; }
        public string UnityId { get; set; } = string.Empty;
        protected DateTime Timestamp { get; set; } = DateTime.MinValue;

        public virtual string ToNarration() =>
            $"[{Timestamp:HH:mm:ss}] {Type} → {Intent} → {State} → Envelope: {EnvelopeId}";

        protected void InitializeEnvelope(
            string envelopeId,
            SystemType type,
            SystemIntent intent,
            SystemState state,
            string unityId,
            DateTime timestamp,
            string systemHash = null)
        {
            EnvelopeId = string.IsNullOrWhiteSpace(envelopeId)
                ? GenerateEnvelopeId(timestamp)
                : envelopeId;

            SystemHash = string.IsNullOrWhiteSpace(systemHash)
                ? GenerateSystemHash(timestamp)
                : systemHash;

            Type = type;
            Intent = intent;
            State = state;
            UnityId = unityId;
            Timestamp = timestamp;
        }

        private string GenerateEnvelopeId(DateTime timestamp)
        {
            var guid = Guid.NewGuid().ToString("N");
            var shortHash = guid.Substring(0, 8);
            return $"{shortHash}-{timestamp:HHmmss}";

        }

        private string GenerateSystemHash(DateTime timestamp)
        {
            var guid = Guid.NewGuid().ToString("N");
            var shortHash = guid.Substring(0, 8);
            return $"{shortHash}-{timestamp:HHmmss}";

        }
    }
    #region Summary
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 🧠 Summary Region: PrismSystemEnvelopeBase
//
// Represents a narratable system envelope used to orchestrate runtime state,
// intent. Engine-agnostic and prefab-safe, this base
// class supports serialization, annotation, and replay across simulation flows.
//
// ┌─────────────────────────────────────────────────────────────────────────┐
// │ Responsibilities                                                       │
// ├─────────────────────────────────────────────────────────────────────────┤
// │ • Store envelope metadata including ID, hash, timestamp                │
// │ • Track system type, intent, and state                          │
// │ • Provide narratable output for logging and contributor feedback       │
// │ • Initialize envelope with fallback ID/hash generation                 │
// └─────────────────────────────────────────────────────────────────────────┘
//
// 🔗 Dependencies:
// - IEnvelope (interface contract)
// - SystemType, SystemIntent, SystemState (enums)
//
// 🧩 Emotional Consequence:
// - Enables traceable system orchestration across runtime flows
// - Supports replay, audit logging, and contributor dashboards
// - Prefab-safe and Unity-compatible
//
// ✦ Maintainer: Jeremy M.
// ✦ Last Audited: Sprint 5 – 2025-09-07
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    #endregion
}