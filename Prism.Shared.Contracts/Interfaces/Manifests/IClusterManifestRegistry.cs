using System.Collections.Generic;
using Prism.Shared.Contracts.Manifests.Types.Clusters;

namespace Prism.Shared.Contracts.Interfaces.Manifests
{
    public interface IClusterManifestRegistry
    {
        IReadOnlyDictionary<string, ClusterManifest> AssignedClusters { get; }
        IReadOnlyDictionary<string, ClusterManifest> AvailableManifests { get; }

        void RegisterManifest(ClusterManifest manifest, bool isSystemCluster = false);
        bool IsClusterAssigned(string clusterId);
        bool IsSystemCluster(string clusterId);
        IEnumerable<ClusterManifest> GetSystemClusters();
        IEnumerable<ClusterManifest> GetAssignableClusters();
    }
}