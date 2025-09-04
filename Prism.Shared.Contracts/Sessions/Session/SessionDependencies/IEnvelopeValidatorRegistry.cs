using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Sessions.Session.SessionDependencies;

public interface IEnvelopeValidatorRegistry
{
    IEnvelopeValidator GetForContext(string contextId);
}