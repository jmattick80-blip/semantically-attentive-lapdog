using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Manifests;

namespace Prism.Shared.Contracts.Manifests.Types
{
    /// <summary>
    /// Represents a manifest that reacts to emotional context.
    /// Supports traits, overlays, and mood vector hydration.
    /// </summary>
    public class EmotionallyReactiveManifest : IEmotionallyReactiveManifest
    {
        public EmotionallyReactiveManifest()
        {
            Traits = new List<string>();
            Overlays = new List<string>();
            MoodVector = new Dictionary<string, float>();
        }

        public string ManifestId { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsNarratable { get; set; }

        public List<string> Traits { get; set; }

        public List<string> Overlays { get; set; }

        public Dictionary<string, float> MoodVector { get; set; }
    }
}