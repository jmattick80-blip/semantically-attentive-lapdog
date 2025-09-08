namespace Prism.Shared.Contracts.Interfaces.Sessions;

public interface IEnvelopeValidatorRegistry
{
    IEnvelopeValidator GetForContext(string contextId);
}