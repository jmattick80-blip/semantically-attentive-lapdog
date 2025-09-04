using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Intent.Identity.Fingerprint;
using Prism.Intent.Identity.Phase;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Runtime.Phases;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Interfaces.Types;
using Prism.Shared.Contracts.Manifests.Types.Intents;
using Prism.Shared.Contracts.Registries;
using Prism.Shared.Contracts.Runtime.Phases.Base;
using Prism.Shared.Contracts.Sessions.Session.Types;
using Prism.Shared.Contracts.Tone;
using Prism.Shared.Contracts.Traits;

namespace Prism.Shared.Contracts.Runtime.Phases;

public class IntentPhase : RuntimePhaseBase, IRuntimePhase
{
    private readonly IntentRegistry _registry;
    private readonly IPhaseContext _phaseContext;
    private readonly ToneResponseManifest _toneManifest;
    private readonly IIntentResolver _intentResolver;

    public IntentPhase(
        IntentRegistry registry,
        RuntimeSession session,
        IPhaseContext phaseContext,
        ToneResponseManifest toneManifest,
        IIntentResolver intentResolver)
        : base(session)
    {
        _registry = registry;
        _phaseContext = phaseContext;
        _toneManifest = toneManifest;
        _intentResolver = intentResolver;
    }

    public override async Task<PrismResult> RunAsync()
    {
        var actionIntent = new IntentManifest(
            manifestId: "Prism.IntentCluster.Action",
            displayName: "Prism.IntentCluster.ActionIntent",
            description: "Handles contributor action intent resolution.",
            defaultTraits: new List<ITrait> { TraitLibrary.IntentBound },
            signalBindings: new List<string> { nameof(IManifest) });

        var shutdownIntent = new IntentManifest(
            manifestId: "Prism.System",
            displayName: "Prism.System.ShutdownIntent",
            description: "Handles system shutdown and contributor exit flow.",
            defaultTraits: new List<ITrait> { TraitLibrary.SystemLevel },
            signalBindings: new List<string> { nameof(IManifest) });

        _registry.RegisterManifest(actionIntent);
        _registry.RegisterManifest(shutdownIntent);

        SummaryLines.Add("🎯 ActionIntent registered.");
        SummaryLines.Add("🛑 ShutdownIntent registered.");

        await Task.CompletedTask;
        return new PrismResult(NarrateSummary(), Session);
    }

    public PrismResult ResolveIntent(PrismIntentRequest request, ContributorFingerprint fingerprint)
    {
        var traceLogger = new TraceMeshLogger();
        var toneAdapter = new ToneResponseAdapter(_phaseContext, _toneManifest);

        traceLogger.LogIntent(request.Intent.IntentType, fingerprint, _phaseContext.GetPhase());

        var result = _intentResolver.Resolve(request);
        var modulated = toneAdapter.Modulate(result, fingerprint);

        traceLogger.LogResponse(request.Intent.IntentType, modulated.Feedback, fingerprint.Tone.Type.ToString(), modulated.Tags);

        return modulated;
    }

    #region IntentPhase Summary (Sprint 5 – August 31, 2025)
    // IntentPhase registers core contributor intents and resolves fingerprinted requests.
    // It routes through Prism’s emotional mesh, logging trace entries and modulating feedback
    // using contributor tone and authored consequence. Supports phase-aware routing and replay.
    #endregion
}