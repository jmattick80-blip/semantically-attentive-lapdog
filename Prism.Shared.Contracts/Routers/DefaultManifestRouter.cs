using System.Linq;
using Prism.Shared.Contracts.Interfaces.Envelopes;
using Prism.Shared.Contracts.Routers.Base;

namespace Prism.Shared.Contracts.Routers;

public sealed class DefaultManifestRouter : ManifestRouterBase
{
    public DefaultManifestRouter(ManifestRouterDescriptor descriptor)
    {
        InflateFromDescriptor(descriptor);
    }

    public override ManifestRoutingResult Route(IIntentEnvelope envelope)
    {
        AnnotateEnvelope(envelope);

        return new ManifestRoutingResult
        {
            Target = "DefaultFlow",
            Strategy = Phase,
            Tone = Tone,
            IsFallback = true,
            Notes = GetRoutingNotes().ToList()
        };
    }

    #region DefaultManifestRouter – End Summary (August 31, 2025)

    // This sealed resolver uses a descriptor to define its strategy, tone, and fallback notes.
    // If no notes are added during routing, the descriptor provides emotionally legible defaults.
    // This allows contributors to narrate fallback behavior without writing custom logic.
    // All routing flows are safe, extensible, and narratable for future editors.

    #endregion
}