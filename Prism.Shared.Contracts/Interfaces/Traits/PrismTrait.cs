using System;

namespace Prism.Shared.Contracts.Interfaces.Traits
{
    public interface ITrait
    {
        string TraitId { get; }
        string TraitName { get; }
        string Tone { get; }
        string Source { get; }
        string ScenarioTag { get; }
        string Description { get; }
        bool IsActive { get; }

        void Activate();
        void Modulate(TraitModulationContext context);
    }

    public class PrismTrait : ITrait
    {
        public string TraitId { get; set; } = Guid.NewGuid().ToString();
        public string TraitName { get; set; }
        public string Tone { get; set; } = "Neutral";
        public string Source { get; set; } = "Unknown";
        public string ScenarioTag { get; set; } = "Unspecified";
        public string Description { get; set; } = "No description provided.";
        public bool IsActive { get; private set; } = false;

        public void Activate()
        {
            IsActive = true;
            Console.WriteLine($"✅ Trait '{TraitName}' activated.");
        }

        public void Modulate(TraitModulationContext context)
        {
            Tone = context.ToneHint ?? Tone;
            Source = context.Source ?? Source;
            ScenarioTag = context.ScenarioTag ?? ScenarioTag;

            Console.WriteLine($"🎛️ Trait '{TraitName}' modulated → Tone: {Tone}, Source: {Source}, Scenario: {ScenarioTag}");
        }
    }
}