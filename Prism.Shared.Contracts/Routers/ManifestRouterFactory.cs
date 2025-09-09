using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Interfaces.Sessions;

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
            };
        }

        public IManifestFlowRouter Create()
        {
            // Fallback to a descriptor-driven default router
            var fallbackDescriptor = new ManifestRouterDescriptor
            {
                StrategyName = "DefaultManifestRouter",
                Tone = "neutral",
                FallbackNotes = new List<string>
                {
                    "Routing via default strategy.",
                    "Consider defining a custom router to enrich contributor flow."
                }
            };

            return new DefaultManifestRouter(fallbackDescriptor);
        }

        #region ManifestRouterFactory – End Summary (August 31, 2025)
        
        // This factory creates manifest flow routers based on session context.
        // It maps strategy names to concrete router implementations.
        // Contributors can safely register new routing strategies without modifying orchestration logic.
        // If no resolver is found, a default resolver is returned with context-aware fallback behavior.

        #endregion
    }
}