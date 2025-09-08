using Prism.Shared.Contracts.Envelopes.Types;

namespace Prism.Shared.Contracts.Interfaces.Manifests
{
    public interface IManifestHydrator<TManifest> where TManifest : IManifest
    {
        TManifest HydrateFromEnvelope(IntentEnvelope envelope);
    }
}