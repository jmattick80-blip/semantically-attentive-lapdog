using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Data;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Manifests.Types;

namespace Prism.Shared.Contracts.Manifests.Hydrators
{
    public class EmotionalManifestHydrator : IManifestHydrator<IEmotionallyReactiveManifest>
    {
        public IEmotionallyReactiveManifest HydrateFromEnvelope(IntentEnvelope envelope)
        {
            if (envelope?.PayloadPackage is not PayloadPackage payload)
            {
                Console.WriteLine("⚠️ Envelope missing payload—cannot hydrate emotionally reactive manifest.");
                return null;
            }

            var manifest = new EmotionallyReactiveManifest
            {
                ManifestId = envelope.IntentId,
                Traits = payload.Traits ?? new List<string>(),
                Overlays = payload.Overlays ?? new List<string>(),
                MoodVector = payload.MoodVector ?? new Dictionary<string, float>()
            };

            Console.WriteLine($"🧠 Hydrated emotionally reactive manifest: {manifest.ManifestId}");
            return manifest;
        }
    }
}