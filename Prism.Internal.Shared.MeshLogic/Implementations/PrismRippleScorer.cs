using Prism.Shared.Contracts.Interfaces.MeshLogic;

namespace Prism.Internal.Shared.MeshLogic.Implementations;

public class PrismRippleScorer : IRippleScorer
{
    public float ScoreRipple(Dictionary<string, float> modulatedDeltas, IEnumerable<string> traits)
    {
        float traitWeight = traits != null ? traits.Count() * 0.1f : 0f;
        float score = 0f;
        foreach (var kvp in modulatedDeltas)
        {
            score += kvp.Value;
        }
        return score + traitWeight;
    }

    #region Prism implementation of IRippleScorer.
    /// <summary>
    /// Scores ripple impact by summing modulated deltas and trait weight.
    /// JM ✦ Prism Architect ✦ 2025-09-08
    /// </summary>
    #endregion
}