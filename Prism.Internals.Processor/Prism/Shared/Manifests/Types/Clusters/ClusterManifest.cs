using System.Collections.Generic;
using System.Linq;
using GalleryDrivers.Prism.Shared.Clusters.Base;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;

namespace GalleryDrivers.Prism.Shared.Manifests.Types.Clusters
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

        #region Traits & Bindings

        public List<ITrait> DefaultTraits { get; set; } = new  List<ITrait>();
        public List<string> SignalBindings { get; set; } =new List<string>();

        IReadOnlyList<ITrait> ITraitBindable.DefaultTraits => DefaultTraits;
        IReadOnlyList<string> ITraitBindable.SignalBindings => SignalBindings;

        #endregion

        #region Child Cluster Containment

        public List<Cluster> ChildClusters { get; private set; } = new List<Cluster>();

        #endregion

        #region Trait Propagation

        public void PropagateTraitBundle(IEnumerable<ITrait> traits)
        {
            var enumerable = traits.ToList();
            DefaultTraits = enumerable.ToList(); // Apply to self
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