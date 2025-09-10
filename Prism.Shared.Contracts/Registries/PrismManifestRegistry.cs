using System;
using System.Collections.Generic;
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

        public PrismManifestRegistry(
            RegistryResolverDescriptor descriptor,
            SemanticIntentEnvelope envelope,
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
                RippleEvent lastRipple = _rippleHistory[_rippleHistory.Count - 1]; // classic indexing
                return $"Ripple count: {_rippleHistory.Count}, Last ripple: {lastRipple.RippleType} at {lastRipple.EmittedAt:HH:mm:ss}";
            }

            return "No ripple events recorded.";
        }
    }

    #region PrismManifestRegistry – Refactored September 10, 2025
    /// <summary>
    /// PrismManifestRegistry provides a descriptor-driven fallback for manifest hydration and narratable hints.
    /// It hydrates the manifest using a provided IManifestHydrator<TManifest> and registers it for contributor-safe access.
    /// Emotional context (toneTags, layerWeights, rippleHistory) is preserved for traceability and inspection.
    ///
    /// Refactor Notes:
    /// • Accepts SemanticIntentEnvelope to preserve emotional context
    /// • Removes redundant envelope field—uses inherited property
    /// • Ensures fallback registry narrates hydration with emotional clarity
    ///
    /// ✦ Maintainer: Jeremy M.
    /// ✦ Last Audited: Sprint 5 – 2025-09-10
    /// </summary>
    #endregion
}