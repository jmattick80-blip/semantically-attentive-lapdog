using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Shared.Contracts.Interfaces.Runtime.Phases;
using Prism.Shared.Contracts.Sessions.Session.Types;

namespace Prism.Shared.Contracts.Runtime.Phases.Base;

public abstract class RuntimePhaseBase : IRuntimePhase
{
    protected readonly RuntimeSession Session;
    private readonly List<string> _summaryLines = new();

    public virtual string PhaseName => GetType().Name;

    public List<string> SummaryLines => _summaryLines;

    protected RuntimePhaseBase(RuntimeSession session)
    {
        Session = session;
    }

    public abstract Task<PrismResult> RunAsync();

    public virtual string NarrateSummary() => string.Join("\n", SummaryLines);
}