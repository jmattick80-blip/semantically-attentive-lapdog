namespace Prism.Shared.Contracts.Traits;

public class TraitModulationContext
{
    /// <summary>Suggested tone adjustment, e.g. "Softened", "Amplified"</summary>
    public string ToneHint { get; set; }

    /// <summary>Source of modulation, e.g. "Overlay", "NPC", "Session"</summary>
    public string Source { get; set; }

    /// <summary>Optional domain or scenario tag</summary>
    public string ScenarioTag { get; set; }

    // Extend as needed
}