using System.Collections.Generic;

namespace Prism.Shared.Contracts.Interfaces.Manifests
{
    /// <summary>
    /// Represents a manifest that carries semantic meaning and contributor-facing tags.
    /// Used for intent interpretation, tone mapping, and narratable routing.
    /// </summary>
    public interface ISemanticManifest : IManifest
    {
        /// <summary>
        /// Tags that describe the semantic context of this manifest.
        /// </summary>
        List<string> SemanticTags { get; set; }

        /// <summary>
        /// Optional contributor-facing description of the manifest's purpose.
        /// </summary>
        string Description { get; set; }
    }
}