using System.Collections.Generic;
using System.Linq;
using GalleryDrivers.Prism.Shared.Clusters.Base;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Manifests.Base;
using GalleryDrivers.Prism.Shared.Manifests.Types.Intents;

namespace GalleryDrivers.Prism.Shared.Clusters.Types
{
    public class CoreCluster : ClusterBase
    {
        protected IEnumerable<ManifestBase> ManifestChildren => Children.OfType<ManifestBase>();
        
        public CoreCluster(IClusterManifest manifest) : base(manifest)
        {
            
        }

        public IEnumerable<IntentManifest> GetOnboardingManifests()
        {
            return GetManifestsOfType<IntentManifest>();
        }

        private IEnumerable<T> GetManifestsOfType<T>() where T : ManifestBase
        {
            return ManifestChildren.OfType<T>();
        }
    }
}