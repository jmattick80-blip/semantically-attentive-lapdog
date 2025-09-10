using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Registries
{
    /// <summary>
    /// Registry for managing intent manifests. Supports registration, inspection, and narration.
    /// Cluster-related methods are stubbed for interface compliance.
    /// </summary>
    public class IntentRegistry : IManifestRegistry<IIntentManifest>, IManifestRegistryBase
    {
        private readonly Dictionary<string, IIntentManifest> _registeredIntents =
            new Dictionary<string, IIntentManifest>();

        public IReadOnlyList<string> Breadcrumbs => _breadcrumbs.AsReadOnly();

        
        /// <summary>
        /// Registers an intent manifest into the registry.
        /// </summary>
        /// <param name="manifest">The intent manifest to register.</param>
        public void RegisterManifest(IIntentManifest manifest)
        {
            if (string.IsNullOrWhiteSpace(manifest.DisplayName))
            {
                RecordBreadcrumb("❌ Manifest registration failed: null or missing DisplayName.");
                return;
            }

            if (!_registeredIntents.ContainsKey(manifest.DisplayName))
            {
                _registeredIntents[manifest.DisplayName] = manifest;
                RecordBreadcrumb($"✅ Manifest registered: {manifest.DisplayName}");
            }
            else
            {
                RecordBreadcrumb($"⚠️ Manifest already registered: {manifest.DisplayName}");
            }

        }

        private readonly List<string> _breadcrumbs = new List<string>();

        private void RecordBreadcrumb(string message)
        {
            _breadcrumbs.Add(message);
            Console.WriteLine(message); // Replace narratable dispatcher if needed
        }
        
        /// <summary>
        /// Removes an intent manifest from the registry by its identifier.
        /// </summary>
        /// <param name="manifestId">The identifier of the manifest to remove.</param>
        public void RemoveManifest(string manifestId)
        {
            if (!_registeredIntents.Remove(manifestId))
            {
                
            }
        }

        /// <summary>
        /// Retrieves an intent manifest by its identifier.
        /// </summary>
        /// <param name="manifestId">The identifier of the manifest.</param>
        /// <returns>The matching intent manifest, or null if not found.</returns>
        public IIntentManifest GetManifestById(string manifestId)
        {
            if (string.IsNullOrWhiteSpace(manifestId))
                throw new ArgumentException("Manifest ID cannot be null or empty.", nameof(manifestId));

            if (_registeredIntents.TryGetValue(manifestId, out var manifest))
                return manifest;

            throw new InvalidOperationException($"❌ No intent manifest found for ID: {manifestId}");
        }

        /// <summary>
        /// Returns all intent manifests in the registry that are narratable.
        /// </summary>
        /// <returns>A collection of narratable intent manifests.</returns>
        public IEnumerable<IIntentManifest> GetNarratableManifests() =>
            _registeredIntents.Values.Where(m => m.IsNarratable);

        /// <summary>
        /// Retrieves all intent manifest identifiers currently registered.
        /// </summary>
        /// <returns>A collection of manifest identifiers.</returns>
        public IEnumerable<string> GetManifestIds() => _registeredIntents.Keys;

        /// <summary>
        /// Checks whether an intent manifest with the given identifier exists in the registry.
        /// </summary>
        /// <param name="manifestId">The identifier to check.</param>
        /// <returns>True if the manifest exists; otherwise, false.</returns>
        public bool HasManifest(string manifestId) => _registeredIntents.ContainsKey(manifestId);

        IEnumerable<IManifest> IManifestRegistryBase.GetNarratableManifests()
        {
            return GetNarratableManifests();
        }

        /// <summary>
        /// Retrieves a narration hint for an intent manifest based on its identifier.
        /// </summary>
        /// <param name="manifestId">The identifier of the manifest.</param>
        /// <returns>A narration hint string, or a fallback message if unavailable.</returns>
        public string GetNarrationHint(string manifestId)
        {
            var manifest = GetManifestById(manifestId);
            return manifest.GetNarrationHint(manifestId);
        }

        /// <summary>
        /// Stubbed method. IntentRegistry does not manage system clusters.
        /// </summary>
        /// <param name="cluster">The cluster to register.</param>
        public void AddSystemCluster(Cluster cluster)
        {
        }

        /// <summary>
        /// Stubbed method. IntentRegistry does not propagate trait bundles to clusters.
        /// </summary>
        /// <param name="traits">The traits to propagate.</param>
        public void PropagateTraitBundle(IEnumerable<ITrait> traits)
        {
        }

        /// <summary>
        /// Stubbed method. IntentRegistry does not manage system clusters.
        /// </summary>
        public void ClearSystemClusters()
        {
        }

        public IEnumerable<IIntentManifest> GetAllManifests()
        {
            return _registeredIntents.Values;
        }
    }
}