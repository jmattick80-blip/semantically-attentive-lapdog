using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Manifests;

namespace GalleryDrivers.Prism.Shared.Manifests.Types
{
    /// <summary>
    /// Represents a manifest that carries semantic meaning and contributor-facing tags.
    /// Used for tone interpretation, routing, and narratable onboarding.
    /// </summary>
    public class SemanticManifest : ISemanticManifest
    {
        public SemanticManifest()
        {
            SemanticTags = new List<string>();
        }

        /// <summary>
        /// Unique identifier for this manifest instance.
        /// </summary>
        public string ManifestId { get; set; }

        /// <summary>
        /// Tags that describe the semantic context of this manifest.
        /// </summary>
        public List<string> SemanticTags { get; set; }

        public string DisplayName { get; }

        /// <summary>
        /// Contributor-facing description of the manifest's purpose.
        /// </summary>
        public string Description { get; set; }

        public bool IsNarratable { get; }
    }
}