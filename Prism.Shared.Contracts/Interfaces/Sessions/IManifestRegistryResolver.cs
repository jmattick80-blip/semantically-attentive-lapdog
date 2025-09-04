using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;

namespace Prism.Shared.Contracts.Interfaces.Sessions
{
    /// <summary>
    /// Resolves contributor-safe components for manifest orchestration and hydration.
    /// Supports both registry access and envelope-driven manifest construction.
    /// </summary>
    public interface IManifestRegistryResolver
    {
        /// <summary>
        /// Resolves the appropriate manifest registry for a given intent envelope.
        /// Used for runtime orchestration, inspection, and trait propagation.
        /// </summary>
        /// <typeparam name="TManifest">The manifest type to resolve.</typeparam>
        /// <param name="envelope">The intent envelope to route.</param>
        /// <returns>A manifest registry capable of managing the manifest.</returns>
        IManifestRegistry<TManifest> ResolveRegistry<TManifest>(IntentEnvelope envelope)
            where TManifest : IManifest;

        /// <summary>
        /// Resolves a hydrator capable of constructing a manifest from the given envelope.
        /// Used during envelope hydration and contributor onboarding.
        /// </summary>
        /// <typeparam name="TManifest">The manifest type to hydrate.</typeparam>
        /// <param name="envelope">The intent envelope to hydrate from.</param>
        /// <returns>A hydrator capable of producing a manifest from the envelope.</returns>
        IManifestHydrator<TManifest> ResolveHydrator<TManifest>(IntentEnvelope envelope)
            where TManifest : IManifest;
        
        /// <summary>
        /// Resolves the manifest registry using envelope context.
        /// This is a compatibility alias for ResolveRegistry.
        /// </summary>
        /// <typeparam name="TManifest">The manifest type to resolve.</typeparam>
        /// <param name="envelope">The intent envelope to route.</param>
        /// <returns>A manifest registry capable of managing the manifest.</returns>
        IManifestRegistry<TManifest> Resolve<TManifest>(IntentEnvelope envelope)
            where TManifest : IManifest;

    }
}