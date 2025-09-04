using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Sessions.Session.SessionDependencies;

namespace Prism.Shared.Contracts.Routers
{
    public class ManifestRouterFactory : IManifestRouterFactory
    {
        private readonly Dictionary<string, Func<IManifestFlowRouter>> _routerMap;

        public ManifestRouterFactory()
        {
            _routerMap = new Dictionary<string, Func<IManifestFlowRouter>>
            {
                { "curation", () => new CurationManifestRouter() },
                { "assembly", () => new AssemblyManifestRouter() },
                { "onboarding", () => new OnboardingManifestRouter() }
                // Contributors can register additional phase-aware routers here
            };
        }

        public IManifestFlowRouter Create(string phase)
        {
            if (_routerMap.TryGetValue(phase, out var factory))
            {
                return factory();
            }

            // Fallback to a descriptor-driven default router
            var fallbackDescriptor = new ManifestRouterDescriptor
            {
                StrategyName = "DefaultManifestRouter",
                Phase = string.IsNullOrWhiteSpace(phase) ? "unspecified" : phase,
                Tone = "neutral",
                FallbackNotes = new List<string>
                {
                    $"No phase-specific router was registered for '{phase}'.",
                    "Routing via default strategy.",
                    "Consider defining a custom router to enrich contributor flow."
                }
            };

            return new DefaultManifestRouter(fallbackDescriptor);
        }

        #region ManifestRouterFactory – End Summary (August 31, 2025)

        // This factory interprets contributor phase and returns a narratable manifest resolver.
        // Each resolver reflects the tone, structure, and flow expectations of its phase.
        // Contributors can safely register new routing strategies without modifying orchestration logic.
        // If no resolver is found, a default resolver is returned with context-aware fallback behavior.

        #endregion
    }
}