using System.Threading.Tasks;

namespace Prism.Shared.Contracts.Interfaces.Runtime.Phases;

public interface IRuntimePhase
{
    Task<PrismResult> RunAsync();
}
