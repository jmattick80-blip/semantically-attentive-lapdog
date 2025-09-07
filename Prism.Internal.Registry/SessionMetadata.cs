namespace Prism.Internal.Registry;

public class SessionMetadata
{
    public string SessionId { get; set; }
    public string CuratorId { get; set; }
    public string Phase { get; set; } // e.g. "draft", "committed"
    public string? DraftSnapshotId { get; set; }
    public string? CommittedSnapshotId { get; set; }
    public DateTime LastUpdated { get; set; }
}
#region SessionMetadata Summary (Sprint 5 – September 2025)
// SessionMetadata captures the emotional and operational footprint of a contributor’s session.
// It anchors session identity, curator responsibility, and lifecycle phase (e.g. draft, committed).
// Snapshot IDs support rollback, replay, and traceable governance across multiplayer flows.
// LastUpdated timestamps ensure audit clarity and emotional consequence tracking.
// This class scaffolds Prism’s session commit logic and prepares the registry for prefab-safe consequence routing.
// JM ✦ Prism Architect ✦ Sprint 5
#endregion
