using System.Collections.Generic;

namespace Prism.Intent.Interpretation.Config
{
    /// <summary>
    /// Stores designer-authored interpretation lines for contributor roles and phases.
    /// </summary>
    public class InterpretationResponseManifest
    {
        private readonly Dictionary<string, Dictionary<string, Dictionary<string, string>>> _responses = new();

        /// <summary>
        /// Registers an interpretation line for a given interpretation, role, and phase.
        /// </summary>
        public void Register(string interpretation, string role, string phase, string response)
        {
            if (!_responses.ContainsKey(interpretation))
                _responses[interpretation] = new Dictionary<string, Dictionary<string, string>>();

            if (!_responses[interpretation].ContainsKey(role))
                _responses[interpretation][role] = new Dictionary<string, string>();

            _responses[interpretation][role][phase] = response;
        }

        /// <summary>
        /// Retrieves an interpretation line based on interpretation, role, and phase.
        /// </summary>
        public string GetResponse(string interpretation, string role, string phase)
        {
            if (_responses.TryGetValue(interpretation, out var roleMap) &&
                roleMap.TryGetValue(role, out var phaseMap) &&
                phaseMap.TryGetValue(phase, out var response))
            {
                return response;
            }

            return "…"; // Fallback if no match
        }
    }

    #region InterpretationResponseManifest Summary (August 31, 2025)
    // Stores authored interpretation lines for contributor roles and lifecycle phases.
    // Enables NPC emitters to inject narratable feedback based on emotional context.
    // Scaffolds Sprint 3’s semantic reflection layer for simulation-grade consequence.
    #endregion
}