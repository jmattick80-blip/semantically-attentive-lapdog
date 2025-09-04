using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Registries;

namespace Prism.Shared.Contracts.Interfaces.Manifests
{
    public interface IManifestRegistrationAdapter
    {
        IEnumerable<IManifestRegistryBase> DiscoverManifests();
        void Register(IManifestRegistryBase manifest);
    }
}