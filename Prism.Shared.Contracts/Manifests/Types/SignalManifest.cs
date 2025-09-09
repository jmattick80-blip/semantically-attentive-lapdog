using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Events;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Manifests.Types
{
    public class SignalManifest : IIntentManifest
    {
        public string ManifestId { get; set; }
        public string DisplayName { get; set; } = "Signal Manifest";
        public string Description { get; }
        public bool IsNarratable { get; }

        private readonly ITraitRouter _traitRouter;
        private readonly List<RippleEvent> _rippleHistory = new();
        private string _internalToneState = "Neutral";

        public SignalManifest(ITraitRouter traitRouter)
        {
            _traitRouter = traitRouter ?? throw new ArgumentNullException(nameof(traitRouter));
        }

        public IEnumerable<string> SignalBindings { get; }

        public void ApplyTrait(PrismTrait trait, MeshProfile mesh)
        {
            if (trait == null || mesh == null)
            {
                Console.WriteLine("⚠️ SignalManifest.ApplyTrait received null input.");
                return;
            }

            // 🧠 Delegate to TraitRouter
            _traitRouter.Route(new[] { trait }, this, mesh);

            // 🌊 Emit ripple for traceability
            _rippleHistory.Add(new RippleEvent
            {
                SourceContributorId = mesh.ContributorId,
                RippleType = "trait.applied",
                EmittedAt = mesh.Timestamp,
                Traits = new List<PrismTrait> { trait }
            });

            // 🎨 Update internal tone state
            _internalToneState = trait.Tone;

            Console.WriteLine($"✅ Trait '{trait.TraitName}' routed via TraitRouter and applied to SignalManifest with tone '{trait.Tone}' at {mesh.Timestamp:O}.");
        }

        public IEnumerable<RippleEvent> GetRippleHistory() => _rippleHistory;
        public string GetToneState() => _internalToneState;

        public string GetNarrationHint(string intentId)
        {
            return $"Signal intent '{intentId}' processed with tone '{_internalToneState}' and {_rippleHistory.Count} ripple events.";
        }

        public IEnumerable<ITrait> DefaultTraits { get; }
    }
}