using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Events;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Registries.Base;
using Prism.Shared.Contracts.Registries.Resolvers;

namespace Prism.Shared.Contracts.Registries
{
    /// <summary>
    /// Fallback registry
    /// Hydrates manifest using descriptor-driven strategy and provides narratable hints.
    /// </summary>
    public class PrismManifestRegistry<TManifest> : BaseManifestRegistry<TManifest> where TManifest : IManifest
    {
        private readonly RegistryResolverDescriptor _descriptor;
        private readonly Dictionary<string, string> _toneTags;
        private readonly Dictionary<string, double> _layerWeights;
        private readonly List<RippleEvent> _rippleHistory;
        private readonly IntentEnvelope _intentEnvelope;
        public IntentEnvelope Envelope => _intentEnvelope;

        public PrismManifestRegistry(
            RegistryResolverDescriptor descriptor,
            IntentEnvelope envelope,
            IManifestHydrator<TManifest> hydrator,
            Dictionary<string, string> toneTags = null,
            Dictionary<string, double> layerWeights = null,
            List<RippleEvent> rippleHistory = null)
            : base(envelope, hydrator)
        {
            _descriptor = descriptor ?? throw new ArgumentNullException(nameof(descriptor));
            _toneTags = toneTags ?? new();
            _layerWeights = layerWeights ?? new();
            _rippleHistory = rippleHistory ?? new();
            _intentEnvelope = envelope ?? throw new ArgumentNullException(nameof(envelope));
        }

        public override string GetNarrationHint(string manifestId)
        {
            var baseHint = HasManifest(manifestId)
                ? $"✅ Manifest '{manifestId}' is available via fallback resolver '{_descriptor.StrategyName}'."
                : $"⚠️ No manifest found for ID '{manifestId}'. Fallback strategy: {_descriptor.StrategyName}.";

            var emotionalWeight = _layerWeights.TryGetValue("emotional", out var e) ? e : 0.0;
            var toneSummary = _toneTags.Count > 0 ? string.Join(", ", _toneTags.Keys) : "none";

            return $"{baseHint} Emotional weight: {emotionalWeight:F2}, Tone tags: {toneSummary}.";
        }
        
        public string GetRippleSummary()
        {
            if (_rippleHistory != null && _rippleHistory.Count > 0)
            {
                RippleEvent lastRipple = _rippleHistory[_rippleHistory.Count - 1];
                return "Ripple count: " + _rippleHistory.Count +
                       ", Last ripple: " + lastRipple.RippleType +
                       " at " + lastRipple.EmittedAt.ToString("HH:mm:ss");
            }

            return "No ripple events recorded.";
        }

    }

    #region PrismManifestRegistry – End Summary (Sprint 5 – September 9, 2025)
    /// <summary>
    /// PrismManifestRegistry provides a descriptor-driven fallback for manifest hydration and narratable hints.
    /// It hydrates the manifest using a provided IManifestHydrator<TManifest> and registers it for contributor-safe access.
    /// Emotional context (toneTags, layerWeights, rippleHistory) is preserved for traceability and inspection.
    ///
    /// This registry is used in ambiguous or legacy routing scenarios, ensuring emotional traceability and narratable feedback.
    ///
    /// Related Interfaces:
    /// - IManifest
    /// - IManifestHydrator<TManifest>
    /// - IntentEnvelope
    /// - RegistryResolverDescriptor
    /// - BaseManifestRegistry<TManifest>
    /// - RippleEvent
    /// </summary>
    #endregion
}