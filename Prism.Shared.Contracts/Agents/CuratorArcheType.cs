using System.Collections.Generic;

namespace Prism.Shared.Contracts.Agents
{
    public class CuratorArchetype
    {
        /// <summary>
        /// Unique role identifier used for transformer resolution and session routing.
        /// </summary>
        public string RoleId { get; set; } = string.Empty;

        /// <summary>
        /// Display name for contributor dashboards and onboarding flows.
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Optional description of this archetype’s emotional or narrative focus.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// List of default traits this curator injects into transformation flows.
        /// </summary>
        public List<string> DefaultTraits { get; set; } = new List<string>();
        
        /// <summary>
        /// Optional metadata block for contributor tooling or scenario resale.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    }
}