using System;
using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Manifests.Types;
using Prism.Shared.Contracts.Data;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Manifests.Types;

namespace Prism.Shared.Contracts.Manifests.Hydrators
{
    /// <summary>
    /// Hydrates semantic intent envelopes into contributor-safe intent manifests.
    /// Supports descriptor-driven narration and prefab-safe fallback behavior.
    /// </summary>
    public class SemanticManifestHydrator : IManifestHydrator<IIntentManifest>
    {
        public IIntentManifest HydrateFromEnvelope(IntentEnvelope envelope)
        {
            if (envelope?.PayloadPackage is not { } payload)
            {
                Console.WriteLine("⚠️ Envelope missing payload—cannot hydrate semantic intent manifest.");
                return null;
            }
            
            Console.WriteLine($"🧬 Starting hydration for intentId '{envelope.IntentId}'");

            var manifest = new SemanticIntentManifest
            {
                ManifestId = envelope.IntentId,
                Description = "Hydrated from semantic intent envelope",
                Tags = payload.Traits ?? new List<string>(),
                Traits = envelope.Traits,
                UnityId = envelope.UnityId
            };
            
            Console.WriteLine($"📎 Tags count: {manifest.Tags.Count}, Traits count: {manifest.Traits.Count}");
            
            Console.WriteLine($"✅ Hydrated manifest: {manifest.ManifestId}");


            Console.WriteLine($"📘 Hydrated semantic intent manifest: {manifest.ManifestId}");
            return manifest;
        }
    }
}