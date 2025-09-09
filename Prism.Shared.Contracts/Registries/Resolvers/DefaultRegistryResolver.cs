using System;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Manifests.Hydrators;
using Prism.Shared.Contracts.Manifests.Types;
using Prism.Shared.Contracts.Registries.Resolvers.Base;

namespace Prism.Shared.Contracts.Registries.Resolvers
{
    /// <summary>
    /// Provides descriptor-driven fallback behavior and narratable hydration.
    /// </summary>
    public class DefaultRegistryResolver : RegistryResolverBase
    {
        private readonly ITraitRouter _traitRouter;

        public DefaultRegistryResolver(RegistryResolverDescriptor descriptor, ITraitRouter traitRouter)
        {
            Descriptor = descriptor ?? throw new ArgumentNullException(nameof(descriptor));
            _traitRouter = traitRouter ?? throw new ArgumentNullException(nameof(traitRouter));
        }

        public override IManifestRegistry<TManifest> Resolve<TManifest>(IntentEnvelope envelope)
        {
            var hydrator = ResolveHydrator<TManifest>(envelope);
            return new PrismManifestRegistry<TManifest>(Descriptor, envelope, hydrator);
        }

        public override IManifestRegistry<TManifest> ResolveRegistry<TManifest>(IntentEnvelope envelope)
        {
            return Resolve<TManifest>(envelope);
        }

        public override IManifestHydrator<TManifest> ResolveHydrator<TManifest>(IntentEnvelope envelope)
        {
            if (envelope == null)
                throw new ArgumentNullException(nameof(envelope));

            var manifestType = typeof(TManifest);
            var intent = envelope.Intent;

            Console.WriteLine($"🧠 Hydrator resolution started");
            Console.WriteLine($"🔍 Intent: {intent}, IntentId: '{envelope.IntentId}'");
            Console.WriteLine($"📦 Manifest type requested: {manifestType.Name}");

            if (typeof(TManifest) == typeof(IIntentManifest))
            {
                var typedHydrator = ResolveIntentManifestHydrator(envelope);
                return (IManifestHydrator<TManifest>)(object)typedHydrator;
            }

            if (intent == SystemIntent.Emotional && manifestType == typeof(IEmotionallyReactiveManifest))
                return new EmotionalManifestHydrator() as IManifestHydrator<TManifest>;

            if (intent == SystemIntent.Input && manifestType == typeof(IInputManifest))
                return new InputManifestHydrator() as IManifestHydrator<TManifest>;

            if (typeof(TManifest) == typeof(IManifest))
            {
                Console.WriteLine($"🚫 Cannot hydrate abstract manifest type '{manifestType.Name}' for intent '{envelope.IntentId}'.");
                Console.WriteLine($"🛡️ Returning NullManifestHydrator to preserve fallback safety.");
                return new NullManifestHydrator<TManifest>();
            }

            Console.WriteLine($"⚠️ No hydrator match for intent '{intent}' and manifest type '{manifestType.Name}'");
            Console.WriteLine($"↪️ Returning NullManifestHydrator for fallback safety");
            return new NullManifestHydrator<TManifest>();
        }

        private IManifestHydrator<IIntentManifest> ResolveIntentManifestHydrator(IntentEnvelope envelope)
        {
            Console.WriteLine($"🧬 Resolved hydrator: {nameof(SemanticManifestHydrator)} for intent '{envelope.IntentId}'");
            return new SemanticManifestHydrator(_traitRouter);
        }
    }
}