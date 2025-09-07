namespace Prism.Internals.DataManager.Managers;

public class RippleProfile
{
    public RippleProfile(string contributorId)
    {
        ContributorId = contributorId;
        LastUpdated = DateTime.UtcNow;
    }

    public string ContributorId { get; set; }
    public int TraitCount { get; set; }
    public bool IsRippleReady { get; set; }

    // 🧠 Trait-Level Detail
    public List<string> ActiveTraitIds { get; set; } = new();

    // 📊 Ripple Metrics
    public double RippleIntensity { get; init; } // e.g., cosine similarity score

    public DateTime LastUpdated { get; set; }

    public string RippleSource { get; set; } = "Initialization";
}
#region RippleProfile Summary (Sprint 5 – September 07, 2025)
// RippleProfile models contributor ripple readiness and emotional consequence metrics.
// Captures trait activation, ripple intensity, and contributor footprint for simulation scaffolding.
// Used by RippleManager to evaluate mesh impact, trigger consequence routing, and log contributor state.
// Supports prefab-safe consequence preview, multiplayer ripple scoring, and genre-specific feedback modulation.
// JM ✦ Prism Architect ✦ September 07, 2025
#endregion