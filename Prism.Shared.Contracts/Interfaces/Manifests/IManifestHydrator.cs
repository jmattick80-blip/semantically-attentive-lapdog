using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Interfaces.Manifests;

namespace GalleryDrivers.Prism.Shared.Interfaces.Manifests
{
    public interface IManifestHydrator<TManifest> where TManifest : IManifest
    {
        TManifest HydrateFromEnvelope(IntentEnvelope envelope);
    }
}