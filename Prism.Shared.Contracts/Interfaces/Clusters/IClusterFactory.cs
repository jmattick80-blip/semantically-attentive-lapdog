using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;

namespace Prism.Shared.Contracts.Interfaces.Clusters
{
    public interface IClusterFactory
    {
        ClusterBase CreateCluster(IClusterManifest manifest);
    }
}