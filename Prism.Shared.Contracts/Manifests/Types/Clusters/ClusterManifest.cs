using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Manifests.Types.Clusters
{
    public class ClusterManifest : IClusterManifest
    {
        public ClusterManifest(string manifestId, string displayName, string description)
        {
            ManifestId = manifestId;
            DisplayName = displayName;
            Description = description;
        }

        #region Identity & Description

        public string ManifestId { get; set; } // Optional: stable registry key
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public bool IsNarratable => !string.IsNullOrEmpty(Description);

        #endregion

        #region Traits & Signals

        public IEnumerable<ITrait> DefaultTraits { get; set; } = new List<ITrait>();
        public IEnumerable<string> SignalBindings { get; set; } = new List<string>();

        #endregion

        #region Child Cluster Containment

        public List<Cluster> ChildClusters { get; private set; } = new List<Cluster>();

        #endregion

        #region Trait Propagation

        public void PropagateTraitBundle(IEnumerable<ITrait> traits)
        {
            DefaultTraits = traits.ToList();
            Console.WriteLine($"📦 Trait bundle propagated to ClusterManifest '{ManifestId}' with {DefaultTraits.Count()} traits.");
        }

        #endregion

        #region Narration

        public string GetNarrationHint(string signalId)
        {
            return $"{DisplayName} activated by signal: {signalId}";
        }

        #endregion
    }
}