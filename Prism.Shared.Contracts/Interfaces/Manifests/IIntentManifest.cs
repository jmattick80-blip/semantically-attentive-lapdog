using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Interfaces.Manifests
{
    public interface IIntentManifest : IManifest
    {
        string GetNarrationHint(string signalId); // might have to evolve to take context into account
        IEnumerable<ITrait> DefaultTraits { get; }
        IEnumerable<string> SignalBindings { get; }
        void ApplyTrait(PrismTrait trait, MeshProfile mesh);
    }
}