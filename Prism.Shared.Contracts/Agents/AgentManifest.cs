using System.Collections.Generic;

namespace Prism.Shared.Contracts.Agents
{
    public class AgentManifest
    {
        /// <summary>
        /// Unique identifier for this manifest (e.g. "HauntedGalleryPack").
        /// </summary>
        public string ManifestId { get; set; } = string.Empty;

        /// <summary>
        /// Contributor-facing name for dashboards, scenario editors, or marketplace listings.
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Optional description of the manifest’s emotional or narrative theme.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// List of NPCs included in this manifest.
        /// </summary>
        public List<NpcDefinition> Npcs { get; set; } = new List<NpcDefinition>();
    }
}

/// <summary>
/// Optional curator