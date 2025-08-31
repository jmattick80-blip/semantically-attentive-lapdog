namespace Prism.Shared.Contracts.Agents
{
    public class NpcDefinition
    {
        /// <summary>
        /// Unique identifier for the NPC, used for registry and transformation routing.
        /// </summary>
        public string NpcId { get; set; } = string.Empty;

        /// <summary>
        /// Contributor-facing display name for UI, dashboards, and scenario editors.
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Trait-trigger mappings that define how this NPC reacts in simulation.
        /// </summary>
        public TraitTriggerMap TraitTriggerMap { get; set; } = new TraitTriggerMap();
    }
}