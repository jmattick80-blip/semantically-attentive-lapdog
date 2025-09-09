using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Registries.Resolvers;

namespace Prism.Shared.Contracts.Manifests.Factories
{
    public class ManifestRegistryResolverFactory : IManifestRegistryResolverFactory
    {
        private readonly ITraitRouter _traitRouter;
        private readonly Dictionary<string, Func<IManifestRegistryResolver>> _resolverMap;

        public ManifestRegistryResolverFactory(ITraitRouter traitRouter)
        {
            _traitRouter = traitRouter ?? throw new ArgumentNullException(nameof(traitRouter));

            _resolverMap = new Dictionary<string, Func<IManifestRegistryResolver>>(StringComparer.OrdinalIgnoreCase)
            {
                { "curation", () => new CurationRegistryResolver(_traitRouter) },
                { "assembly", () => new AssemblyRegistryResolver(_traitRouter) },
                { "onboarding", () => new OnboardingRegistryResolver(_traitRouter) }
            };
        }

        public IManifestRegistryResolver Create(string strategy = "default")
        {
            if (_resolverMap.TryGetValue(strategy, out var resolverFactory))
            {
                Console.WriteLine($"🔧 Resolver strategy '{strategy}' selected.");
                return resolverFactory.Invoke();
            }

            var fallbackDescriptor = new RegistryResolverDescriptor
            {
                StrategyName = "DefaultRegistryResolver",
                FallbackNotes = new List<string>
                {
                    "Using default registry strategy.",
                    "Consider defining a custom resolver to enrich validation and payload mapping."
                }
            };

            Console.WriteLine($"⚠️ No resolver found for strategy '{strategy}'. Using fallback.");
            return new DefaultRegistryResolver(fallbackDescriptor, _traitRouter);
        }

        #region ManifestRegistryResolverFactory – End Summary (September 9, 2025)

        // Each resolver hydrates manifests using the IntentEnvelope and applies emotional context
        // via ITraitRouter when supported through IEmotionallyReactiveManifest.
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

        public IManifestRegistryResolver Create()
        {
            var fallbackDescriptor = new RegistryResolverDescriptor
            {
                StrategyName = "DefaultRegistryResolver",
                FallbackNotes = new List<string>
                {
                    "Using default registry strategy.",
                    "Consider defining a custom resolver to enrich validation and payload mapping.",
                    "TraitRouter not injected—default resolver will not support emotional consequence routing."
                }
            };

            return new DefaultRegistryResolver(fallbackDescriptor, _traitRouter);
        }
    }
}