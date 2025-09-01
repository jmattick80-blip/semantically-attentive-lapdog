using Prism.Shared.Contracts;
using Prism.Intent.Interpretation.Models;

namespace Prism.Intent.Interpretation.Trace
{
    public class MeshReplayEngine
    {
        /// <summary>
        /// Replays a trace cluster and generates a narratable PrismResult.
        /// </summary>
        public PrismResult ReplayCluster(TraceCluster cluster)
        {
            var feedbackLines = new List<string>();

            foreach (var entry in cluster.Entries)
            {
                feedbackLines.Add(entry.Feedback);
            }

            var summary = $"Replay of cluster [{cluster.ClusterLabel}] with tone: {cluster.ToneSummary}";
            var feedback = $"{summary}\n" + string.Join("\n", feedbackLines);

            return new PrismResult(feedback)
            {
                Tags = new List<string>
                {
                    $"ReplayCluster:{cluster.ClusterLabel}",
                    $"ToneSummary:{cluster.ToneSummary}",
                    $"Phase:{cluster.Phase}"
                }
            };
        }

        /// <summary>
        /// Replays multiple clusters and returns a composite PrismResult.
        /// </summary>
        public PrismResult ReplayAll(List<TraceCluster> clusters)
        {
            var allFeedback = new List<string>();

            foreach (var cluster in clusters)
            {
                var replay = ReplayCluster(cluster);
                allFeedback.Add(replay.Feedback);
            }

            return new PrismResult(string.Join("\n\n", allFeedback))
            {
                Tags = new List<string> { "Replay:AllClusters" }
            };
        }
    }

    #region MeshReplayEngine Summary (August 31, 2025)
    // MeshReplayEngine replays emotional trace clusters with narratable consequences.
    // It supports contributor reflection, NPC behavior shaping, and simulation-wide modulation.
    // This scaffolds Sprint 3’s memory loop and prepares Prism for legacy-grade replayability.
    #endregion
}