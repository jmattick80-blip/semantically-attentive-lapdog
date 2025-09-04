using System.Collections.Generic;
using Prism.Shared.Contracts.Agents;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Sessions.Session.SessionDependencies;

public interface ISessionDependencyResolver
{
    IEnvelopeValidator ResolveValidator(SessionContext context);
    IManifestFlowRouter ResolveRouter(SessionContext context);
    ICallbackDispatcher ResolveDispatcher(SessionContext context);
    List<NpcDefinition> ResolveNpcDefinitions(SessionContext context);
}
#region SessionDependencyResolver – Resolves session-scoped services based on context

// Provides narratable access to session-specific dependencies.
// Each method interprets context to expose the right validator, resolver, dispatcher, or NPC definitions.
// This resolver acts as a semantic gateway for runtime orchestration, ensuring contributor-safe flows.

#endregion