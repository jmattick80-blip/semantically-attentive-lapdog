using System.Threading.Tasks;
using Prism.Shared.Contracts.Registries;
using Prism.Shared.Contracts.Sessions.Session.Types;

namespace Prism.Shared.Contracts.Interfaces.Types
{
    /// <summary>
    /// Interface for Prism runtime processors.
    /// Defines contract for session orchestration and runtime startup.
    /// </summary>
    public interface IPrismRuntime
    {
        string Role { get; }
        Task<PrismResult> StartAsync();
        RuntimeSession Session { get; }
        ClusterRegistry ClusterRegistry { get; }
        IntentRegistry IntentRegistry { get; }
    }
}