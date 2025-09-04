using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Interfaces.Envelopes;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Envelopes.Types
{
    /// <summary>
    /// Represents the outcome of an intent resolution.
    /// Contains narration, traits, errors, and contextual metadata.
    /// </summary>
    public class ResultsEnvelope : IEnvelopeResults
    {
        public string Narration { get; }
        public IEnumerable<ITrait> Traits { get; }
        public IEnumerable<string> Errors { get; }
        public IManifest Manifest { get; }
        public ISessionContext Session { get; }
        public object Payload { get; }

        private ResultsEnvelope(
            string narration,
            IEnumerable<ITrait> traits,
            IEnumerable<string> errors,
            IManifest manifest,
            ISessionContext session,
            object payload)
        {
            Narration = narration ?? "No narration provided.";
            Traits = traits ?? new List<ITrait>();
            Errors = errors ?? new List<string>();
            Manifest = manifest;
            Session = session;
            Payload = payload;
        }

        /// <summary>
        /// Creates a successful envelope with narration and traits.
        /// </summary>
        public static ResultsEnvelope Success(
            string narration,
            IEnumerable<ITrait> traits,
            IManifest manifest,
            ISessionContext session,
            object payload = null)
        {
            return new ResultsEnvelope(narration, traits, null, manifest, session, payload);
        }

        /// <summary>
        /// Creates a failure envelope with narration and error messages.
        /// </summary>
        public static ResultsEnvelope Failure(
            string narration,
            IEnumerable<string> errors,
            ISessionContext session = null,
            object payload = null)
        {
            return new ResultsEnvelope(narration, new List<ITrait>(), errors, null, session, payload);
        }

        /// <summary>
        /// Creates a failure envelope with traits and errors.
        /// </summary>
        public static ResultsEnvelope FailureWithTraits(
            string narration,
            IEnumerable<ITrait> traits,
            IEnumerable<string> errors,
            IManifest manifest = null,
            ISessionContext session = null,
            object payload = null)
        {
            return new ResultsEnvelope(narration, traits, errors, manifest, session, payload);
        }

        /// <summary>
        /// Returns a narratable summary of the envelope.
        /// </summary>
        public string ToSummary()
        {
            var manifestId = Manifest?.ManifestId ?? "unknown";
            var sessionSummary = Session?.ToSummary() ?? "no session";
            var errorCount = Errors?.Count() ?? 0;
            var traitCount = Traits?.Count() ?? 0;

            return $"📦 Envelope Summary: Manifest='{manifestId}', Traits={traitCount}, Errors={errorCount}, Session={sessionSummary}";
        }
    }
}