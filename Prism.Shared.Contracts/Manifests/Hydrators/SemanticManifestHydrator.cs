using System;
using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Manifests.Types;
using Prism.Shared.Contracts.Data;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Events;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Manifests.Types;

namespace Prism.Shared.Contracts.Manifests.Hydrators
{
    /// <summary>
    /// Hydrates semantic intent envelopes into contributor-safe intent manifests.
    /// Supports descriptor-driven narration, emotional context propagation, and prefab-safe fallback behavior.
    /// </summary>
    public class SemanticManifestHydrator : IManifestHydrator<IIntentManifest>
    {
        private readonly ITraitRouter _traitRouter;

        public SemanticManifestHydrator(ITraitRouter traitRouter)
        {
            _traitRouter = traitRouter ?? throw new ArgumentNullException(nameof(traitRouter));
        }

        public IIntentManifest HydrateFromEnvelope(IntentEnvelope envelope)
        {
            if (envelope?.PayloadPackage is not { } payload)
            {
                Console.WriteLine("⚠️ Envelope missing payload—cannot hydrate semantic intent manifest.");
                return null;
            }

            Console.WriteLine($"🧬 Starting hydration for intentId '{envelope.IntentId}'");

            var manifest = new SemanticIntentManifest(_traitRouter)
            {
                ManifestId = envelope.IntentId,
                Description = "Hydrated from semantic intent envelope",
                Tags = payload.Traits ?? new List<string>(),
                Traits = envelope.Traits,
                UnityId = envelope.UnityId
            };

            // Optional: propagate emotional context if present
            if (envelope.ToneTags is { Count: > 0 })
            {
                Console.WriteLine($"🎨 Tone tags detected: {string.Join(", ", envelope.ToneTags.Keys)}");
            }

            if (envelope.LayerWeights is { Count: > 0 } and { Count: > 0 })
            {
                envelope.LayerWeights.TryGetValue("emotional", out var emotional);
                envelope.LayerWeights.TryGetValue("narrative", out var narrative);
                envelope.LayerWeights.TryGetValue("technical", out var technical);

                Console.WriteLine($"📊 Layer weights detected: emotional={emotional}, narrative={narrative}, technical={technical}");
            }

            if (envelope.RippleHistory is { Count: > 0 })
            {
                Console.WriteLine($"🌊 Ripple history detected: {envelope.RippleHistory.Count} entries");
            }

            Console.WriteLine($"📎 Tags count: {manifest.Tags.Count}, Traits count: {manifest.Traits.Count}");
            Console.WriteLine($"✅ Hydrated manifest: {manifest.ManifestId}");

            return manifest;
        }
    }
}