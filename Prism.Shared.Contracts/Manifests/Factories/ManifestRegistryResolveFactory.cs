using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Registries.Resolvers;

namespace Prism.Shared.Contracts.Manifests.Factories
{
    public class ManifestRegistryResolverFactory : IManifestRegistryResolverFactory
    {
        private readonly Dictionary<string, Func<IManifestRegistryResolver>> _resolverMap;

        public ManifestRegistryResolverFactory()
        {
            _resolverMap = new Dictionary<string, Func<IManifestRegistryResolver>>(StringComparer.OrdinalIgnoreCase)
            {
                { "curation", () => new CurationRegistryResolver() },
                { "assembly", () => new AssemblyRegistryResolver() },
                { "onboarding", () => new OnboardingRegistryResolver() }
                // Contributors can register additional phase-aware resolvers here
            };
        }

        public IManifestRegistryResolver Create(string phase)
        {
            var normalizedPhase = string.IsNullOrWhiteSpace(phase)
                ? "unspecified"
                : phase.Trim().ToLowerInvariant();

            if (_resolverMap.TryGetValue(normalizedPhase, out var factory))
            {
                return factory();
            }

            var fallbackDescriptor = new RegistryResolverDescriptor
            {
                StrategyName = "DefaultRegistryResolver",
                Phase = normalizedPhase,
                FallbackNotes = new List<string>
                {
                    $"No registry resolver registered for '{normalizedPhase}'.",
                    "Using default registry strategy.",
                    "Consider defining a custom resolver to enrich validation and payload mapping."
                }
            };

            return new DefaultRegistryResolver(fallbackDescriptor);
        }

        #region ManifestRegistryResolverFactory – End Summary (August 31, 2025)

        // This factory interprets contributor phase and returns a narratable registry resolver.
        // Each resolver hydrates manifests using the IntentEnvelope and applies emotional context
        // when supported via IEmotionallyReactiveManifest.
        //
        // Contributors can safely register new phase-aware resolvers without modifying orchestration logic.
        // Resolver lookup is phase-normalized to ensure consistency and avoid brittle mappings.
        //
        // If no resolver is found, a DefaultRegistryResolver is returned with fallback narration
        // and descriptor metadata—ensuring simulation continuity and contributor clarity.
        //
        // Related Interfaces:
        // - IManifestRegistryResolver
        // - IManifestRegistry<TManifest>
        // - IntentEnvelope
        // - RegistryResolverDescriptor
        // - PayloadPackage

        #endregion
    }
}