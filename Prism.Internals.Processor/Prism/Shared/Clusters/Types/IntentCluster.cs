using System.Collections.Generic;
using System.Linq;
using GalleryDrivers.Prism.Shared.Clusters.Base;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Manifests.Types.Intents;
using GalleryDrivers.Prism.Shared.Overlays;

namespace GalleryDrivers.Prism.Shared.Clusters.Types
{
    public class IntentCluster : ClusterBase
    {
        public IntentCluster(IClusterManifest manifest) : base(manifest)
        {
        }

        public IEnumerable<IntentManifest> GetIntents() =>
            Children.OfType<IntentManifest>();
    }
}