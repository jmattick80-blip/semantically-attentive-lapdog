using System.Collections.Generic;
using Prism.Shared.Contracts.Manifests.Types.Clusters;
using Prism.Shared.Contracts.Manifests.Types.Intents;

namespace Prism.Shared.Contracts.Clusters.Bundles
{
    public class ClusterBundle
    {
        public ClusterManifest ClusterManifest;
        public List<IntentManifest> Intents;

        public ClusterBundle(ClusterManifest clusterManifest, List<IntentManifest> intents)
        {
            ClusterManifest = clusterManifest;
            Intents = intents;
        }
    }
    // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 🧠 Summary Region: ClusterBundle
//
// Represents a packaged bundle of cluster and intent manifests.
// Used to group simulation logic, trait orchestration, and transformation flows
// into prefab-safe units for registry hydration or scenario deployment.
//
// ┌─────────────────────────────────────────────────────────────────────────┐
// │ Responsibilities                                                       │
// ├─────────────────────────────────────────────────────────────────────────┤
// │ • Pair a ClusterManifest with its associated IntentManifests           │
// │ • Enable modular deployment of simulation clusters                     │
// │ • Support registry, scenario, and transformation routing               │
// └─────────────────────────────────────────────────────────────────────────┘
//
// 🔗 Dependencies:
// - ClusterManifest (defines cluster metadata and traits)
// - IntentManifest (defines transformation logic and signal bindings)
//
// 🧩 Emotional Consequence:
// - Enables narratable packaging of simulation logic
// - Prefab-safe and ready for registry or scenario tooling
// - Ideal for Unity bridge, IO handoff, or multiplayer orchestration
//
// ✦ Maintainer: Jeremy M.
// ✦ Last Audited: Sprint 5 – 2025-09-07
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
}