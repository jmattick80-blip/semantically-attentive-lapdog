using System;
using GalleryDrivers.Prism.Shared.Enums;
using GalleryDrivers.Prism.Shared.Interfaces.Envelopes;

namespace GalleryDrivers.Prism.Shared.Envelopes.Base
{
    /// <summary>
    /// Represents a narratable system envelope used for orchestrating runtime state and intent.
    /// This base class is engine-agnostic and safe for serialization, annotation, and replay.
    /// </summary>
    public abstract class PrismSystemEnvelopeBase : IEnvelope
    {
        protected string EnvelopeId { get; set; }
        public string SystemHash { get; protected set; }
        public SystemType Type { get; protected set; }
        public SystemIntent Intent { get; protected set; }
        public SystemPhase Phase { get; protected set; }
        public SystemState State { get; protected set; }
        public string UnityId { get; set; } = string.Empty;
        protected DateTime Timestamp { get; set; } = DateTime.MinValue;

        public virtual string ToNarration() =>
            $"[{Timestamp:HH:mm:ss}] {Type} → {Intent} → {Phase} → {State} → Envelope: {EnvelopeId}";

        protected void InitializeEnvelope(
            string envelopeId,
            SystemType type,
            SystemIntent intent,
            SystemPhase phase,
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
            Phase = phase;
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
}