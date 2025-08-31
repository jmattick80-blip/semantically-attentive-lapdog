using GalleryDrivers.Prism.Shared.Manifests.Types.Intents;
using GalleryDrivers.Prism.Shared.Sessions.Types;

namespace GalleryDrivers.Prism.Shared.Interfaces.Envelopes
{
    public interface IIntentEnvelope : IEnvelope
    {
        string IntentId { get; }
        string RoleContext { get; }
        string[] Tags { get; }
        IntentManifest SourceManifest { get; }
        PrismSession Session { get; }
        string ToNarration(); // Optional override
    }
}