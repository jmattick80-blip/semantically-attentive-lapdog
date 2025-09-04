using System;
using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Registries.Resolvers.Base
{
    /// <summary>
    /// Base class for envelope-aware registry resolution.
    /// Supports fallback-safe routing, hydrator resolution, and contributor-facing narration.
    /// </summary>
    public abstract class RegistryResolverBase : IManifestRegistryResolver
    {
        protected readonly string Phase;
        protected RegistryResolverDescriptor Descriptor;

        protected RegistryResolverBase(string phase)
        {
            Phase = phase;
            Descriptor = new RegistryResolverDescriptor
            {
                StrategyName = GetType().Name,
                Phase = phase,
                FallbackNotes = new List<string>
                {
                    $"Using registry resolver for phase '{phase}'.",
                    $"Resolver type: {GetType().Name}"
                }
            };
        }

        /// <summary>
        /// Resolves a manifest registry using fallback strategy.
        /// Override in subclasses for phase-specific orchestration.
        /// </summary>
        public virtual IManifestRegistry<TManifest> Resolve<TManifest>(IntentEnvelope envelope)
            where TManifest : IManifest
        {
            var hydrator = ResolveHydrator<TManifest>(envelope);
            Console.WriteLine($"🧭 Fallback registry resolution using strategy: {Descriptor.StrategyName}");
            return new PrismManifestRegistry<TManifest>(Descriptor, envelope, hydrator);
        }

        /// <summary>
        /// Resolves a phase-specific registry.
        /// Must be implemented by subclasses.
        /// </summary>
        public abstract IManifestRegistry<TManifest> ResolveRegistry<TManifest>(IntentEnvelope envelope)
            where TManifest : IManifest;

        /// <summary>
        /// Resolves a manifest hydrator based on envelope context.
        /// Must be implemented by subclasses.
        /// </summary>
        public abstract IManifestHydrator<TManifest> ResolveHydrator<TManifest>(IntentEnvelope envelope)
            where TManifest : IManifest;
    }

    #region RegistryResolverBase – End Summary (Sprint 5 – September 1, 2025)
    /// <summary>
    /// RegistryResolverBase provides envelope-aware fallback logic for manifest registry resolution.
    /// It supports descriptor-driven narration, hydrator injection, and contributor-safe orchestration.
    /// Subclasses must implement phase-specific registry and hydrator resolution strategies.
    ///
    /// This base class ensures that even in ambiguous routing scenarios,
    /// contributors receive emotionally legible feedback and prefab-safe hydration.
    ///
    /// Related Interfaces:
    /// - IManifestRegistryResolver
    /// - IManifestRegistry<TManifest>
    /// - IManifestHydrator<TManifest>
    /// - IntentEnvelope
    /// - RegistryResolverDescriptor
    /// </summary>
    #endregion
}