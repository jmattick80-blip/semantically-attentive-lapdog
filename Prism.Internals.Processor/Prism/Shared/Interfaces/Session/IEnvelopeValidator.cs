using GalleryDrivers.Prism.Shared.Envelopes.Base;

namespace GalleryDrivers.Prism.Shared.Interfaces.Session
{
    public interface IEnvelopeValidator
    {
        bool Validate(IntentEnvelope envelope);
    }
}