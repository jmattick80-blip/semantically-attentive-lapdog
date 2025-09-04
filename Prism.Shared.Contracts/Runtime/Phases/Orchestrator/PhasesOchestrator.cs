using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Shared.Contracts.Interfaces.Runtime.Phases;
using Prism.Shared.Contracts.Runtime.Phases.Results;

namespace Prism.Shared.Contracts.Runtime.Phases.Orchestrator;

public class PhasesOrchestrator
{
    private readonly List<IRuntimePhase> _phases = new();

    public void AddPhase(IRuntimePhase phase) => _phases.Add(phase);

    public async Task<List<PhaseResultBlock>> RunAsync()
    {
        var results = new List<PhaseResultBlock>();
        foreach (var phase in _phases)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await phase.RunAsync();
            stopwatch.Stop();

            results.Add(new PhaseResultBlock
            {
                PhaseName = phase.GetType().Name,
                Duration = stopwatch.Elapsed,
                MoodImpact = InferMood(result),
                Result = result
            });
        }
        return results;
    }

    private string InferMood(PrismResult result)
    {
        return result.Message.Contains("⚠️") ? "Concerned" : "Confident";
    }
}