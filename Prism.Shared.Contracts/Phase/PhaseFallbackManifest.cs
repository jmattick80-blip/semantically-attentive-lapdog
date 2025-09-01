using System.Collections.Generic;

namespace Prism.Shared.Contracts.Phase
{
    /// <summary>
    /// Stores designer-authored fallback messages based on phase, role, and tone.
    /// </summary>
    public class PhaseFallbackManifest
    {
        private readonly Dictionary<string, Dictionary<string, Dictionary<string, string>>> _fallbacks =
            new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

        public void Register(string phase, string role, string tone, string message)
        {
            if (!_fallbacks.ContainsKey(phase))
                _fallbacks[phase] = new Dictionary<string, Dictionary<string, string>>();

            if (!_fallbacks[phase].ContainsKey(role))
                _fallbacks[phase][role] = new Dictionary<string, string>();

            _fallbacks[phase][role][tone] = message;
        }

        public string GetFallback(string phase, string role, string tone)
        {
            if (_fallbacks.TryGetValue(phase, out var roleMap) &&
                roleMap.TryGetValue(role, out var toneMap) &&
                toneMap.TryGetValue(tone, out var message))
            {
                return message;
            }

            return null;
        }
    }
}