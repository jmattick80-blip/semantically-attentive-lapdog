using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Manifests.Types.Intents;

namespace Prism.Shared.Contracts.Clusters.Types
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