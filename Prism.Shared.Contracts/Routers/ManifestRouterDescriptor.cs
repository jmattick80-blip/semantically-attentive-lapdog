using System.Collections.Generic;

namespace Prism.Shared.Contracts.Routers;

public class ManifestRouterDescriptor
{
    public string StrategyName { get; set; } = "Unnamed Router";
    public string Phase { get; set; } = "unspecified";
    public string Tone { get; set; } = "neutral";
    public List<string> FallbackNotes { get; set; } = new()
    {
        "Routing via fallback strategy.",
        "No phase-specific resolver was registered.",
        "Consider defining a custom resolver for richer flow control."
    };
}