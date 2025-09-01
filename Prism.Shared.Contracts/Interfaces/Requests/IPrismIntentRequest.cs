using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Interfaces.Requests
{
    public interface IPrismIntentRequest
    {
        Guid RequestId { get; }                         // Hashed fingerprint of the request
        string Slug { get; }                            // Readable identifier (e.g. "exhibit-applydelta-moodshift")
        SemanticIntent Intent { get; }                 // Who + What
        SessionEntity TargetEntity { get; }            // Entity being acted on
        string Verb { get; }                            // Action to perform (e.g. "ApplyDelta", "Commit", "Preview")
        Dictionary<string, object> Payload { get; }     // Optional parameters (e.g. mood deltas, layout edits)
        SessionContext Session { get; }                 // Session scope, contributor ID, phase, etc.
        DateTime Timestamp { get; }                     // When the request was created
    }
}