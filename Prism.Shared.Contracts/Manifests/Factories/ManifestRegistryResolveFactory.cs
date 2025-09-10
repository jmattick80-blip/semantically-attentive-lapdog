using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Registries.Resolvers;

namespace Prism.Shared.Contracts.Manifests.Factories
{
    public class ManifestRegistryResolverFactory : IManifestRegistryResolverFactory
    {
        private readonly ITraitRouter _traitRouter;

        // Strategy-to-resolver factory map
        private readonly Dictionary<string, Func<IManifestRegistryResolver>> _resolverMap;

        // Cached resolver instances to ensure registry persistence
        private readonly Dictionary<string, IManifestRegistryResolver> _resolverCache;

        public ManifestRegistryResolverFactory(ITraitRouter traitRouter)
        {
            _traitRouter = traitRouter ?? throw new ArgumentNullException(nameof(traitRouter));

            _resolverMap = new Dictionary<string, Func<IManifestRegistryResolver>>(StringComparer.OrdinalIgnoreCase)
            {
                { "curation", () => new CurationRegistryResolver(_traitRouter) },
                { "assembly", () => new AssemblyRegistryResolver(_traitRouter) },
                { "onboarding", () => new OnboardingRegistryResolver(_traitRouter) }
            };

            _resolverCache = new Dictionary<string, IManifestRegistryResolver>(StringComparer.OrdinalIgnoreCase);
        }

        public IManifestRegistryResolver Create(string strategy = "default")
        {
            if (_resolverCache.TryGetValue(strategy, out var cachedResolver))
            {
                Console.WriteLine($"🔁 Cached resolver returned for strategy '{strategy}'.");
                return cachedResolver;
            }

            if (_resolverMap.TryGetValue(strategy, out var resolverFactory))
            {
                var resolver = resolverFactory.Invoke();
                _resolverCache[strategy] = resolver;
                Console.WriteLine($"🔧 Resolver strategy '{strategy}' selected and cached.");

                // Optional: emit registry snapshot for audit
                var envelopeIntent = "manifest-bootstrap"; // Align with bootstrapper
                var registry = resolver.Resolve<IIntentManifest>(new SemanticIntentEnvelope(envelopeIntent, null));
                Console.WriteLine($"📨 Registry resolved using envelope intent: '{envelopeIntent}'");

                var manifestIds = registry.GetManifestIds();
                Console.WriteLine($"📦 Registry snapshot [{strategy}]: {string.Join(", ", manifestIds)}");

                return resolver;
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

            var fallbackResolver = new DefaultRegistryResolver(fallbackDescriptor, _traitRouter);
            _resolverCache[strategy] = fallbackResolver;
            Console.WriteLine($"⚠️ No resolver found for strategy '{strategy}'. Using fallback.");

            return fallbackResolver;
        }

        public IManifestRegistryResolver Create()
        {
            const string defaultStrategy = "default";

            if (_resolverCache.TryGetValue(defaultStrategy, out var cached))
            {
                return cached;
            }

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

            var fallback = new DefaultRegistryResolver(fallbackDescriptor, _traitRouter);
            _resolverCache[defaultStrategy] = fallback;
            return fallback;
        }

        #region ManifestRegistryResolverFactory ✦ Refactored September 10, 2025

        /// <summary>
        /// Provides strategy-based resolver creation for manifest registries, ensuring emotional consequence routing
        /// via ITraitRouter and persistent registry hydration across session lifecycle.
        /// 
        /// ✅ Resolver caching ensures manifests registered during bootstrap remain visible during runtime intent dispatch.
        /// ✅ Registry snapshot logging supports audit traceability and ripple lineage validation.
        /// 
        /// Supported Strategies:
        /// • curation
        /// • assembly
        /// • onboarding
        /// 
        /// Fallback: DefaultRegistryResolver with narratable descriptor metadata.
        /// 
        /// JM ✦ Prism Architect ✦ 2025-09-10
        /// </summary>

        #endregion
    }
}