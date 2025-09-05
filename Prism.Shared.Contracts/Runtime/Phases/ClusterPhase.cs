using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Shared.Contracts.Clusters.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Runtime.Phases;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Manifests.Types.Clusters;
using Prism.Shared.Contracts.Manifests.Types.Intents;
using Prism.Shared.Contracts.Registries;
using Prism.Shared.Contracts.Runtime.Phases.Base;
using Prism.Shared.Contracts.Sessions.Session.Types;
using Prism.Shared.Contracts.Traits;

namespace Prism.Shared.Contracts.Runtime.Phases;

public class ClusterPhase : RuntimePhaseBase, IRuntimePhase
{
    private readonly ClusterRegistry _registry;

    public ClusterPhase(ClusterRegistry registry, RuntimeSession session)
        : base(session)
    {
        _registry = registry;
    }

    public override async Task<PrismResult> RunAsync()
    {
        /*var manifest = new ClusterManifest("Prism.CoreCluster", "Prism.CoreCluster", "Handles contributor onboarding.")
        {
            DefaultTraits = new List<ITrait> { TraitLibrary.Narratable, TraitLibrary.IntentBound },
            SignalBindings = new List<string> { nameof(IManifest) }
        };

        var cluster = new CoreCluster(manifest);

        var onboardingIntent = new IntentManifest(
            "Prism.CoreCluster.OnboardingRegistryResolver",
            "Prism.CoreCluster.OnboardingIntent",
            "Resolves contributor onboarding intent.",
            new List<ITrait> { TraitLibrary.Onboarding },
            new List<string> { nameof(IManifest) });

        cluster.AddChild(onboardingIntent);
        _registry.RegisterManifest(manifest);

        SummaryLines.Add("🧩 CoreCluster registered.");
        SummaryLines.Add("🎯 OnboardingIntent attached to CoreCluster.");
        */

        await Task.CompletedTask;
        return new PrismResult(NarrateSummary(), Session);
    }
}