using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Traits.Base;

namespace Prism.Shared.Contracts.Traits
{
    /// <summary>
    /// PrismTrait is a prefab-safe, narratable emotional trait used across Prism OS.
    /// It inherits from PrismTraitBase and supports descriptor-driven modulation via the Modulate method.
    /// PrismTrait is used in contributor onboarding, mesh activation, and simulation scaffolds.
    /// Designers can pass values like ToneHint, Source, or ScenarioTag to guide emotional adaptation.
    /// </summary>
    public class PrismTrait : PrismTraitBase
    {
        /// <summary>
        /// Optional emotional tone descriptor—used in overlays and contributor feedback.
        /// </summary>
        public string Tone { get; set; }

        /// <summary>
        /// Optional origin label—used to trace trait injection source (e.g., TriggerMap, Envelope, Adapter).
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Optional scenario tag—used to guide modulation context or routing.
        /// </summary>
        public string ScenarioTag { get; set; }

        public PrismTrait(string traitId, string traitName, string description)
            : base(traitId, traitName, description)
        {
        }

        public override void Modulate(TraitModulationContext traitModulationContext)
        {
            Tone = traitModulationContext.ToneHint;
            Source = traitModulationContext.Source;
            ScenarioTag = traitModulationContext.ScenarioTag;
        }
    }

    #region PrismTrait Summary
    /// <summary>
    /// PrismTrait is a prefab-safe, narratable emotional trait used across Prism OS.
    /// It inherits from PrismTraitBase and supports descriptor-driven modulation via the Modulate method.
    /// PrismTrait is used in contributor onboarding, mesh activation, and simulation scaffolds.
    /// Designers can pass values like ToneHint, Source, or ScenarioTag to guide emotional adaptation.
    /// This trait structure remains generic, extensible, and emotionally legible across domains.
    /// </summary>
    /// LastModified: 2025-09-03
    /// JM ✦ Prism Architect ✦ 2025-09-03
    #endregion
}