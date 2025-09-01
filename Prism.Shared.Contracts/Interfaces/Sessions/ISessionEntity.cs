using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Enums;

namespace Prism.Shared.Contracts.Interfaces.Sessions
{
    public interface ISessionEntity
    {
        string EntityId { get; }
        string SessionId { get; }
        DateTime Timestamp { get; }

        // Optional hooks
        PrismSelectorTypes.EntityType EntityType { get; set; }

        Dictionary<string, object> Metadata { get; }
        
        // Emotional mesh vector
        Dictionary<string, float> MoodVector { get; }
    }
}