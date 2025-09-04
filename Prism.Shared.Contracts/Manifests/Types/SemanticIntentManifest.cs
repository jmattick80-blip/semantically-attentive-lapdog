using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Manifests.Types
{
    /// <summary>
    /// Represents a semantic intent manifest used for routing, tone interpretation, and contributor onboarding.
    /// </summary>
    public class SemanticIntentManifest : IIntentManifest
    {
        public string ManifestId { get; set; }
        public string DisplayName { get; set; } = "Semantic Intent";
        public string Description { get; set; }
        public bool IsNarratable { get; set; } = true;

        public List<ITrait> Traits { get; set; } = new();
        public List<string> Tags { get; set; } = new();
        public string UnityId { get; set; }

        public IReadOnlyList<ITrait> DefaultTraits => Traits;
        public IReadOnlyList<string> SignalBindings => Tags;

        public void PropagateTraitBundle(IEnumerable<ITrait> traits)
        {
            Traits.AddRange(traits);
        }

        public string GetNarrationHint(string signalId)
        {
            return $"Narration hint for signal '{signalId}' not yet implemented.";
        }
    }
}