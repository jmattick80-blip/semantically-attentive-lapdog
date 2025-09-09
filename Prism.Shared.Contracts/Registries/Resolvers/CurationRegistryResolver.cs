using System;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Manifests.Hydrators;
using Prism.Shared.Contracts.Registries.Resolvers.Base;

namespace Prism.Shared.Contracts.Registries.Resolvers
{
    /// <summary>
    /// Supports envelope-driven hydration and contributor-safe review orchestration.
    /// </summary>
    public class CurationRegistryResolver : RegistryResolverBase
    {
        private readonly ITraitRouter _traitRouter;

        public CurationRegistryResolver(ITraitRouter traitRouter)
        {
            _traitRouter = traitRouter ?? throw new ArgumentNullException(nameof(traitRouter));
        }

        public override IManifestRegistry<TManifest> Resolve<TManifest>(IntentEnvelope envelope)
        {
            var hydrator = ResolveHydrator<TManifest>(envelope);
            return new CurationManifestRegistry<TManifest>(envelope, hydrator);
        }

        public override IManifestRegistry<TManifest> ResolveRegistry<TManifest>(IntentEnvelope envelope)
        {
            return Resolve<TManifest>(envelope);
        }

        public override IManifestHydrator<TManifest> ResolveHydrator<TManifest>(IntentEnvelope envelope)
        {
            if (envelope == null)
                throw new ArgumentNullException(nameof(envelope));

            return envelope.Intent switch
            {
                SystemIntent.Emotional => new EmotionalManifestHydrator() as IManifestHydrator<TManifest>,
                SystemIntent.Semantic  => new SemanticManifestHydrator(_traitRouter)  as IManifestHydrator<TManifest>,
                SystemIntent.Input     => new InputManifestHydrator()     as IManifestHydrator<TManifest>,
                _ => new NullManifestHydrator<TManifest>()
            };
        }
    }

    #region CurationRegistryResolver – End Summary (Sprint 5 – September 1, 2025)
    /// <summary>
    /// CurationRegistryResolver orchestrates emotionally reactive manifest hydration.
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