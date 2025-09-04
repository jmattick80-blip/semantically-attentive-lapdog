using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Interfaces.Manifests
{
    public interface IIntentManifest : IManifest, ITraitBindable
    {
        string GetNarrationHint(string signalId); // might have to evolve to take context into account
    }
}