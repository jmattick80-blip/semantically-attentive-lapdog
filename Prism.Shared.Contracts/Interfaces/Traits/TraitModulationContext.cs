using System;

namespace Prism.Shared.Contracts.Interfaces.Traits
{
    public class TraitModulationContext
    {
        /// <summary>
        /// Suggested emotional tone for the trait (e.g., "Neutral", "Excited", "Tense").
        /// </summary>
        public string? ToneHint { get; set; }

        /// <summary>
        /// Source of the trait modulation (e.g., "npc", "scenario", "payload").
        /// </summary>
        public string? Source { get; set; }

        /// <summary>
        /// Scenario tag that provides contextual relevance (e.g., "startup", "layout-edit").
        /// </summary>
        public string? ScenarioTag { get; set; }

        /// <summary>
        /// Optional contributor ID or role that initiated the modulation.
        /// </summary>
        public string? ContributorId { get; set; }

        /// <summary>
        /// Optional timestamp for when modulation occurred.
        /// </summary>
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Optional notes or annotations for audit traceability.
        /// </summary>
        public string? Annotation { get; set; }
    }
}