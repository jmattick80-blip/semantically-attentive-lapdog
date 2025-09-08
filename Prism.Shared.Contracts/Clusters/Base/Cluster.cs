using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Sessions.Session.Types;

namespace Prism.Shared.Contracts.Clusters.Base
{
    /// <summary>
    /// Represents a narratable, trait-driven cluster within Prism.
    /// Handles manifest registration, session binding, and trait orchestration.
    /// </summary>
    public class Cluster : ClusterBase, ICluster
    {
        private List<ITrait> _activeTraits = new  List<ITrait>();

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

        public void ReceiveTraits(IEnumerable<ITrait> traits)
        {
            var enumerable = traits.ToList();
            if (!enumerable.Any())
            {
                Log("⚠️ Received empty or null trait bundle—no traits applied.");
                return;
            }

            _activeTraits.Clear();
            _activeTraits.AddRange(enumerable);
            Log($"🔁 Traits received and activated: {string.Join(", ", _activeTraits.Select(t => t.TraitName))}");
        }


        protected sealed override void ActivateDefaultTraits()
        {
            _activeTraits.AddRange(Manifest.DefaultTraits);
            Log($"🧬 Default traits activated: {string.Join(", ", _activeTraits.Select(t => t.TraitName))}");
        }
    }
    // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 🧠 Summary Region: Cluster
//
// Represents a narratable, trait-driven simulation cluster.
// Handles manifest registration, session binding, trait orchestration,
// and interface exposure for transformation routing.
//
// ┌─────────────────────────────────────────────────────────────────────────┐
// │ Responsibilities                                                       │
// ├─────────────────────────────────────────────────────────────────────────┤
// │ • Register cluster from manifest and expose ClusterId                  │
// │ • Activate and receive traits for simulation behavior                  │
// │ • Bind cluster to session and log activation/deactivation              │
// │ • Expose supported interfaces from child manifests                     │
// └─────────────────────────────────────────────────────────────────────────┘
//
// 🔗 Dependencies:
// - IClusterManifest (for metadata and default traits)
// - IIntentManifest (for signal bindings)
// - PrismSession (for session binding)
//
// 🧩 Emotional Consequence:
// - Enables narratable trait orchestration across simulation clusters
// - Supports prefab-safe session binding and transformation routing
// - Actively used in runtime flows and registry hydration
//
// ✦ Maintainer: Jeremy M.
// ✦ Last Audited: Sprint 5 – 2025-09-07
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
}