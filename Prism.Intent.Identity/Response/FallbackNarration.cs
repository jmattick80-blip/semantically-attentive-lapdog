using Prism.Shared.Contracts;

namespace Prism.Intent.Identity.Response
{
    public static class FallbackNarration
    {
        /// <summary>
        /// Provides fallback narration when tone modulation fails or context is ambiguous.
        /// </summary>
        public static string GetDefaultMessage(string intentName)
        {
            return $"We’re here to help. Let’s revisit your request: {intentName}";
        }

        /// <summary>
        /// Provides a gentle fallback when contributor tone is mismatched or missing.
        /// </summary>
        public static PrismResult ApplyFallback(PrismResult original, string intentName)
        {
            var fallback = original.Clone();
            fallback.Feedback = GetDefaultMessage(intentName);
            fallback.Tags.Add("FallbackNarration");
            return fallback;
        }
    }

    #region FallbackNarration Summary (August 31, 2025)
    // FallbackNarration provides gentle, tone-neutral messaging when modulation fails or context is unclear.
    // It ensures Prism responds with empathy even in ambiguous or mismatched scenarios.
    // This stub supports Sprint 2’s emotional safety net and prepares Prism for graceful fallback.
    #endregion
}