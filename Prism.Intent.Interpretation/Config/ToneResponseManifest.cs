using System.Collections.Generic;

namespace Prism.Intent.Interpretation.Config
{
    /// <summary>
    /// Stores designer-authored tone responses for contributors and NPC emitters.
    /// </summary>
    public class ToneResponseManifest
    {
        private readonly Dictionary<string, Dictionary<string, string>> _responses = new();

        /// <summary>
        /// Registers a tone response for a given role and tone.
        /// </summary>
        public void Register(string role, string tone, string response)
        {
            if (!_responses.ContainsKey(role))
                _responses[role] = new Dictionary<string, string>();

            _responses[role][tone] = response;
        }

        /// <summary>
        /// Retrieves a tone response based on contributor role and tone.
        /// </summary>
        public string GetResponse(string role, string tone)
        {
            if (_responses.TryGetValue(role, out var toneMap) &&
                toneMap.TryGetValue(tone, out var response))
            {
                return response;
            }

            return "…"; // Default fallback if no match
        }
    }

    #region ToneResponseManifest Summary (August 31, 2025)
    // ToneResponseManifest stores designer-authored emotional feedback for contributors and NPC emitters.
    // It supports role-based tone modulation and enables Unity MonoBehaviour emitters to inject authored responses.
    // This scaffolds Sprint 3’s voice layer and prepares Prism for simulation-grade narration.
    #endregion
}