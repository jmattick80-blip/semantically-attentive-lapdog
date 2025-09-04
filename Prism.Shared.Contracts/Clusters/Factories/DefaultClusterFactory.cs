using System;
using GalleryDrivers.Prism.Shared.Interfaces.Clusters;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;

namespace Prism.Shared.Contracts.Clusters.Factories
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