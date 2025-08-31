using Prism.Shared.Contracts;

namespace Prism.Internals.Globals;

public static class GlobalContext
{
    static GlobalContext()
    {
        AdapterRegistry = new Dictionary<string, string>();
        ActiveCurators = new List<string> { PrismConstants.DefaultCuratorPhase };
    }

    public static string? CurrentMeshSnapshotId { get; set; }
    public static Dictionary<string, string> AdapterRegistry { get; set; }
    public static List<string> ActiveCurators { get; set; }
}