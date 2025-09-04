using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;

namespace Prism.Shared.Contracts.Manifests.Adapters
{
    public class DefaultManifestRegistrationAdapter : IManifestRegistrationAdapter
    {
        public IEnumerable<IManifestRegistryBase> DiscoverManifests()
        {
            throw new System.NotImplementedException();
        }

        public void Register(IManifestRegistryBase manifest)
        {
            throw new System.NotImplementedException();
        }
    }
}