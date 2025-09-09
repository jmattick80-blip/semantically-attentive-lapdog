using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Fingerprint;

namespace Prism.Shared.Contracts
{
    /// <summary>
    /// Logs contributor intents and Prism responses with emotional mesh consequence.
    /// Supports fingerprint serialization, cluster anchoring, and registry hydration.
    /// </summary>
    public class TraceMeshLogger
    {
        private readonly List<TraceEntry> _entries = new  List<TraceEntry>();
        
        /// <summary>
        /// Logs a routed intent with contributor fingerprint and context.
        /// Includes mesh consequence tags and cluster anchors.
        /// </summary>
        public void LogIntent(string intentName, ContributorFingerprint fingerprint)
        {
            _entries.Add(new TraceEntry
            {
                Timestamp = DateTime.UtcNow,
                Intent = intentName,
                ContributorId = fingerprint.ContributorId,
                Role = fingerprint.Role,
                Tone = fingerprint.Tone.Type.ToString(),
                
                Tags = new List<string>
                {
                    "IntentRouted",
                    $"Tone:{fingerprint.Tone.Type}",
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
    // TraceMeshLogger captures routed intents and Prism responses with emotional mesh consequences.
    // Supports fingerprint serialization, cluster anchoring, and registry hydration.
    #endregion
}