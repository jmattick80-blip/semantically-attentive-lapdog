using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Manifests.Types.Clusters;

namespace GalleryDrivers.Prism.Shared.Interfaces.Registries
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