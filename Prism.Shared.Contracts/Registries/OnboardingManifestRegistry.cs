using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Registries.Base;

namespace Prism.Shared.Contracts.Registries
{
    /// <summary>
    /// OnboardingManifestRegistry manages emotionally reactive manifests during contributor onboarding.
    /// Hydrates from envelope and supports contributor initialization and emotional scaffolding.
    /// </summary>
    public class OnboardingManifestRegistry<TManifest> : BaseManifestRegistry<TManifest> where TManifest : IManifest
    {
        public OnboardingManifestRegistry(SemanticIntentEnvelope envelope, IManifestHydrator<TManifest> hydrator)
            : base(envelope, hydrator) { }

        public override string GetNarrationHint(string manifestId) =>
            HasManifest(manifestId)
                ? $"Manifest '{manifestId}' is ready for contributor onboarding."
                : $"No onboarding manifest found for ID '{manifestId}'. Consider initializing one.";
    }

    #region OnboardingManifestRegistry – End Summary (Sprint 5 – September 1, 2025)
    /// <summary>
    /// OnboardingManifestRegistry orchestrates emotionally reactive manifests during contributor onboarding.
    /// It hydrates from an IntentEnvelope using a provided IManifestHydrator<TManifest>,
    /// registers the manifest for prefab-safe initialization, and provides narratable hints for contributor clarity.
    ///
    /// This registry is used when contributors first engage with Prism OS, ensuring emotional resonance,
    /// fallback safety, and traceable tone scaffolding from the first interaction.
    ///
    /// Related Interfaces:
    /// - IManifest
    /// - IManifestHydrator<TManifest>
    /// - IntentEnvelope
    /// - BaseManifestRegistry<TManifest>
    /// </summary>
    #endregion
}