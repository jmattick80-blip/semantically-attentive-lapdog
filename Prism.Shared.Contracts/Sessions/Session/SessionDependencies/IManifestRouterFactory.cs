using Prism.Shared.Contracts.Interfaces.Routers;

namespace Prism.Shared.Contracts.Sessions.Session.SessionDependencies;

public interface IManifestRouterFactory
{
    IManifestFlowRouter Create(string curatorPhase);
}