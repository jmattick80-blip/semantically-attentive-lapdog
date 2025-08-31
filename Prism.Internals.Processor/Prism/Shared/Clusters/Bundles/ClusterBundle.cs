using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Manifests.Types.Clusters;
using GalleryDrivers.Prism.Shared.Manifests.Types.Intents;

namespace GalleryDrivers.Prism.Shared.Clusters.Bundles
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