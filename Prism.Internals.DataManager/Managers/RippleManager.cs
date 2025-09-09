using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces.Managers;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Internals.DataManager.Managers
{
    public class RippleManager : IPrismManager
    {
        private readonly List<RippleProfile> _rippleProfiles = new();
        public IReadOnlyList<RippleProfile> RippleProfiles => _rippleProfiles.AsReadOnly();

        public string ManagerId { get; set; } = "RippleManager";
        public string Description { get; set; } = "Tracks contributor ripple readiness and emotional consequence propagation.";

        public async Task InitializeAsync(List<MeshProfile> profiles)
        {
            if (profiles.Count == 0)
            {
                Console.WriteLine("⚠️ RippleManager: No profiles provided during initialization.");
                return;
            }

            foreach (var profile in profiles)
            {
                var activeTraits = profile.Traits?
                    .OfType<PrismTrait>()
                    .Where(t => t.IsActive)
                    .ToList() ?? new List<PrismTrait>();

                var rippleProfile = new RippleProfile(profile.ContributorId)
                {
                    TraitCount = profile.Traits?.Count ?? 0,
                    IsRippleReady = activeTraits.Any(),
                    ActiveTraitIds = activeTraits.Select(t => t.TraitName).ToList(),
                    RippleIntensity = CalculateRippleIntensity(activeTraits),
                    RippleSource = "InitializeAsync"
                };

                _rippleProfiles.Add(rippleProfile);

                Console.WriteLine($"🌊 RippleProfile created for {rippleProfile.ContributorId} | Traits: {rippleProfile.TraitCount} | Ready: {rippleProfile.IsRippleReady} | Intensity: {rippleProfile.RippleIntensity:F2}");
            }

            await TriggerRippleSimulationAsync();
        }

        private async Task TriggerRippleSimulationAsync()
        {
            Console.WriteLine("🌀 RippleManager: Triggering async ripple consequence simulation...");
            await Task.Delay(100);

            foreach (var ripple in _rippleProfiles)
            {
                Console.WriteLine($"📡 RippleEventLog → Contributor: {ripple.ContributorId}, Intensity: {ripple.RippleIntensity:F2}, Traits: {string.Join(", ", ripple.ActiveTraitIds)}");
            }

            // Future: propagate ripple effects, update emotional mesh, log consequences
        }

        private double CalculateRippleIntensity(List<PrismTrait> traits)
        {
            double totalScore = 0.0;

            foreach (var trait in traits)
            {
                double toneWeight = trait.Tone switch
                {
                    "Excited" => 0.4,
                    "Neutral" => 0.2,
                    "Tense" => 0.3,
                    _ => 0.1
                };

                double sourceMultiplier = trait.Source switch
                {
                    "npc" => 1.0,
                    "scenario" => 0.8,
                    "payload" => 0.6,
                    _ => 0.5
                };

                double scenarioBonus = trait.ScenarioTag == "startup" ? 0.2 : 0.0;

                totalScore += toneWeight * sourceMultiplier + scenarioBonus;
            }

            return Math.Min(1.0, totalScore);
        }
    }

    #region RippleManager Summary (Sprint 5 – September 09, 2025)
    // RippleManager tracks contributor ripple readiness and emotional consequence propagation.
    // Transforms MeshProfile objects into RippleProfile snapshots using PrismTrait contracts.
    // Scores ripple intensity based on tone, source, and scenario resonance.
    // Logs ripple events for contributor traceability and prefab-safe consequence scaffolding.
    // Supports async ripple simulation and future mesh consequence routing.
    // JM ✦ Prism Architect ✦ September 09, 2025
    #endregion
}