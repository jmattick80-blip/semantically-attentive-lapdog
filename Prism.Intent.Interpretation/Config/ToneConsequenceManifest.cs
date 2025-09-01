using System.Collections.Generic;

namespace Prism.Intent.Interpretation.Config
{
    /// <summary>
    /// Stores designer-authored consequence lines based on tone and contributor role.
    /// </summary>
    public class ToneConsequenceManifest
    {
        private readonly Dictionary<string, Dictionary<string, string>> _responses = new();

        /// <summary>
        /// Registers a consequence line for a given role and tone.
        /// </summary>
        public void Register(string role, string tone, string response)
        {
            if (!_responses.ContainsKey(role))
                _responses[role] = new Dictionary<string, string>();

            _responses[role][tone] = response;
        }

        /// <summary>
        /// Retrieves a consequence line based on role and tone.
        /// </summary>
        public string GetResponse(string role, string tone)
        {
            if (_responses.TryGetValue(role, out var toneMap) &&
                toneMap.TryGetValue(tone, out var response))
            {
                return response;
            }

            return "…"; // Fallback if no match
        }
    }

    #region ToneConsequenceManifest Summary (August 31, 2025)
    // Stores authored consequence lines for contributor tone and role.
    // Enables simulation-grade emotional feedback without hardcoded phrasing.
    // Scaffolds Sprint 3’s consequence layer for mesh-aware response modulation.
    #endregion
}