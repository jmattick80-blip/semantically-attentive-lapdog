using System.Collections.Generic;

namespace Prism.Intent.Interpretation.Config
{
    public class InterpretationManifest
    {
        /// <summary>
        /// Maps system intents to interpretation strategies (e.g. Escalation, Curiosity, Reflection).
        /// </summary>
        public Dictionary<string, string> IntentInterpretationMap { get; set; } = new();

        /// <summary>
        /// Defines fallback interpretation strategy when intent is ambiguous or missing.
        /// </summary>
        public string DefaultInterpretationStrategy { get; set; } = "Neutral";

        /// <summary>
        /// Optional overrides for interpretation strategy based on contributor phase.
        /// </summary>
        public Dictionary<string, string> PhaseOverrides { get; set; } = new();

        /// <summary>
        /// Optional tone-based modifiers to adjust interpretation nuance.
        /// </summary>
        public Dictionary<string, string> ToneModifiers { get; set; } = new();
    }

    #region InterpretationManifest Summary (August 31, 2025)
    // InterpretationManifest defines how Prism interprets contributor intent across emotional and lifecycle context.
    // It maps system intents to semantic strategies, with optional overrides for phase and tone.
    // This stub scaffolds Sprint 3’s reflection layer and prepares Prism for mesh consequence.
    #endregion
}