using Prism.Intent.Identity.Fingerprint;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Fingerprint;

namespace Prism.Intent.Identity.Trace
{
    /// <summary>
    /// Logs contributor intents and Prism responses with emotional mesh consequence.
    /// Supports fingerprint serialization, cluster anchoring, and registry hydration.
    /// </summary>
    public class TraceMeshLogger
    {
        private readonly List<TraceEntry> _entries = new();
        
        /// <summary>
        /// Logs a routed intent with contributor fingerprint and phase context.
        /// Includes mesh consequence tags and cluster anchors.
        /// </summary>
        public void LogIntent(string intentName, ContributorFingerprint fingerprint, string phase)
        {
            _entries.Add(new TraceEntry
            {
                Timestamp = DateTime.UtcNow,
                Intent = intentName,
                ContributorId = fingerprint.ContributorId,
                Role = fingerprint.Role,
                Tone = fingerprint.Tone.Type.ToString(),
                Phase = phase,
                Tags = new List<string>
                {
                    "IntentRouted",
                    $"Tone:{fingerprint.Tone.Type}",
                    $"PhaseRegistryHint:{phase}",
                    $"MeshConsequence:Pending",
                    "ClusterAnchor"
                },
                Fingerprint = fingerprint.ToString()
            });
        }

        /// <summary>
        /// Logs Prism’s response to an intent, including tone modulation and fallback narration.
        /// Tags response with mesh consequence and emotional routing hints.
        /// </summary>
        public void LogResponse(string intentName, string responseSummary, string toneUsed, IEnumerable<string> tags = null)
        {
            var enrichedTags = tags?.ToList() ?? new List<string>();
            enrichedTags.Add("ResponseLogged");
            enrichedTags.Add($"Tone:{toneUsed}");
            enrichedTags.Add("MeshConsequence:Resolved");

            _entries.Add(new TraceEntry
            {
                Timestamp = DateTime.UtcNow,
                Intent = intentName,
                ContributorId = "System",
                Role = "Responder",
                Tone = toneUsed,
                Phase = "Response",
                Response = responseSummary,
                Tags = enrichedTags
            });
        }

        /// <summary>
        /// Retrieves all trace entries for replay, audit, or emotional mesh hydration.
        /// </summary>
        public IReadOnlyList<TraceEntry> GetTrace() => _entries.AsReadOnly();
    }

    #region TraceMeshLogger Summary (Sprint 4 – August 31, 2025)
    // TraceMeshLogger captures routed intents and Prism responses with emotional mesh consequence.
    // Supports fingerprint serialization, cluster anchoring, phase registry hydration, and tone tagging.
    // Enables replayable trace logs for MeshClusterBuilder and consequence routing in PhaseRegistryHydrator.
    #endregion
}