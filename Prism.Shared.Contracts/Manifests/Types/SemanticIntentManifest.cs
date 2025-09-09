using System;
using System.Collections.Generic;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Events;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Interfaces.Routers;

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

        private readonly ITraitRouter _traitRouter;
        private readonly List<RippleEvent> _rippleHistory = new();
        private string _internalToneState = "Neutral";

        public SemanticIntentManifest(ITraitRouter traitRouter)
        {
            _traitRouter = traitRouter ?? throw new ArgumentNullException(nameof(traitRouter));
        }

        public IEnumerable<ITrait> DefaultTraits => Traits;
        public IEnumerable<string> SignalBindings => Tags;

        public void ApplyTrait(PrismTrait trait, MeshProfile mesh)
        {
            if (trait == null || mesh == null)
            {
                Console.WriteLine("⚠️ SemanticIntentManifest.ApplyTrait received null input.");
                return;
            }

            // 🧠 Route trait through TraitRouter
            _traitRouter.Route(new[] { trait }, this, mesh);

            // 🎨 Update internal tone state
            _internalToneState = trait.Tone;

            // 🌊 Emit ripple for traceability
            _rippleHistory.Add(new RippleEvent
            {
                SourceContributorId = mesh.ContributorId,
                RippleType = "trait.applied",
                EmittedAt = mesh.Timestamp,
                Traits = new List<PrismTrait> { trait }
            });

            Console.WriteLine($"✅ Trait '{trait.TraitName}' routed via TraitRouter and applied to SemanticIntentManifest with tone '{trait.Tone}' at {mesh.Timestamp:O}.");
        }

        public void PropagateTraitBundle(IEnumerable<ITrait> traits)
        {
            Traits.AddRange(traits);
        }

        public string GetNarrationHint(string signalId)
        {
            return $"🧠 Semantic intent '{signalId}' processed with tone '{_internalToneState}' and {Traits.Count} traits.";
        }

        public IEnumerable<RippleEvent> GetRippleHistory() => _rippleHistory;
        public string GetToneState() => _internalToneState;
    }
}