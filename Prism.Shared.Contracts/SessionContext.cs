using System;
using System.Collections;
using System.Collections.Generic;
using Prism.Shared.Contracts.Agents;
using Prism.Shared.Contracts.Events;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts
{
    public class SessionContext : ISessionContext
    {
        public string SessionId { get; set; } = string.Empty;
        public string GalleryId { get; set; } = string.Empty;
        public int GallerySeedNumber { get; set; }
        public string MeshSnapshotId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public string CuratorRole { get; set; } = string.Empty;
        public string ContributorId { get; set; } = string.Empty;
        public Dictionary<string, string> TraitTriggerMap { get; set; } = new  Dictionary<string, string>();
        public MeshProfile MeshProfile { get; set; }
        public List<NpcDefinition> NpcDefinitions { get; set; } = new List<NpcDefinition>();
        public Dictionary<string, string> ToneTags { get; set; } = new Dictionary<string, string>();
        public List<RippleEvent> RippleHistory { get; set; } = new List<RippleEvent>();
        public List<string> Tags { get; set; } = new List<string>();
        public Dictionary<string, float> LayerWeights { get; set; } = new Dictionary<string, float>();

        public class CuratorLogEntry
        {
            public string ContributorId { get; set; }
            public DateTime Timestamp { get; set; }
            public List<string> CommittedEntities { get; set; }
            public Dictionary<string, object> MetadataSnapshot { get; set; }
            public List<NpcDefinition> NpcDefinitions { get; set; } = new List<NpcDefinition>();
        }

        public string ToSummary()
        {
            return $"🧠 Session '{SessionId}' launched by '{ContributorId}' on {CreatedAt:yyyy-MM-dd HH:mm}, status: '{Status}'. Gallery: '{GalleryId}' (seed {GallerySeedNumber}), mesh snapshot: '{MeshSnapshotId}', curator role: '{CuratorRole}'. Trait triggers: {TraitTriggerMap?.Count ?? 0}, NPCs: {NpcDefinitions?.Count ?? 0}.";
        }
    }
}