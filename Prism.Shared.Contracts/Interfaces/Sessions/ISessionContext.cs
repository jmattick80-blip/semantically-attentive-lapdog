using System;
using System.Collections.Generic;

namespace Prism.Shared.Contracts.Interfaces.Sessions
{
    public interface ISessionContext
    {
        string SessionId { get; }
        string GalleryId { get; }
        int GallerySeedNumber { get; }
        string CuratorPhase { get; }
        string MeshSnapshotId { get; }
        DateTime CreatedAt { get; }
        string Status { get; }
        string CuratorRole { get; }
        string ContributorId { get; }
        string Phase { get; }
        Dictionary<string, string> TraitTriggerMap { get; }
        string ToSummary();
    }
}