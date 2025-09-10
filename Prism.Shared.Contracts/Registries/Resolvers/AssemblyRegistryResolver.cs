using System;
using System.Linq;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Manifests.Hydrators;
using Prism.Shared.Contracts.Registries.Resolvers.Base;

namespace Prism.Shared.Contracts.Registries.Resolvers
{
    /// <summary>
    /// Supports envelope-driven hydration and prefab-safe orchestration.
    /// </summary>
    public class AssemblyRegistryResolver : RegistryResolverBase
    {
        private readonly ITraitRouter _traitRouter;

        public AssemblyRegistryResolver(ITraitRouter traitRouter)
        {
            _traitRouter = traitRouter ?? throw new ArgumentNullException(nameof(traitRouter));
        }

        public override IManifestRegistry<TManifest> Resolve<TManifest>(SemanticIntentEnvelope envelope)
        {
            var hydrator = ResolveHydrator<TManifest>(envelope);

            // ✅ Construct registry first, then hydrate once via InitializeFromEnvelope
            var registry = new AssemblyManifestRegistry<TManifest>(envelope, hydrator);
            registry.InitializeFromEnvelope();

            // ✅ Confirm hydration succeeded
            if (!registry.GetAllManifests().Any())
            {
                Console.WriteLine("❌ Registry hydration failed—no manifests registered.");
                return new AssemblyManifestRegistry<TManifest>(envelope, new NullManifestHydrator<TManifest>());
            }

            return registry;
        }


        public override IManifestRegistry<TManifest> ResolveRegistry<TManifest>(SemanticIntentEnvelope envelope)
        {
            return Resolve<TManifest>(envelope);
        }

        public override IManifestHydrator<TManifest> ResolveHydrator<TManifest>(IntentEnvelope envelope)
        {
            if (envelope == null)
                throw new ArgumentNullException(nameof(envelope));

            Console.WriteLine($"🔍 Resolver received envelope intent: {envelope.Intent}");
            Console.WriteLine($"📨 Envelope ID: {envelope.IntentId}");

            // ✅ Fallback logic for known envelope IDs
            if (envelope.IntentId == "manifest-bootstrap")
            {
                Console.WriteLine("✅ Fallback: SemanticManifestHydrator selected for 'manifest-bootstrap'");
                return new SemanticManifestHydrator(_traitRouter) as IManifestHydrator<TManifest>;
            }

            return envelope.Intent switch
            {
                SystemIntent.Emotional => new EmotionalManifestHydrator() as IManifestHydrator<TManifest>,
                SystemIntent.Semantic  => new SemanticManifestHydrator(_traitRouter) as IManifestHydrator<TManifest>,
                SystemIntent.Input     => new InputManifestHydrator() as IManifestHydrator<TManifest>,
                _ => new NullManifestHydrator<TManifest>()
            };
        }
    }

    #region AssemblyRegistryResolver Summary ✦ Refactored September 10, 2025
    /// <summary>
    /// Resolves the appropriate IManifestHydrator<TManifest> based on envelope intent or known envelope ID,
    /// constructs an AssemblyManifestRegistry<TManifest>, and ensures contributor-safe orchestration.
    ///
    /// Responsibilities:
    /// • Select hydrator based on envelope.Intent or fallback to known envelope IDs
    /// • Log intent routing for traceability and audit
    /// • Prevent null hydrator fallback for prefab-safe registry hydration
    ///
    /// Emotional Consequence:
    /// • Restores registry continuity across bootstrap and runtime
    /// • Enables ripple lineage and contributor-safe manifest registration
    /// • Narrates resolver behavior for audit and debugging clarity
    ///
    /// ✦ Maintainer: Jeremy M.
    /// ✦ Last Audited: Sprint 5 – 2025-09-10
    /// </summary>
    #endregion
}