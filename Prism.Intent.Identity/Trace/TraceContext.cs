using Prism.Intent.Identity.Fingerprint;

namespace Prism.Intent.Identity.Trace
{
    /// <summary>
    /// Represents the contextual metadata for a traceable interaction.
    /// Used to hydrate trace entries and modulate emotional mesh behavior.
    /// </summary>
    public class TraceContext
    {
        public string Intent { get; set; }
        public ContributorFingerprint Fingerprint { get; set; }
        public string Phase { get; set; }
        public string Response { get; set; }
        public List<string> Tags { get; set; } = new();

        public TraceContext(string intent, ContributorFingerprint fingerprint, string phase, string response)
        {
            Intent = intent;
            Fingerprint = fingerprint;
            Phase = phase;
            Response = response;
        }

        public override string ToString()
        {
            return $"{Intent} by {Fingerprint?.ContributorId} in phase {Phase}";
        }
    }

    #region TraceContext Summary (August 31, 2025)
    // TraceContext encapsulates contributor identity, phase, and semantic consequence for a traceable interaction.
    // It is used to hydrate trace entries and scaffold emotional mesh behavior.
    // This stub supports Sprint 2’s memory layer and prepares Prism for tone-aware replay.
    #endregion
}