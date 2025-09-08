using System.Collections.Generic;

namespace Prism.Shared.Contracts.Interfaces.MeshLogic;

public interface IRippleScorer
{
    /// <summary>
    /// Calculates ripple score from modulated mesh impact.
    /// </summary>
    float ScoreRipple(Dictionary<string, float> modulatedDeltas, IEnumerable<string> traits);
}
/// <summary>
/// Scores ripple impact based on modulated deltas and contributor traits.
/// Used to determine emotional consequence and feedback intensity.
/// JM ✦ Prism Architect ✦ 2025-09-08
/// </summary>