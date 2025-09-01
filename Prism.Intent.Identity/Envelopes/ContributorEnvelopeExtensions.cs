using GalleryDrivers.Prism.Shared.Enums;
using GalleryDrivers.Prism.Shared.Interfaces.Envelopes;
using Prism.Intent.Identity.Fingerprint;

namespace Prism.Intent.Identity.Envelopes
{
    public static class ContributorEnvelopeExtensions
    {
        /// <summary>
        /// Applies contributor fingerprint data to envelope fields.
        /// </summary>
        public static IEnvelope WithContributor(this IEnvelope envelope, ContributorFingerprint fingerprint)
        {
            envelope.UnityId = fingerprint.ContributorId;
            envelope.Phase = Enum.TryParse<SystemPhase>(fingerprint.Phase, out var parsedPhase)
                ? parsedPhase
                : SystemPhase.Unspecified;

            // Optional: enrich with tone or role via tags or trace context if supported
            return envelope;
        }

        /// <summary>
        /// Retrieves contributor ID from envelope.
        /// </summary>
        public static string GetContributorId(this IEnvelope envelope)
        {
            return envelope.UnityId;
        }
    }

    #region ContributorEnvelopeExtensions Summary (August 31, 2025)
    // ContributorEnvelopeExtensions apply fingerprint data to envelope fields like UnityId and Phase.
    // They align with Prism’s narratable envelope contract and support contributor-safe routing.
    // This stub supports Sprint 2’s empathy layer and prepares Prism for traceable consequence.
    #endregion
}