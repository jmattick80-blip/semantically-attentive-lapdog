using System;

namespace Prism.Shared.Contracts.Interfaces.Requests
{
    public interface ISemanticIntent
    {
        string IntentType { get; } // e.g. "MoodShift", "NPCCommand", "LayoutEdit"
        string SourceId { get; }   // Who or what triggered it
        DateTime Timestamp { get; }
    }
}