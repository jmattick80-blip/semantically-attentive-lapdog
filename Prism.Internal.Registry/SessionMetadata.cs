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