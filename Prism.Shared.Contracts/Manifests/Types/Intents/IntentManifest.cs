using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Events;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Interfaces.Routers;

namespace Prism.Shared.Contracts.Manifests.Types.Intents
{
    public class IntentManifest : ManifestBase, IIntentManifest
    {
        public IntentManifest(
            string manifestId,
            string displayName,
            string description,
            List<ITrait> defaultTraits,
            List<string> signalBindings,
            ITraitRouter traitRouter)
            : base(manifestId, displayName, description)
        {
            DefaultTraits = defaultTraits ?? new List<ITrait>();
            SignalBindings = signalBindings ?? new List<string>();
            _traitRouter = traitRouter ?? throw new ArgumentNullException(nameof(traitRouter));
        }

        #region Traits & Signals

        public IEnumerable<ITrait> DefaultTraits { get; set; }
        public IEnumerable<string> SignalBindings { get; set; }

        private readonly ITraitRouter _traitRouter;
        private readonly List<RippleEvent> _rippleHistory = new();
        private string _internalToneState = "Neutral";

        public void ApplyTrait(PrismTrait trait, MeshProfile mesh)
        {
            if (trait == null || mesh == null)
            {
                Console.WriteLine("⚠️ IntentManifest.ApplyTrait received null input.");
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

            Console.WriteLine($"✅ Trait '{trait.TraitName}' routed via TraitRouter and applied to IntentManifest '{ManifestId}' with tone '{trait.Tone}' at {mesh.Timestamp:O}.");
        }

        public void PropagateTraitBundle(IEnumerable<ITrait> traits)
        {
            DefaultTraits = traits?.ToList() ?? new List<ITrait>();
            Console.WriteLine($"📦 Trait bundle propagated to IntentManifest '{ManifestId}' with {DefaultTraits.Count()} traits.");
        }

        public IEnumerable<RippleEvent> GetRippleHistory() => _rippleHistory;
        public string GetToneState() => _internalToneState;

        #endregion

        #region Narration

        public string GetNarrationHint(string signalId)
        {
            return $"{DisplayName} triggered by signal: {signalId} with tone '{_internalToneState}' and {DefaultTraits.Count()} traits.";
        }

        #endregion
    }
}