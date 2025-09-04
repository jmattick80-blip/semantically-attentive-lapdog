using System;

namespace Prism.Shared.Contracts.Runtime.Phases.Results;

public class PhaseResultBlock
{
    public string PhaseName { get; set; }
    public TimeSpan Duration { get; set; }
    public string MoodImpact { get; set; }
    public PrismResult Result { get; set; }
    public string Summary => Result.Message;
}