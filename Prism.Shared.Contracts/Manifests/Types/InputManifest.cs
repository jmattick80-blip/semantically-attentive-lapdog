using Prism.Shared.Contracts.Manifests.Types;

namespace GalleryDrivers.Prism.Shared.Manifests.Types
{
    /// <summary>
    /// Represents a manifest derived from contributor input.
    /// Supports display name, role context, and tag propagation.
    /// </summary>
    public class InputManifest : IInputManifest
    {
        public string ManifestId { get; set; }

        public string DisplayName { get; set; }
        public string Description { get; }

        public string RoleContext { get; set; }

        public string[] Tags { get; set; }

        public bool IsNarratable { get; set; }
    }
}