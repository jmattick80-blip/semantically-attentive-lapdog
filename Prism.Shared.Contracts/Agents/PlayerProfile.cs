using System.Collections.Generic;

namespace Prism.Shared.Contracts.Agents
{
    public class PlayerProfile
    {
        /// <summary>
        /// Unique identifier for the player or contributor.
        /// </summary>
        public string PlayerId { get; set; } = string.Empty;

        /// <summary>
        /// Display name used in dashboards, contributor logs, and multiplayer sessions.
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Optional role or archetype assigned to this player (e.g. "Designer", "Curator").
        /// </summary>
        public string Archetype { get; set; } = string.Empty;

        /// <summary>
        /// Trait bundle this player injects into transformation or scenario flows.
        /// </summary>
        public List<string> Traits { get; set; } = new List<string>();

        /// <summary>
        /// Mood vector used to influence emotional mesh or exhibit reactions.
        /// </summary>
        public Dictionary<string, float> MoodVector { get; set; } = new Dictionary<string, float>();

        /// <summary>
        /// Optional metadata block for contributor tooling or replay dashboards.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    }
}