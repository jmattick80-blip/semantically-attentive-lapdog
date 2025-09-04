using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Shared.Contracts.Agents;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Registries;
using Prism.Shared.Contracts.Sessions.Session.Types;

namespace Prism.Shared.Contracts.Interfaces.Types;

public interface IPrismBootstrapper
{
    string Role { get; }
    Task<PrismResult> InitializeAsync(
        IEnvelopeValidator validator,
        IManifestRegistryResolver resolver,
        ICallbackDispatcher dispatcher,
        string contributorId,
        string role,
        List<NpcDefinition> npcDefinitions
    );

    RuntimeSession Session { get; }
    ClusterRegistry ClusterRegistry { get; }
    IntentRegistry IntentRegistry { get; }
}
