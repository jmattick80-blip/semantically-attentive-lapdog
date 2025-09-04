using Prism.Shared.Contracts.Interfaces.Envelopes;
using Prism.Shared.Contracts.Routers;

namespace Prism.Shared.Contracts.Interfaces.Routers;

public interface IManifestFlowRouter
{
    ManifestRoutingResult Route(IIntentEnvelope envelope);
}
#region IManifestFlowRouter – End Summary (August 31, 2025)

// This interface defines the contract for routing intent envelopes within Prism OS.
// It accepts any IIntentEnvelope and returns a narratable ManifestRoutingResult.
// Implementations interpret contributor phase, tone, and context to guide manifest flow.
// The interface is domain-neutral, emotionally legible, and safe for future editors.

#endregion