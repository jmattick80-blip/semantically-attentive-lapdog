using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryDrivers.Prism.Runtime.Registries;
using GalleryDrivers.Prism.Shared.Clusters.Types;
using GalleryDrivers.Prism.Shared.DataPackages;
using GalleryDrivers.Prism.Shared.Interfaces.Registries;
using GalleryDrivers.Prism.Shared.Interfaces.Session;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;
using GalleryDrivers.Prism.Shared.Manifests.Types.Clusters;
using GalleryDrivers.Prism.Shared.Manifests.Types.Intents;
using GalleryDrivers.Prism.Shared.Sessions.Types;
using GalleryDrivers.Prism.Shared.Traits;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;

namespace GalleryDrivers.Prism.Runtime.Bootstrap
{
    public static class PrismRuntimeBootstrap
    {
        private static ClusterRegistry _clusterRegistry;
        private static IntentRegistry _intentRegistry;
        private static RuntimeSession _session;

        private static readonly List<IManifestRegistryBase> RegisteredManifests = new List<IManifestRegistryBase>();

        public static async Task<PrismResult> InitializeAsync(
            IEnvelopeValidator validator,
            IManifestRegistryRouter router,
            ICallbackDispatcher dispatcher,
            string contributorId,
            string role)
        {
            if (_session != null)
                return new PrismResult("⚠️ Session already initialized.", _session);

            _clusterRegistry = new ClusterRegistry();
            _intentRegistry = new IntentRegistry();



            _session = new RuntimeSession(validator, router, dispatcher, contributorId, role);
            await Task.Run(() => _session.StartSessionAsync());

            var clusterRegistryResult = RegisterManifest(_clusterRegistry);
            var intentRegistryResult = RegisterManifest(_intentRegistry);

            var coreResult = await RegisterCoreClusterAsync();
            var intentResult = await RegisterIntentClusterAsync();
            var globalResult = await RegisterGlobalIntentsAsync();

            var summary = new List<string>
            {
                clusterRegistryResult.Message,
                intentRegistryResult.Message,
                coreResult.Message,
                intentResult.Message,
                globalResult.Message
            };

            return new PrismResult($"🧠 PrismRuntimeBootstrap: Startup complete.\n{string.Join("\n", summary)}", _session);
        }
        
        private static PrismResult RegisterManifest(IManifestRegistryBase manifest)
        {
            if (manifest == null || RegisteredManifests.Contains(manifest))
            {
                return new PrismResult("⚠️ Manifest registration skipped: null or already registered.", _session);
            }

            RegisteredManifests.Add(manifest);

            var displayName = manifest.GetNarratableManifests().FirstOrDefault()?.DisplayName ?? "Unnamed Registry";

            return new PrismResult($"🧩 Manifest registered: {displayName}.", _session);
        }

        private static async Task<PrismResult> RegisterCoreClusterAsync()
        {
            var manifest = new ClusterManifest(
                manifestId: "Prism.IntentCluster",
                displayName: "Prism.IntentCluster",
                description: "Handles contributor intent resolution and trait propagation."
            );

            manifest.DefaultTraits = new List<ITrait> {
                TraitLibrary.Narratable,
                TraitLibrary.IntentBound
            };

            manifest.SignalBindings = new List<string> {
                nameof(IManifest)
            };

            var coreCluster = new CoreCluster(manifest);

            var onboardingIntent = new IntentManifest(
                manifestId: "Prism.CoreCluster.Onboarding",
                displayName: "Prism.CoreCluster.OnboardingIntent",
                description: "Resolves contributor onboarding intent.",
                defaultTraits: new List<ITrait> { TraitLibrary.Onboarding },
                signalBindings: new List<string> { nameof(IManifest) }
            );

            coreCluster.AddChild(onboardingIntent);

            await Task.CompletedTask;

            return new PrismResult("🧠 PrismRuntimeBootstrap: CoreCluster registered with OnboardingIntent.", _session);
        }
        
        private static async Task<PrismResult> RegisterIntentClusterAsync()
        {
            var manifest = new ClusterManifest(
                manifestId: "Prism.IntentCluster",
                displayName: "Prism.IntentCluster",
                description: "Handles contributor intent resolution and trait propagation."
            );

            // Assign additional properties after construction
            manifest.DefaultTraits = new List<ITrait> {
                TraitLibrary.IntentBound,
                TraitLibrary.Narratable
            };

            manifest.SignalBindings = new List<string> {
                nameof(IManifest)
            };

            var intentCluster = new IntentCluster(manifest);

            var actionIntent = new IntentManifest(
                manifestId: "Prism.IntentCluster.Action",
                displayName: "Prism.IntentCluster.ActionIntent",
                description: "Handles contributor action intent resolution.",
                defaultTraits: new List<ITrait> { TraitLibrary.IntentBound },
                signalBindings: new List<string> { nameof(IManifest) }
            );


            intentCluster.AddChild(actionIntent);

            await Task.CompletedTask;

            return new PrismResult("🧠 PrismRuntimeBootstrap: IntentCluster registered with ActionIntent.", _session);
        }

        private static async Task<PrismResult> RegisterGlobalIntentsAsync()
        {
            var shutdownIntent = new IntentManifest(
                manifestId: "Prism.System",
                displayName: "Prism.System.ShutdownIntent",
                description: "Handles system shutdown and contributor exit flow.",
                defaultTraits: new List<ITrait> { TraitLibrary.SystemLevel },
                signalBindings: new List<string> { nameof(IManifest) }
            );

            _intentRegistry.RegisterManifest(shutdownIntent);
            await Task.CompletedTask; // Keeps async signature valid
            return new PrismResult("🧠 PrismRuntimeBootstrap: Global intents registered.", _session);
        }

        public static RuntimeSession GetSession() => _session;
        public static ClusterRegistry GetClusterRegistry() => _clusterRegistry;
        public static IntentRegistry GetIntentRegistry() => _intentRegistry;
    }
}
