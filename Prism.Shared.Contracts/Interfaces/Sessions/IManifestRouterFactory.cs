using Prism.Shared.Contracts.Interfaces.Routers;

namespace Prism.Shared.Contracts.Interfaces.Sessions;

public interface IManifestRouterFactory
{
    IManifestFlowRouter Create(string curatorPhase);
}