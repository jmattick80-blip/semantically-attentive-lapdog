using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts
{
    public class SessionEntityState : ISessionEntity
    {
        public string EntityId { get; set; } = string.Empty;       // e.g. "npc_Archivist", "ritual_Threshold"
        public string EntityType { get; set; } = string.Empty;     // e.g. "NPC", "Ritual", "Exhibit", "MeshNode"
        public string SessionId { get; set; } = string.Empty;
        public string SnapshotId { get; set; } = string.Empty;  // Optional reference to a snapshot version
        public int Version { get; set; } = 1;                     // Incremented on each update

        public Dictionary<string, float> MoodVector { get; set; } = new Dictionary<string, float>(); // Emotional state, resonance, etc.
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();  // Curator phase, tags, overlays

        public bool IsDraft { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // ISessionEntity implementation
        string ISessionEntity.EntityId => EntityId;
        string ISessionEntity.EntityType => EntityType;
        Dictionary<string, object> ISessionEntity.Metadata => Metadata;
        public List<string> Traits { get; set; } = new List<string>();
    }
}