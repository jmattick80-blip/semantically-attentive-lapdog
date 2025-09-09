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
            };
        }

        public IManifestRegistryResolver Create()
        {
            
            var fallbackDescriptor = new RegistryResolverDescriptor
            {
                StrategyName = "DefaultRegistryResolver",
                FallbackNotes = new List<string>
                {
                    "Using default registry strategy.",
                    "Consider defining a custom resolver to enrich validation and payload mapping."
                }
            };

            return new DefaultRegistryResolver(fallbackDescriptor);
        }

        #region ManifestRegistryResolverFactory – End Summary (August 31, 2025)
        
        // Each resolver hydrates manifests using the IntentEnvelope and applies emotional context
        // when supported via IEmotionallyReactiveManifest.
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