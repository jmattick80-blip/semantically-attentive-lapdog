using System.Collections.Generic;

namespace Prism.Shared.Contracts.Interfaces.MeshLogic;

public interface IMeshPropagator
{
    /// <summary>
    /// Modulates contributor mood deltas across mesh layers.
    /// </summary>
    Dictionary<string, float> Propagate(Dictionary<string, float> moodDeltas, string contributorId);
}
/// <summary>
/// Defines how mood deltas propagate across mesh layers.
/// Used by MeshEngine to modulate contributor tone and ripple consequence.
/// JM ✦ Prism Architect ✦ 2025-09-08
/// </summary>