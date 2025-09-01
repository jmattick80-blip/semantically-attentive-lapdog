using Prism.Intent.Identity.Fingerprint;
using Prism.Intent.Interpretation.Memory;
using System.Collections.Generic;
using System.Linq;
using Prism.Intent.Identity.Trace;
using Prism.Intent.Interpretation.Models;

namespace Prism.Intent.Interpretation.Trace
{
    /// <summary>
    /// Groups contributor trace entries into emotional clusters for mesh activation and replay.
    /// </summary>
    public class MeshClusterBuilder
    {
        /// <summary>
        /// Builds emotional clusters from contributor trace log.
        /// </summary>
        public List<TraceCluster> BuildClusters(string contributorId, ContributorMemoryStore memory)
        {
            var traceLog = memory.GetTraceLog(contributorId);
            var toneHistory = memory.GetToneHistory(contributorId);

            if (traceLog.Count == 0)
                return new List<TraceCluster>();

            var clusters = new List<TraceCluster>();
            var currentCluster = new TraceCluster();

            foreach (var entry in traceLog)
            {
                if (IsClusterBoundary(entry))
                {
                    if (currentCluster.Entries.Count > 0)
                        clusters.Add(currentCluster);

                    currentCluster = new TraceCluster();
                }

                currentCluster.Entries.Add(entry);
            }

            if (currentCluster.Entries.Count > 0)
                clusters.Add(currentCluster);

            // Optional: annotate clusters with tone summaries
            AnnotateClustersWithTone(clusters, toneHistory);

            return clusters;
        }

        private bool IsClusterBoundary(TraceEntry entry)
        {
            return entry.Tags.Any(tag =>
                tag.Contains("Phase:Start") ||
                tag.Contains("Escalation") ||
                tag.Contains("Narration:Onboarding"));
        }

        private void AnnotateClustersWithTone(List<TraceCluster> clusters, List<FingerprintTone> toneHistory)
        {
            foreach (var cluster in clusters)
            {
                var tones = cluster.Entries
                    .SelectMany(e => e.Tags)
                    .Where(t => t.StartsWith("Tone:"))
                    .Select(t => t.Replace("Tone:", ""))
                    .Distinct()
                    .ToList();

                cluster.ToneSummary = tones.Count > 0
                    ? string.Join(", ", tones)
                    : "Neutral";
            }
        }
    }

    #region MeshClusterBuilder Summary (August 31, 2025)
    // MeshClusterBuilder groups contributor trace entries into emotional clusters.
    // It identifies boundaries based on tags and annotates clusters with tone summaries.
    // This scaffolds Sprint 3’s mesh activation layer and prepares Prism for replayable consequence.
    #endregion
}