using System.Collections.Generic;
using System.Linq;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;
using GalleryDrivers.Prism.Shared.Manifests.Types.Clusters;
using GalleryDrivers.Prism.Shared.Manifests.Types.Intents;

namespace GalleryDrivers.Prism.Shared.Traits
{
    public static class TraitResolver
    {
        public static bool HasAllTraits(IManifest manifest, IEnumerable<ITrait> traits)
        {
            switch (manifest)
            {
                case ClusterManifest cluster:
                    return traits.All(t => cluster.DefaultTraits.Contains(t));
                case IntentManifest intent:
                    return traits.All(t => intent.DefaultTraits.Contains(t));
                default:
                    return false;
            }
        }
    }
}