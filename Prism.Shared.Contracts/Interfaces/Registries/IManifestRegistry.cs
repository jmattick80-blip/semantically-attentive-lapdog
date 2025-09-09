using System.Collections.Generic;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Interfaces.Registries
{
    /// <summary>
    /// Defines a contributor-safe registry for managing narratable manifests and system clusters.
    /// Supports registration, inspection, trait propagation, and runtime orchestration.
    /// </summary>
    public interface IManifestRegistry<TManifest> where TManifest : IManifest
    {
        /// <summary>
        /// Registers a manifest into the registry.
        /// </summary>
        /// <param name="manifest">The manifest to register.</param>
        void RegisterManifest(TManifest manifest);

        /// <summary>
        /// Removes a manifest from the registry by its identifier.
        /// </summary>
        /// <param name="manifestId">The identifier of the manifest to remove.</param>
        void RemoveManifest(string manifestId);

        /// <summary>
        /// Retrieves a manifest by its identifier.
        /// </summary>
        /// <param name="manifestId">The identifier of the manifest.</param>
        /// <returns>The matching manifest, or null if not found.</returns>
        TManifest GetManifestById(string manifestId);

        /// <summary>
        /// Returns all manifests in the registry that are narratable.
        /// </summary>
        /// <returns>A collection of narratable manifests.</returns>
        IEnumerable<TManifest> GetNarratableManifests();

        /// <summary>
        /// Retrieves all manifest identifiers currently registered.
        /// </summary>
        /// <returns>A collection of manifest identifiers.</returns>
        IEnumerable<string> GetManifestIds();

        /// <summary>
        /// Checks whether a manifest with the given identifier exists in the registry.
        /// </summary>
        /// <param name="manifestId">The identifier to check.</param>
        /// <returns>True if the manifest exists; otherwise, false.</returns>
        bool HasManifest(string manifestId);

        /// <summary>
        /// Retrieves a narration hint for a manifest based on its identifier.
        /// </summary>
        /// <param name="manifestId">The identifier of the manifest.</param>
        /// <returns>A narration hint string, or a fallback message if unavailable.</returns>
        string GetNarrationHint(string manifestId);

        /// <summary>
        /// Registers a system cluster into the manifest registry.
        /// </summary>
        /// <param name="cluster">The cluster to register.</param>
        void AddSystemCluster(Cluster cluster);

        /// <summary>
        /// Clears all registered clusters from the registry.
        /// </summary>
        void ClearSystemClusters();
    }
}