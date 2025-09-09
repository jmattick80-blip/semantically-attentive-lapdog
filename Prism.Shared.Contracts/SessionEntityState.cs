using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.MoodProfiles;
using Prism.Shared.Contracts.Enums;

namespace Prism.Shared.Contracts
{
    public class SessionEntityState : ISessionEntity
    {
        public string EntityId { get; set; } = string.Empty;       // e.g. "npc_Archivist", "ritual_Threshold"
        public PrismSelectorTypes.EntityType EntityType { get; set; } = PrismSelectorTypes.EntityType.Unknown; // ✅ Now enum-based
        public string SessionId { get; set; } = string.Empty;
        public string SnapshotId { get; set; } = string.Empty;     // Optional reference to a snapshot version
        public int Version { get; set; } = 1;                      // Incremented on each update

        public Dictionary<string, float> MoodVector { get; set; } = new Dictionary<string, float>(); // Emotional state, resonance, etc.
        public Dictionary<string, object> Metadata { get; set; } =new Dictionary<string, object>();  // tags, overlays

        public bool IsDraft { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public List<string> Traits { get; set; } = new List<string>();          // Traits scaffolded at resolve
        public MoodProfile MoodProfile { get; set; } = new MoodProfile();      // Emotional contract

        // ISessionEntity implementation
        string ISessionEntity.EntityId => EntityId;
        PrismSelectorTypes.EntityType ISessionEntity.EntityType
        {
            get => EntityType; // ✅ Correct type
            set => EntityType = value;
        }

        // ✅ Preserves compatibility with string-based consumers
        Dictionary<string, object> ISessionEntity.Metadata => Metadata;
    }
}