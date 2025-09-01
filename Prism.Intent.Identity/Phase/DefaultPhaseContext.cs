namespace Prism.Intent.Identity.Phase
{
    public class DefaultPhaseContext : IPhaseContext
    {
        public string GetPhase() => "Onboarding";
        public bool RequiresFallback() => true;
        public string GetValidationMode() => "Gentle";
    }

    #region DefaultPhaseContext Summary (August 31, 2025)
    // DefaultPhaseContext provides a static phase model for testing and onboarding flows.
    // It returns "Onboarding" with gentle validation and fallback enabled.
    // This stub supports Sprint 2’s emotional scaffolding and contributor-safe testing.
    #endregion
}