using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;
using GalleryDrivers.Prism.Shared.Manifests.Base;

namespace GalleryDrivers.Prism.Shared.Manifests.Types.Intents
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