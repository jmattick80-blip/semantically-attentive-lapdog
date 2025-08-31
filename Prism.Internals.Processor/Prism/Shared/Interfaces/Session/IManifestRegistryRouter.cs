using GalleryDrivers.Prism.Shared.Envelopes.Base;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Interfaces.Registries;

namespace GalleryDrivers.Prism.Shared.Interfaces.Session
{
    public interface IManifestRegistryRouter
    {
        /// <summary>
        /// Resolves the appropriate manifest registry for a given intent envelope.
        /// </summary>
        /// <typeparam name="TManifest">The manifest type to resolve.</typeparam>
        /// <param name="envelope">The intent envelope to route.</param>
        /// <returns>A manifest registry capable of processing the envelope.</returns>
        IManifestRegistry<TManifest> Resolve<TManifest>(IntentEnvelope envelope) where TManifest : IManifest;
    }
}