using Prism.Intent.Identity.Trace;

namespace Prism.Intent.Interpretation.Models
{
    /// <summary>
    /// Represents a grouped set of trace entries that form an emotional arc or contributor journey.
    /// </summary>
    public class TraceCluster
    {
        /// <summary>
        /// The trace entries that belong to this emotional cluster.
        /// </summary>
        public List<TraceEntry> Entries { get; set; } = new();

        /// <summary>
        /// A summary of tone types present across the cluster.
        /// </summary>
        public string ToneSummary { get; set; } = "Neutral";

        /// <summary>
        /// Optional label for the cluster’s emotional arc (e.g. “Escalation Loop”, “Onboarding Journey”).
        /// </summary>
        public string ClusterLabel { get; set; } = string.Empty;

        /// <summary>
        /// Optional phase marker for where this cluster fits in the contributor lifecycle.
        /// </summary>
        public string Phase { get; set; } = string.Empty;
    }

    #region TraceCluster Summary (August 31, 2025)
    // TraceCluster represents a narratable group of trace entries forming an emotional arc.
    // It supports tone summaries, phase markers, and optional labels for mesh replay and consequence.
    // This scaffolds Sprint 3’s mesh activation layer and prepares Prism for emotional trace clustering.
    #endregion
}