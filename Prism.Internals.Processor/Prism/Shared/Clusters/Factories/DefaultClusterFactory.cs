using System;
using GalleryDrivers.Prism.Shared.Clusters.Base;
using GalleryDrivers.Prism.Shared.Interfaces.Clusters;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;

namespace GalleryDrivers.Prism.Shared.Clusters.Factories
{
    public class DefaultClusterFactory : IClusterFactory
    {
        private readonly Func<IClusterManifest, ClusterBase> _clusterResolver;

        public DefaultClusterFactory(Func<IClusterManifest, ClusterBase> clusterResolver)
        {
            _clusterResolver = clusterResolver;
        }

        public ClusterBase CreateCluster(IClusterManifest manifest)
        {
            return _clusterResolver.Invoke(manifest)
                   ?? throw new InvalidOperationException("No cluster resolver provided.");
        }
    }
}