using GalleryDrivers.Prism.Shared.Envelopes.Base;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Interfaces.Registries;
using GalleryDrivers.Prism.Shared.Interfaces.Session;

namespace GalleryDrivers.Prism.Shared.Routers
{
    public class ManifestRegistryRouter : IManifestRegistryRouter
    {
        public IManifestRegistry<TManifest> Resolve<TManifest>(IntentEnvelope envelope) where TManifest : IManifest
        {
            throw new System.NotImplementedException();
        }
    }
}