using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Manifests.Types.Intents;

namespace Prism.Shared.Contracts.Clusters.Types
{
    public class CoreCluster : ClusterBase
    {
        protected IEnumerable<ManifestBase> ManifestChildren => Children.OfType<ManifestBase>();
        
        public CoreCluster(IClusterManifest manifest) : base(manifest)
        {
            
        }

        public IEnumerable<IntentManifest> GetOnboardingManifests()
        {
            return GetManifestsOfType<IntentManifest>();
        }

        private IEnumerable<T> GetManifestsOfType<T>() where T : ManifestBase
        {
            return ManifestChildren.OfType<T>();
        }
    }
    // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 🧠 Summary Region: CoreCluster
//
// Represents a simulation cluster focused on contributor onboarding.
// Provides access to onboarding-related intent manifests and supports
// manifest filtering via generic type resolution.
//
// ┌─────────────────────────────────────────────────────────────────────────┐
// │ Responsibilities                                                       │
// ├─────────────────────────────────────────────────────────────────────────┤
// │ • Bind to cluster manifest and expose onboarding intents               │
// │ • Filter child manifests by type                                       │
// │ • Support contributor-safe bootstrapping flows                         │
// └─────────────────────────────────────────────────────────────────────────┘
//
// 🔗 Dependencies:
// - IClusterManifest
// - IntentManifest
//
// 🧩 Emotional Consequence:
// - Enables narratable onboarding flows for contributors
// - Prefab-safe and ready for registry hydration
// - Ideal for scenario editors and mesh bootstrapping
//
// ✦ Maintainer: Jeremy M.
// ✦ Last Audited: Sprint 5 – 2025-09-07
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
}