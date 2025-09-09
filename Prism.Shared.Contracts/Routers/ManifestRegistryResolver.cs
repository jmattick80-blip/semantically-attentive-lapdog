using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Manifests.Hydrators;
using Prism.Shared.Contracts.Registries;
using IHydratorContract = Prism.Shared.Contracts.Interfaces.Manifests.IManifestHydrator<Prism.Shared.Contracts.Interfaces.Manifests.IManifest>;

namespace Prism.Shared.Contracts.Routers
{
    /// <summary>
    /// Supports prefab-safe hydration and emotionally reactive orchestration.
    /// </summary>
    public class ManifestRegistryResolver : IManifestRegistryResolver
    {
        private readonly Dictionary<SystemIntent, object> _hydrators;
        private readonly ITraitRouter _traitRouter;

        public ManifestRegistryResolver(ITraitRouter traitRouter)
        {
            _traitRouter = traitRouter ?? throw new ArgumentNullException(nameof(traitRouter));

            // Register known hydrators keyed by SystemIntent
            _hydrators = new Dictionary<SystemIntent, object>
            {
                { SystemIntent.Emotional, new EmotionalManifestHydrator() },
                { SystemIntent.Semantic, new SemanticManifestHydrator(_traitRouter) },
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

            if (hydrator is IManifestRegistry<TManifest> registry)
            {
                Console.WriteLine($"✅ Registry resolved for intent: {envelope.Intent}");
                return registry;
            }

            Console.WriteLine($"⚠️ Hydrator for intent '{envelope.Intent}' does not implement IManifestRegistry<{typeof(TManifest).Name}>");
            return null;
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