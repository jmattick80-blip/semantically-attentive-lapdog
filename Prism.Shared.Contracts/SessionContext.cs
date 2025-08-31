using System;
using System.Collections.Generic;

namespace Prism.Shared.Contracts
{
    public class SessionContext
    {
        public string SessionId { get; set; } = string.Empty;
        public string GalleryId { get; set; } = string.Empty;
        public int GallerySeedNumber { get; set; }
        public string CuratorPhase { get; set; } = string.Empty;
        public string MeshSnapshotId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public string CuratorRole { get; set; } = string.Empty;
        public string ContributorId { get; set; } = string.Empty;
        public string Phase { get; set; } = string.Empty; // Optional: alias for CuratorPhase if needed
        public Dictionary<string, string> TraitTriggerMap { get; set; } = new  Dictionary<string, string>();
        
        public class CuratorLogEntry
        {
            public string ContributorId { get; set; }
            public string Phase { get; set; }
            public DateTime Timestamp { get; set; }
            public List<string> CommittedEntities { get; set; }
            public Dictionary<string, object> MetadataSnapshot { get; set; }
        }
    }
}