using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;

namespace Prism.Shared.Contracts.Registries
{
    public class ClusterRegistry : IManifestRegistry<IClusterManifest>, IManifestRegistryBase
    {
        private readonly Dictionary<string, IClusterManifest> _registeredClusters = new Dictionary<string, IClusterManifest>();

        public IReadOnlyList<string> Breadcrumbs => _breadcrumbs.AsReadOnly();
        
        public void RegisterManifest(IClusterManifest manifest)
        {
            if (manifest == null || string.IsNullOrWhiteSpace(manifest.DisplayName))
                return;

            if (!_registeredClusters.ContainsKey(manifest.DisplayName))
            {
                _registeredClusters[manifest.DisplayName] = manifest;
            }
        }

        private readonly List<string> _breadcrumbs = new List<string>();
        private void RecordBreadcrumb(string message)
        {
            _breadcrumbs.Add(message);
            Console.WriteLine(message); // Replace narratable dispatcher if needed
        }
        
        public void AddSystemCluster(Cluster cluster)
        {
            if (string.IsNullOrEmpty(cluster.Manifest.DisplayName)) return;
            if (_registeredClusters.ContainsKey(cluster.Manifest.DisplayName)) return;

            _registeredClusters[cluster.Manifest.DisplayName] = cluster.Manifest;
        }

        public void ClearSystemClusters()
        {
            _registeredClusters.Clear();
        }
        
        public void RemoveManifest(string manifestId)
        {
            _registeredClusters.Remove(manifestId);
        }

        public IClusterManifest GetManifestById(string manifestId)
        {
            if (string.IsNullOrWhiteSpace(manifestId))
                throw new ArgumentException("Manifest ID cannot be null or empty.", nameof(manifestId));

            if (_registeredClusters.TryGetValue(manifestId, out var manifest))
                return manifest;

            throw new InvalidOperationException($"No cluster manifest found for ID: {manifestId}");
        }
        public IEnumerable<IClusterManifest> GetNarratableManifests() =>
            _registeredClusters.Values.Where(m => m.IsNarratable);

        public IEnumerable<string> GetManifestIds() => _registeredClusters.Keys;

        public bool HasManifest(string manifestId) => _registeredClusters.ContainsKey(manifestId);

        IEnumerable<IManifest> IManifestRegistryBase.GetNarratableManifests()
        {
            return GetNarratableManifests();
        }

        public string GetNarrationHint(string manifestId)
        {
            var manifest = GetManifestById(manifestId);
            return manifest.GetNarrationHint(manifestId);
        }
    }
}