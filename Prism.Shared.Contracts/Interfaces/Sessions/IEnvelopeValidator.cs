using Prism.Shared.Contracts.Envelopes;

namespace Prism.Shared.Contracts.Interfaces.Sessions
{
    public interface IEnvelopeValidator
    {
        bool Validate(IntentEnvelope envelope);
    }
}