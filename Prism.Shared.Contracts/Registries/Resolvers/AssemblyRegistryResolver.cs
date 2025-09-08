using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Manifests.Hydrators;
using Prism.Shared.Contracts.Registries.Resolvers.Base;

namespace Prism.Shared.Contracts.Registries.Resolvers
{
    /// <summary>
    /// Resolver for manifest registries during the assembly phase.
    /// Supports envelope-driven hydration and prefab-safe orchestration.
    /// </summary>
    public class AssemblyRegistryResolver : RegistryResolverBase
    {
        public AssemblyRegistryResolver() : base("assembly") { }

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
            // Example: resolve based on intent type
            return envelope.Intent switch
            {
                SystemIntent.Emotional => new EmotionalManifestHydrator() as IManifestHydrator<TManifest>,
                SystemIntent.Semantic => new SemanticManifestHydrator() as IManifestHydrator<TManifest>,
                SystemIntent.Input => new InputManifestHydrator() as IManifestHydrator<TManifest>,
                _ => new NullManifestHydrator<TManifest>()
            };
        }
    }

    #region AssemblyRegistryResolver – End Summary (Sprint 5 – September 1, 2025)
    /// <summary>
    /// AssemblyRegistryResolver orchestrates manifest hydration and registration during the assembly phase.
    /// It resolves the appropriate IManifestHydrator<TManifest> based on envelope intent,
    /// constructs an AssemblyManifestRegistry<TManifest>, and ensures contributor-safe orchestration.
    ///
    /// This resolver supports prefab-safe routing, emotional mesh activation, and fallback narration.
    /// It is part of Prism OS’s phase-aware registry resolution system.
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