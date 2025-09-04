using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Interfaces.Manifests;

public interface IManifestRegistryResolverFactory
{
    IManifestRegistryResolver Create(string curatorPhase);
}