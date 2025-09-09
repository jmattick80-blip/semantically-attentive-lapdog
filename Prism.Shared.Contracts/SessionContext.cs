using System;
using System.Collections.Generic;
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

        public class CuratorLogEntry
        {
            public string ContributorId { get; set; }
            public DateTime Timestamp { get; set; }
            public List<string> CommittedEntities { get; set; }
            public Dictionary<string, object> MetadataSnapshot { get; set; }
        }

        public string ToSummary()
        {
            return $"Session '{SessionId}' by contributor '{ContributorId}', created at {CreatedAt}, status: '{Status}', gallery: '{GalleryId}' (seed {GallerySeedNumber}), curator role: '{CuratorRole}', mesh snapshot: '{MeshSnapshotId}'.";
        }
    }
}