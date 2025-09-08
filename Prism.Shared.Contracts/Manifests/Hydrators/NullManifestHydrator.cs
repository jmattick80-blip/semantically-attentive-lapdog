using System;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;

namespace Prism.Shared.Contracts.Manifests.Hydrators
{
    /// <summary>
    /// Fallback hydrator used when no manifest hydrator is available.
    /// Prevents null reference errors and provides narratable feedback.
    /// </summary>
    public class NullManifestHydrator<TManifest> : IManifestHydrator<TManifest> where TManifest : IManifest
    {
        public TManifest HydrateFromEnvelope(IntentEnvelope envelope)
        {
            var manifestType = typeof(TManifest).Name;
            var envelopeId = envelope?.IntentId ?? "unknown";

            Console.WriteLine($"🚫 Null hydrator invoked for manifest type '{manifestType}' and envelope '{envelopeId}'.");
            return default;
        }
    }
}