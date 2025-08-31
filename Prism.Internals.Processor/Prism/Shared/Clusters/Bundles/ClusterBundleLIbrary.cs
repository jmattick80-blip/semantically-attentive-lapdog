using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;
using GalleryDrivers.Prism.Shared.Manifests.Types.Clusters;
using GalleryDrivers.Prism.Shared.Manifests.Types.Intents;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Traits;

namespace GalleryDrivers.Prism.Shared.Clusters.Bundles
{
    public static class ClusterBundleLibrary
    {
        private static readonly List<ClusterBundle> Bundles =new List<ClusterBundle>();

        static ClusterBundleLibrary()
        {
            Bundles.Add(CreateCoreClusterBundle());
            Bundles.Add(CreateIntentClusterBundle());
            // Add more bundles here as needed
        }

        public static IEnumerable<ClusterBundle> GetAll() => Bundles;

        private static ClusterBundle CreateCoreClusterBundle()
        {
            var clusterManifest = new ClusterManifest(manifestId:"Prism.CoreCluster", displayName:"Prism.CoreCluster", description:"Orchestrates contributor onboarding and manifest resolution.")
            {
                DefaultTraits = new List<ITrait> { TraitLibrary.Narratable, TraitLibrary.ContributorSafe },
                SignalBindings = new List<string> { nameof(IManifest) }
            };

            var onboardingIntent = new IntentManifest(
                manifestId: "Prism.CoreCluster.Onboarding",
                displayName: "Prism.CoreCluster.OnboardingIntent",
                description: "Resolves contributor onboarding intent.",
                defaultTraits: new List<ITrait> { TraitLibrary.Onboarding },
                signalBindings: new List<string> { nameof(IManifest) }
            );


            return new ClusterBundle(clusterManifest, new List<IntentManifest> { onboardingIntent });
        }

        private static ClusterBundle CreateIntentClusterBundle()
        {
            var clusterManifest = new ClusterManifest("Prism.IntentCluster", "Prism.IntentCluster", "Handles contributor intent resolution and trait propagation.")
            {
                DefaultTraits = new List<ITrait> { TraitLibrary.IntentBound, TraitLibrary.Narratable },
                SignalBindings = new List<string> { nameof(IManifest) }
            };

            var actionIntent = new IntentManifest(
                manifestId: "Prism.IntentCluster.Action",
                displayName: "Prism.IntentCluster.ActionIntent",
                description: "Handles contributor action intent resolution.",
                defaultTraits: new List<ITrait> { TraitLibrary.IntentBound },
                signalBindings: new List<string> { nameof(IManifest) }
            );

            return new ClusterBundle(clusterManifest, new List<IntentManifest> { actionIntent });
        }
    }
}