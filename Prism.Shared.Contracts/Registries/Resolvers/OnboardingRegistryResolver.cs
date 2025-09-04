using GalleryDrivers.Prism.Shared.Registries;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Manifests.Hydrators;
using Prism.Shared.Contracts.Registries.Resolvers.Base;

namespace Prism.Shared.Contracts.Registries.Resolvers
{
    /// <summary>
    /// Resolver for manifest registries during the onboarding phase.
    /// Supports envelope-driven hydration and contributor-safe initialization.
    /// </summary>
    public class OnboardingRegistryResolver : RegistryResolverBase
    {
        public OnboardingRegistryResolver() : base("onboarding") { }

        public override IManifestRegistry<TManifest> Resolve<TManifest>(IntentEnvelope envelope)
        {
            var hydrator = ResolveHydrator<TManifest>(envelope);
            return new OnboardingManifestRegistry<TManifest>(envelope, hydrator);
        }

        public override IManifestRegistry<TManifest> ResolveRegistry<TManifest>(IntentEnvelope envelope)
        {
            return Resolve<TManifest>(envelope);
        }

        public override GalleryDrivers.Prism.Shared.Interfaces.Manifests.IManifestHydrator<TManifest> ResolveHydrator<TManifest>(IntentEnvelope envelope)
        {
            return envelope.Intent switch
            {
                SystemIntent.Emotional => new EmotionalManifestHydrator() as GalleryDrivers.Prism.Shared.Interfaces.Manifests.IManifestHydrator<TManifest>,
                SystemIntent.Semantic => new SemanticManifestHydrator() as GalleryDrivers.Prism.Shared.Interfaces.Manifests.IManifestHydrator<TManifest>,
                SystemIntent.Input => new InputManifestHydrator() as GalleryDrivers.Prism.Shared.Interfaces.Manifests.IManifestHydrator<TManifest>,
                _ => new NullManifestHydrator<TManifest>()
            };
        }
    }

    #region OnboardingRegistryResolver – End Summary (Sprint 5 – September 1, 2025)
    /// <summary>
    /// OnboardingRegistryResolver orchestrates emotionally reactive manifest hydration during contributor onboarding.
    /// It resolves the appropriate IManifestHydrator<TManifest> based on envelope intent,
    /// constructs an OnboardingManifestRegistry<TManifest>, and ensures prefab-safe initialization and tone-aware narration.
    ///
    /// This resolver is used when contributors first engage with Prism OS,
    /// ensuring emotional resonance, fallback safety, and traceable consequence from the first interaction.
    ///
    /// Related Components:
    /// - IntentEnvelope
    /// - IManifestRegistry<TManifest>
    /// - IManifestHydrator<TManifest>
    /// - OnboardingManifestRegistry<TManifest>
    /// - RegistryResolverBase
    /// </summary>
    #endregion
}