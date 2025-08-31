using System.Collections.Generic;
using System.Linq;
using GalleryDrivers.Prism.Shared.Interfaces.Clusters;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;
using GalleryDrivers.Prism.Shared.Sessions.Types;

namespace GalleryDrivers.Prism.Shared.Clusters.Base
{
    /// <summary>
    /// Represents a narratable, trait-driven cluster within Prism.
    /// Handles manifest registration, session binding, and trait orchestration.
    /// </summary>
    public class Cluster : ClusterBase, ICluster
    {
        private readonly List<ITrait> _activeTraits = new  List<ITrait>();

        public Cluster(IClusterManifest manifest)
            : base(manifest)
        {
            ClusterId = manifest.ManifestId;
            IsNarratable = manifest.IsNarratable;
            ActivateDefaultTraits();
        }

        public string ClusterId { get; }
        public bool IsNarratable { get; }

        public IEnumerable<ITrait> GetActiveTraits() => _activeTraits;

        public IEnumerable<string> GetSupportedInterfaces()
        {
            return Children
                .OfType<IIntentManifest>()
                .SelectMany(m => m.SignalBindings)
                .Distinct();
        }

        public void BindToSession(PrismSession session)
        {
            session.BindToCluster(ClusterId);
            Log($"🔗 Cluster bound to session: {session.SessionId}");
        }

        public void ActivateCluster()
        {
            ActivateDefaultTraits();
            Log($"✅ Cluster activated: {ClusterId}");
        }

        public void DeactivateCluster()
        {
            _activeTraits.Clear();
            Log($"❎ Cluster deactivated: {ClusterId}");
        }

        protected sealed override void ActivateDefaultTraits()
        {
            _activeTraits.AddRange(Manifest.DefaultTraits);
            Log($"🧬 Default traits activated: {string.Join(", ", _activeTraits.Select(t => t.TraitName))}");
        }
    }
}