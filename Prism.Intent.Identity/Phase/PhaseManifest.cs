namespace Prism.Intent.Identity.Phase
{
    public class PhaseManifest
    {
        /// <summary>
        /// The name of the registry or validation context being hydrated.
        /// </summary>
        public string RegistryName { get; set; }

        /// <summary>
        /// The validation mode to apply (e.g. Gentle, Strict, Exploratory).
        /// </summary>
        public string ValidationMode { get; set; }

        /// <summary>
        /// Fallback message to use when validation fails or tone mismatches.
        /// </summary>
        public string FallbackMessage { get; set; }

        /// <summary>
        /// Semantic tags for traceability and emotional consequence.
        /// </summary>
        public List<string> Tags { get; set; } = new();
    }

    #region PhaseManifest Summary (August 31, 2025)
    // PhaseManifest describes how Prism should validate and respond based on contributor phase.
    // It includes validation mode, fallback narration, and semantic tags for emotional traceability.
    // This stub supports Sprint 2’s phase-aware routing and prepares Prism for adaptive consequence.
    #endregion
}