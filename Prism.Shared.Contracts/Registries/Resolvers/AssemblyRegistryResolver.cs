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
    /// Supports envelope-driven hydration and prefab-safe orchestration.
    /// </summary>
    public class AssemblyRegistryResolver : RegistryResolverBase
    {
        private readonly ITraitRouter _traitRouter;

        public AssemblyRegistryResolver(ITraitRouter traitRouter)
        {
            _traitRouter = traitRouter ?? throw new ArgumentNullException(nameof(traitRouter));
        }

        public override IManifestRegistry<TManifest> Resolve<TManifest>(IntentEnvelope envelope)
        {
            var hydrator = ResolveHydrator<TManifest>(envelope);
            return new AssemblyManifestRegistry<TManifest>(envelope, hydrator);
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

    #region AssemblyRegistryResolver – End Summary (Sprint 5 – September 1, 2025)
    /// <summary>
    /// It resolves the appropriate IManifestHydrator<TManifest> based on envelope intent,
    /// constructs an AssemblyManifestRegistry<TManifest>, and ensures contributor-safe orchestration.
    ///
    /// This resolver supports prefab-safe routing, emotional mesh activation, and fallback narration.
    ///
    /// Related Components:
    /// - IntentEnvelope
    /// - IManifestRegistry<TManifest>
    /// - IManifestHydrator<TManifest>
    /// - AssemblyManifestRegistry<TManifest>
    /// - RegistryResolverBase
    /// </summary>
    #endregion
}