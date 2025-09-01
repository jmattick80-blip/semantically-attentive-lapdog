using System;

namespace Prism.Shared.Contracts.Interfaces.Requests
{
    public class SemanticIntent : ISemanticIntent
    {
        public string IntentType { get; set; } = string.Empty;
        public string SourceId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}