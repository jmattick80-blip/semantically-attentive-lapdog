using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Interfaces.Registries;

namespace GalleryDrivers.Prism.Shared.Interfaces.Manifests
{
    public interface IManifestRegistrationAdapter
    {
        IEnumerable<IManifestRegistryBase> DiscoverManifests();
        void Register(IManifestRegistryBase manifest);
    }
}