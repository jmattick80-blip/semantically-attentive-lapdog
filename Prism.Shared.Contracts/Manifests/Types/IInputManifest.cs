using Prism.Shared.Contracts.Interfaces.Manifests;

namespace Prism.Shared.Contracts.Manifests.Types
{
    /// <summary>
    /// Represents a manifest derived from contributor input.
    /// Supports display name, role context, and tag propagation.
    /// </summary>
    public interface IInputManifest : IManifest
    {
        /// <summary>
        /// Role or context associated with the contributor input.
        /// </summary>
        string RoleContext { get; set; }

        /// <summary>
        /// Tags that describe the input's tone, domain, or routing hints.
        /// </summary>
        string[] Tags { get; set; }
    }
}