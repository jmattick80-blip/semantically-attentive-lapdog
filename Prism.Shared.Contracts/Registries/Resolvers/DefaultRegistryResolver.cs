using System;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
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
        public DefaultRegistryResolver(RegistryResolverDescriptor descriptor)
        {
            Descriptor = descriptor;
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

            // 🧠 Zone 1: Diagnostic Trace
            Console.WriteLine($"🧠 Hydrator resolution started");
            Console.WriteLine($"🔍 Intent: {intent}, IntentId: '{envelope.IntentId}'");
            Console.WriteLine($"📦 Manifest type requested: {manifestType.Name}");

            // 🧩 Zone 2: Intent-Type Matching
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
            
            // 🛑 Zone 3: Fallback Narration
            Console.WriteLine($"⚠️ No hydrator match for intent '{intent}' and manifest type '{manifestType.Name}'");
            Console.WriteLine($"↪️ Returning NullManifestHydrator for fallback safety");
            return new NullManifestHydrator<TManifest>();
        }
        
        private IManifestHydrator<IIntentManifest> ResolveIntentManifestHydrator(IntentEnvelope envelope)
        {
            Console.WriteLine($"🧬 Resolved hydrator: {nameof(SemanticManifestHydrator)} for intent '{envelope.IntentId}'");
            return new SemanticManifestHydrator();
        }

    }

    #region DefaultRegistryResolver – End Summary (Sprint 5 – September 1, 2025)
    /// <summary>
    /// It resolves the appropriate IManifestHydrator<TManifest> based on envelope intent,
    /// constructs a PrismManifestRegistry<TManifest>, and ensures contributor-safe hydration and narration.
    ///
    /// This resolver is used in ambiguous, legacy, or recovery scenarios where emotional traceability
    /// and prefab-safe fallback behavior are essential.
    ///
    /// Related Components:
    /// - IntentEnvelope
    /// - RegistryResolverDescriptor
    /// - IManifestRegistry<TManifest>
    /// - IManifestHydrator<TManifest>
    /// - PrismManifestRegistry<TManifest>
    /// - RegistryResolverBase
    /// </summary>
    #endregion
}