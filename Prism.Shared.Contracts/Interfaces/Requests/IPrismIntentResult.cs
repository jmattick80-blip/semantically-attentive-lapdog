using System;
using System.Collections.Generic;

namespace Prism.Shared.Contracts.Interfaces.Requests
{
    public interface IPrismIntentResult
    {
        IPrismIntentRequest Request { get; }            // Original request for traceability
        bool Success { get; }                           // Outcome flag
        string ResultCode { get; }                      // e.g. "signalTriggered", "CommitSuccess", "InvalidSession"
        string Message { get; }                         // Narratable feedback
        Dictionary<string, object> Consequence { get; } // Mesh impact, registry refs, audit trail, etc.
        string Slug { get; }                            // Reversed slug for pairing/debugging
        DateTime Timestamp { get; }                     // When the result was generated
    }
}