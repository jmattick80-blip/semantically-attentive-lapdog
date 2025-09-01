using System;
using System.Collections.Generic;

namespace Prism.Shared.Contracts.Fingerprint
{
    public class TraceEntry
    {
        public DateTime Timestamp { get; set; }
        public string Intent { get; set; }
        public string ContributorId { get; set; }
        public string Role { get; set; }
        public string Tone { get; set; }
        public string Phase { get; set; }
        public string Response { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public string Feedback { get; set; }
        public string Fingerprint { get; set; }
    }

    #region TraceEntry Summary (August 31, 2025)
    // TraceEntry represents a single moment in Prism’s emotional memory.
    // It captures contributor identity, tone, phase, and response for trace hydration.
    // This stub supports Sprint 2’s semantic logging and replayable consequence.
    #endregion
}