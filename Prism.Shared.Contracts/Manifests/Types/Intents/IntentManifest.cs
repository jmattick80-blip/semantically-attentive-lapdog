using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Manifests.Types.Intents
{
    public class IntentManifest : ManifestBase, IIntentManifest
    {
        public IntentManifest(
            string manifestId,
            string displayName,
            string description,
            List<ITrait> defaultTraits,
            List<string> signalBindings
        ) : base(manifestId, displayName, description)
        {
            DefaultTraits = defaultTraits ?? new List<ITrait>();
            SignalBindings = signalBindings ?? new List<string>();
        }

        public List<ITrait> DefaultTraits { get; set; }
        IReadOnlyList<string> ITraitBindable.SignalBindings => null;
        IReadOnlyList<ITrait> ITraitBindable.DefaultTraits => null;
        public List<string> SignalBindings { get; set; }

        public void PropagateTraitBundle(IEnumerable<ITrait> traits)
        {
            DefaultTraits = new List<ITrait>(traits);
        }

        public string GetNarrationHint(string signalId)
        {
            return $"{DisplayName} triggered by signal: {signalId}";
        }
    }
}