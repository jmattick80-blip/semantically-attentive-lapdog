using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Events;

namespace Prism.Shared.Contracts;

public class MeshProfile
{
    public string ContributorId { get; set; } = string.Empty;
    public string IntentType { get; set; } = string.Empty;
    public string MoodVector { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public List<RippleEvent>? RippleHistory { get; set; }
    // Optional: for emotional consequence tracking
    public Dictionary<string, float>? LayerWeights { get; set; }

    // Optional: for tone modulation or fallback triggers
    public Dictionary<string, string>? ToneTags { get; set; }

    // Optional: for session-based mesh drift analysis
    public string? Phase { get; set; }
    public string? ClusterId { get; set; }

    // Optional: for contributor role or domain tagging
    public List<string>? Tags { get; set; }
}