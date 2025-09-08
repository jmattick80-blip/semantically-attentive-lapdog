using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Traits;

namespace Prism.Shared.Contracts.Sessions
{
    public class SessionEntity : ISessionEntity
    {
        public string EntityId { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public PrismSelectorTypes.EntityType EntityType { get; set; }

        public Dictionary<string, object> Metadata { get; set; } = new  Dictionary<string, object>();
        public Dictionary<string, float> MoodVector { get; set; } = new   Dictionary<string, float>();
        public bool IsDraft { get; set; } = true;

        public List<PrismTrait> Traits { get; set; } = new();
    }
}