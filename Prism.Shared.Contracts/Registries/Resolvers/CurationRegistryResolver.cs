using GalleryDrivers.Prism.Shared.Registries;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Manifests.Hydrators;
using Prism.Shared.Contracts.Registries.Resolvers.Base;

namespace Prism.Shared.Contracts.Registries.Resolvers
{
    /// <summary>
    /// Resolver for manifest registries during the curation phase.
    /// Supports envelope-driven hydration and contributor-safe review orchestration.
    /// </summary>
    public class CurationRegistryResolver : RegistryResolverBase
    {
        public CurationRegistryResolver() : base("curation") { }

        public override IManifestRegistry<TManifest> Resolve<TManifest>(IntentEnvelope envelope)
        {
            var hydrator = ResolveHydrator<TManifest>(envelope);
            return new CurationManifestRegistry<TManifest>(envelope, hydrator);
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

    #region CurationRegistryResolver – End Summary (Sprint 5 – September 1, 2025)
    /// <summary>
    /// CurationRegistryResolver orchestrates emotionally reactive manifest hydration during the review phase.
    /// It resolves the appropriate IManifestHydrator<TManifest> based on envelope intent,
    /// constructs a CurationManifestRegistry<TManifest>, and ensures contributor-safe inspection and feedback.
    ///
    /// This resolver supports prefab-safe routing, fallback narration, and emotional traceability
    /// for contributors reviewing system behavior and authored consequence.
    ///
    /// Related Components:
    /// - IntentEnvelope
    /// - IManifestRegistry<TManifest>
    /// - IManifestHydrator<TManifest>
    /// - CurationManifestRegistry<TManifest>
    /// - RegistryResolverBase
    /// </summary>
    #endregion
}