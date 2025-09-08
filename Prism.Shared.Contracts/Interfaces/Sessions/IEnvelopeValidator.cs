using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;

namespace Prism.Shared.Contracts.Interfaces.Sessions
{
    public interface IEnvelopeValidator
    {
        bool Validate(IntentEnvelope envelope);
    }
}