using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Registries.Base;
using Prism.Shared.Contracts.Registries.Resolvers;

namespace Prism.Shared.Contracts.Registries
{
    /// <summary>
    /// Fallback registry used when no phase-specific registry is available.
    /// Hydrates manifest using descriptor-driven strategy and provides narratable hints.
    /// </summary>
    public class PrismManifestRegistry<TManifest> : BaseManifestRegistry<TManifest> where TManifest : IManifest
    {
        private readonly RegistryResolverDescriptor _descriptor;

        public PrismManifestRegistry(
            RegistryResolverDescriptor descriptor,
            IntentEnvelope envelope,
            IManifestHydrator<TManifest> hydrator)
            : base(envelope, hydrator)
        {
            _descriptor = descriptor;
        }

        public override string GetNarrationHint(string manifestId) =>
            HasManifest(manifestId)
                ? $"Manifest '{manifestId}' is available via fallback resolver."
                : $"No manifest found for ID '{manifestId}'. Fallback strategy: {_descriptor.StrategyName}.";
    }

    #region PrismManifestRegistry – End Summary (Sprint 5 – September 1, 2025)
    /// <summary>
    /// PrismManifestRegistry provides a descriptor-driven fallback when no phase-specific registry is resolved.
    /// It hydrates the manifest using a provided IManifestHydrator<TManifest> and registers it for contributor-safe access.
    /// This registry is used in ambiguous or legacy routing scenarios, ensuring emotional traceability and narratable feedback.
    ///
    /// Related Interfaces:
    /// - IManifest
    /// - IManifestHydrator<TManifest>
    /// - IntentEnvelope
    /// - RegistryResolverDescriptor
    /// - BaseManifestRegistry<TManifest>
    /// </summary>
    #endregion
}