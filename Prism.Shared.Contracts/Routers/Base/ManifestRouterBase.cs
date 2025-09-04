using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Envelopes;
using Prism.Shared.Contracts.Interfaces.Routers;

namespace Prism.Shared.Contracts.Routers.Base;

public abstract class ManifestRouterBase : IManifestFlowRouter
{
    protected ManifestRouterDescriptor Descriptor { get; private set; } = new();

    protected readonly List<string> RoutingNotes = new();

    public virtual void InflateFromDescriptor(ManifestRouterDescriptor descriptor)
    {
        Descriptor = descriptor ?? new ManifestRouterDescriptor();
    }

    protected string Phase => Descriptor?.Phase ?? "unspecified";
    protected string Tone => Descriptor?.Tone ?? "neutral";
    public string StrategyName => Descriptor?.StrategyName ?? "Unnamed Router";

    public abstract ManifestRoutingResult Route(IIntentEnvelope envelope);

    protected void AnnotateEnvelope(IIntentEnvelope envelope)
    {
        if (RoutingNotes.Count == 0)
        {
            RoutingNotes.AddRange(Descriptor?.FallbackNotes ?? new List<string>
            {
                $"Routing via '{StrategyName}' strategy.",
                $"Phase: {Phase}",
                $"Tone: {Tone}"
            });
        }

        envelope.AddNotes(RoutingNotes);
    }

    public IEnumerable<string> GetRoutingNotes() => RoutingNotes;
}