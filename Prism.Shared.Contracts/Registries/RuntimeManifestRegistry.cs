using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Registries
{
    /// <summary>
    /// Runtime registry for managing emotionally reactive manifests during live simulation.
    /// Supports inspection, trait propagation, and narratable orchestration.
    /// </summary>
    public class RuntimeManifestRegistry<TManifest> : IManifestRegistry<TManifest> where TManifest : IManifest
    {
        private readonly Dictionary<string, TManifest> _manifests = new();
        private readonly List<Cluster> _clusters = new();

        public void RegisterManifest(TManifest manifest)
        {
            if (manifest == null || string.IsNullOrWhiteSpace(manifest.ManifestId))
                return;

            _manifests[manifest.ManifestId] = manifest;
            Console.WriteLine($"📡 Registered runtime manifest: {manifest.ManifestId}");
        }

        public void RemoveManifest(string manifestId)
        {
            if (_manifests.Remove(manifestId))
                Console.WriteLine($"🧹 Removed manifest: {manifestId}");
        }

        public TManifest GetManifestById(string manifestId)
        {
            _manifests.TryGetValue(manifestId, out var manifest);
            return manifest;
        }

        public IEnumerable<TManifest> GetNarratableManifests()
        {
            foreach (var manifest in _manifests.Values)
            {
                if (manifest.IsNarratable)
                    yield return manifest;
            }
        }

        public IEnumerable<string> GetManifestIds() => _manifests.Keys;

        public bool HasManifest(string manifestId) => _manifests.ContainsKey(manifestId);

        public string GetNarrationHint(string manifestId)
        {
            return _manifests.TryGetValue(manifestId, out var manifest)
                ? $"Manifest '{manifestId}' is active and narratable."
                : $"Manifest '{manifestId}' not found in runtime registry.";
        }

        public void AddSystemCluster(Cluster cluster)
        {
            if (cluster != null)
                _clusters.Add(cluster);
        }

        public void PropagateTraitBundle(IEnumerable<ITrait> traits)
        {
            if (traits == null)
            {
                Console.WriteLine("⚠️ Trait bundle is null—no traits propagated.");
                return;
            }

            foreach (var cluster in _clusters)
            {
                cluster.ReceiveTraits(traits);
                Console.WriteLine($"🔁 Propagated traits to cluster: {cluster.ClusterId}");
            }
        }

        public void ClearSystemClusters()
        {
            _clusters.Clear();
            Console.WriteLine("🧼 Cleared all runtime clusters.");
        }

        public IEnumerable<TManifest> GetAllManifests()
        {
            return _manifests.Values;
        }
    }
}