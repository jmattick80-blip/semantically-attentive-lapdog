using GalleryDrivers.Prism.Shared.Enums;
using GalleryDrivers.Prism.Shared.Interfaces.Envelopes;
using Prism.Intent.Identity.Trace;

namespace Prism.Intent.Identity.Envelopes
{
    public static class TraceEnvelopeExtensions
    {
        /// <summary>
        /// Applies trace context to envelope fields.
        /// </summary>
        public static IEnvelope WithTraceContext(this IEnvelope envelope, TraceContext context)
        {
            envelope.UnityId = context.Fingerprint?.ContributorId;
            envelope.Intent = Enum.TryParse<SystemIntent>(context.Intent, out var parsedIntent)
                ? parsedIntent
                : SystemIntent.Unspecified;

            envelope.Phase = Enum.TryParse<SystemPhase>(context.Phase, out var parsedPhase)
                ? parsedPhase
                : SystemPhase.Unspecified;

            return envelope;
        }

        /// <summary>
        /// Retrieves trace intent from envelope.
        /// </summary>
        public static string GetTraceIntent(this IEnvelope envelope)
        {
            return envelope.Intent.ToString();
        }
    }

    #region TraceEnvelopeExtensions Summary (August 31, 2025)
    // TraceEnvelopeExtensions apply trace context to envelope fields like Intent, Phase, and UnityId.
    // They align with Prism’s narratable envelope contract and support emotional trace hydration.
    // This stub supports Sprint 2’s memory layer and prepares Prism for mesh activation.
    #endregion
}