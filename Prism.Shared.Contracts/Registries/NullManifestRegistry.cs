using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Registries
{
    /// <summary>
    /// Fallback registry used when no manifest registry is available.
    /// Prevents null reference errors and provides narratable feedback.
    /// </summary>
    public class NullManifestRegistry<TManifest> : IManifestRegistry<TManifest> where TManifest : IManifest
    {
        public void RegisterManifest(TManifest manifest)
        {
            Console.WriteLine($"🚫 Cannot register manifest—no active registry for type: {typeof(TManifest).Name}");
        }

        public void RemoveManifest(string manifestId)
        {
            Console.WriteLine($"🚫 Cannot remove manifest '{manifestId}'—no active registry.");
        }

        public TManifest GetManifestById(string manifestId)
        {
            Console.WriteLine($"🚫 Manifest '{manifestId}' not found—null registry in use.");
            return default;
        }

        public IEnumerable<TManifest> GetNarratableManifests()
        {
            Console.WriteLine("🚫 No narratable manifests—null registry in use.");
            return Array.Empty<TManifest>();
        }

        public IEnumerable<string> GetManifestIds()
        {
            return Array.Empty<string>();
        }

        public bool HasManifest(string manifestId)
        {
            return false;
        }

        public string GetNarrationHint(string manifestId)
        {
            return $"⚠️ No registry available to narrate manifest '{manifestId}'.";
        }

        public void AddSystemCluster(Cluster cluster)
        {
            Console.WriteLine("🚫 Cannot add cluster—no active registry.");
        }

        public void PropagateTraitBundle(IEnumerable<ITrait> traits)
        {
            Console.WriteLine("🚫 Cannot propagate traits—no active registry.");
        }

        public void ClearSystemClusters()
        {
            Console.WriteLine("🚫 Cannot clear clusters—no active registry.");
        }

        public IEnumerable<TManifest> GetAllManifests()
        {
            return Array.Empty<TManifest>();
        }
    }
}