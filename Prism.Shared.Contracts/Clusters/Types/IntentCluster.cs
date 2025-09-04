using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Manifests.Types.Intents;

namespace Prism.Shared.Contracts.Clusters.Types
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