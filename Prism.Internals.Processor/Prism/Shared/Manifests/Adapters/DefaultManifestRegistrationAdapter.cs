using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Interfaces.Registries;

namespace GalleryDrivers.Prism.Shared.Manifests.Adapters
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