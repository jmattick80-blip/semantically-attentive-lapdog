namespace Prism.Shared.Contracts.Interfaces.Phase
{
    public interface IPhaseContext
    {
        /// <summary>
        /// Gets the current contributor phase (e.g. Onboarding, Escalation, Reflection).
        /// </summary>
        string GetPhase();

        /// <summary>
        /// Determines whether the current phase requires fallback narration.
        /// </summary>
        bool RequiresFallback();

        /// <summary>
        /// Gets the validation mode appropriate for the current phase.
        /// </summary>
        string GetValidationMode();
    }

    #region IPhaseContext Summary (August 31, 2025)
    // IPhaseContext defines the contract for contributor lifecycle awareness.
    // It enables Prism to adapt validation, fallback, and routing based on contributor phase.
    // This stub supports Sprint 2’s phase-aware empathy layer and prepares Prism for adaptive consequence.
    #endregion
}