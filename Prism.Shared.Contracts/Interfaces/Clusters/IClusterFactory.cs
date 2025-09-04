using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;

namespace GalleryDrivers.Prism.Shared.Interfaces.Clusters
{
    public interface IClusterFactory
    {
        ClusterBase CreateCluster(IClusterManifest manifest);
    }
}