using System.Collections.Generic;
using Prism.Shared.Contracts.Manifests.Types.Clusters;
using Prism.Shared.Contracts.Manifests.Types.Intents;

namespace Prism.Shared.Contracts.Clusters.Bundles
{
    public class ClusterBundle
    {
        public ClusterManifest ClusterManifest;
        public List<IntentManifest> Intents;

        public ClusterBundle(ClusterManifest clusterManifest, List<IntentManifest> intents)
        {
            ClusterManifest = clusterManifest;
            Intents = intents;
        }
    }
}