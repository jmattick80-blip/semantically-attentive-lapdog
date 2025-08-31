using GalleryDrivers.Prism.Shared.Clusters.Base;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;

namespace GalleryDrivers.Prism.Shared.Interfaces.Clusters
{
    public interface IClusterFactory
    {
        ClusterBase CreateCluster(IClusterManifest manifest);
    }
}