using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Shared.Contracts.Agents;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Registries;
using Prism.Shared.Contracts.Sessions.Session.Types;

namespace Prism.Shared.Contracts.Interfaces.Types;

public interface IPrismBootstrapper
{
    string Role { get; }
    Task<PrismResult> InitializeAsync(
        SessionContext sessionContext,
        IEnvelopeValidator validator,
        IManifestRegistryResolver resolver,
        ICallbackDispatcher dispatcher,
        ITraitRouter traitRouter,
        string contributorId,
        string role,
        List<NpcDefinition> npcDefinitions
    );

    RuntimeSession Session { get; }
    ClusterRegistry ClusterRegistry { get; }
    IntentRegistry IntentRegistry { get; }
}
