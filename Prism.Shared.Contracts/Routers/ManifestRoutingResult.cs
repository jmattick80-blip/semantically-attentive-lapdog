using System.Collections.Generic;

namespace Prism.Shared.Contracts.Routers
{
    public class ManifestRoutingResult
    {
        public string Target { get; set; } = "unspecified";         // e.g. "NPCLayer", "ValidationFlow", "TutorialStage"
        public string Strategy { get; set; } = "default";           // e.g. "Curation", "Assembly", "OnboardingRegistryResolver"
        public string Tone { get; set; } = "neutral";               // e.g. "playful", "formal", "gentle"
        public bool IsFallback { get; set; } = false;               // Indicates if default routing was used
        public List<string> Notes { get; set; } = new();                 // Narratable annotations for contributors

        public static ManifestRoutingResult Default(string phase = "unspecified")
        {
            return new ManifestRoutingResult
            {
                Target = "DefaultFlow",
                Strategy = phase,
                Tone = "neutral",
                IsFallback = true,
                Notes = new List<string>
                {
                    $"No phase-specific resolver found. Routed using default strategy for phase '{phase}'.",
                    "Consider defining a custom resolver for richer flow control."
                }
            };
        }

        public void AddNote(string note)
        {
            if (!string.IsNullOrWhiteSpace(note))
            {
                Notes.Add(note.Trim());
            }
        }

        public void AddNotes(IEnumerable<string> notes)
        {
            foreach (var note in notes)
            {
                AddNote(note);
            }
        }
    }
    
    #region ManifestRoutingResult – End Summary (August 31, 2025)

    // This class represents the outcome of a manifest routing decision.
    // It carries the target destination, routing strategy, emotional tone, and fallback status.
    // Notes provide narratable context for contributors and future editors.
    // The Default() method ensures safe fallback behavior when no resolver is registered.
    // All routing results are emotionally legible, contributor-safe, and extensible.

    #endregion

}