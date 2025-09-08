using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Manifests.Hydrators;
using Prism.Shared.Contracts.Registries;
using IHydratorContract = Prism.Shared.Contracts.Interfaces.Manifests.IManifestHydrator<Prism.Shared.Contracts.Interfaces.Manifests.IManifest>;


namespace Prism.Shared.Contracts.Routers
{
    /// <summary>
    /// Resolves phase-aware manifest registries and intent-specific hydrators.
    /// Supports prefab-safe hydration and emotionally reactive orchestration.
    /// </summary>
    public class ManifestRegistryResolver : IManifestRegistryResolver
    {
        private readonly Dictionary<SystemIntent, object> _hydrators;
        private readonly Dictionary<SystemPhase, Func<IntentEnvelope, IHydratorContract, object>> _registryFactories;

        public ManifestRegistryResolver()
        {
            // Register known hydrators keyed by SystemIntent
            _hydrators = new Dictionary<SystemIntent, object>
            {
                { SystemIntent.Emotional, new EmotionalManifestHydrator() },
                { SystemIntent.Semantic, new SemanticManifestHydrator() },
                { SystemIntent.Input, new InputManifestHydrator() }
            };
        }


        public IManifestRegistry<TManifest> Resolve<TManifest>(IntentEnvelope envelope)
            where TManifest : IManifest
            => ResolveRegistry<TManifest>(envelope);

        public IManifestRegistry<TManifest> ResolveRegistry<TManifest>(IntentEnvelope envelope)
            where TManifest : IManifest
        {
            if (envelope == null)
                throw new ArgumentNullException(nameof(envelope));

            var hydrator = ResolveHydrator<TManifest>(envelope);

            IManifestRegistry<TManifest> registry = envelope.Phase switch
            {
                SystemPhase.Onboarding => new OnboardingManifestRegistry<TManifest>(envelope, hydrator),
                SystemPhase.Review => new ReviewManifestRegistry<TManifest>(),
                SystemPhase.Runtime => new RuntimeManifestRegistry<TManifest>(),
                _ => new NullManifestRegistry<TManifest>()
            };

            Console.WriteLine($"📦 Resolved registry for phase: {envelope.Phase}");
            return registry;
        }

        public IManifestHydrator<TManifest> ResolveHydrator<TManifest>(IntentEnvelope envelope)
            where TManifest : IManifest
        {
            if (envelope == null)
                throw new ArgumentNullException(nameof(envelope));

            if (_hydrators.TryGetValue(envelope.Intent, out var hydrator) &&
                hydrator is IManifestHydrator<TManifest> typedHydrator)
            {
                Console.WriteLine($"🧬 Resolved hydrator for intent: {envelope.Intent}");
                return typedHydrator;
            }


            Console.WriteLine($"⚠️ No hydrator found for intent: {envelope.Intent}");
            return new NullManifestHydrator<TManifest>();
        }
    }
}