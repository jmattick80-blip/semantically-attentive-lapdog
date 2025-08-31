using System;
using System.Collections.Generic;

namespace Prism.Shared.Contracts.Interfaces.Sessions
{
    public interface ISessionEntity
    {
        string EntityId { get; }
        string SessionId { get; }
        DateTime Timestamp { get; }

        // Optional hooks
        string EntityType { get; } // e.g. "Exhibit", "NPC", "Zone"
        Dictionary<string, object> Metadata { get; }
        
        // Emotional mesh vector
        Dictionary<string, float> MoodVector { get; }
    }
}