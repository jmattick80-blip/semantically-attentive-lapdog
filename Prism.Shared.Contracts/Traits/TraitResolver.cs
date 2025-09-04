using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Manifests.Types.Clusters;
using Prism.Shared.Contracts.Manifests.Types.Intents;

namespace Prism.Shared.Contracts.Traits
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

        public static TraitMap Resolve(object transformedTraits)
        {
            throw new NotImplementedException();
        }
    }
}