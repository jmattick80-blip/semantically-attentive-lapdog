namespace Prism.Intent.Identity.Trace
{
    /// <summary>
    /// Defines the contract for a traceable event within PrismOS.
    /// Used by loggers, replay engines, and emotional mesh hydration.
    /// </summary>
    public interface ITraceEntry
    {
        DateTime Timestamp { get; }
        string Intent { get; }
        string ContributorId { get; }
        string Role { get; }
        string Tone { get; }
        string Phase { get; }
        string Response { get; }
        IReadOnlyList<string> Tags { get; }
    }

    #region ITraceEntry Summary (August 31, 2025)
    // ITraceEntry defines the shape of a traceable moment in Prism’s emotional memory.
    // It supports replayability, semantic tagging, and contributor consequence.
    // This stub scaffolds Sprint 2’s trace mesh and prepares Prism for mesh interpretation.
    #endregion
}