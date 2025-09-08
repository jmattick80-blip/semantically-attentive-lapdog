using System;
using GalleryDrivers.Prism.Shared.Manifests.Types;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Manifests.Types;

namespace Prism.Shared.Contracts.Manifests.Hydrators
{
    /// <summary>
    /// Hydrates an input manifest from an intent envelope.
    /// Used for contributor onboarding, role context interpretation, and tag propagation.
    /// </summary>
    public class InputManifestHydrator : IManifestHydrator<IInputManifest>
    {
        public IInputManifest HydrateFromEnvelope(IntentEnvelope envelope)
        {
            if (envelope == null)
            {
                Console.WriteLine("⚠️ Envelope is null—cannot hydrate input manifest.");
                return null;
            }

            var manifest = new InputManifest
            {
                ManifestId = envelope.IntentId,
                DisplayName = envelope.DisplayName ?? "Unnamed Input",
                RoleContext = envelope.RoleContext ?? "Contributor",
                Tags = envelope.Tags ?? new string[0],
                IsNarratable = true
            };

            Console.WriteLine($"📥 Hydrated input manifest: {manifest.ManifestId}");
            return manifest;
        }
    }
}