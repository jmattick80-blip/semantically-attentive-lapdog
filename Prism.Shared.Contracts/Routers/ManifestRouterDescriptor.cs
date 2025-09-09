using System.Collections.Generic;

namespace Prism.Shared.Contracts.Routers;

public class ManifestRouterDescriptor
{
    public string StrategyName { get; set; } = "Unnamed Router";
    public string Tone { get; set; } = "neutral";
    public List<string> FallbackNotes { get; set; } = new()
    {
        "Routing via fallback strategy.",
        "Consider defining a custom resolver for richer flow control."
    };
}