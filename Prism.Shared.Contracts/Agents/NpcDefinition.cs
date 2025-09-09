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
    }
}