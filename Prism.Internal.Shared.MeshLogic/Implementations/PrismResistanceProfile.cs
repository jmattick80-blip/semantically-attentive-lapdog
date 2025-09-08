using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.MeshLogic;

namespace Prism.Internal.Shared.MeshLogic.Implementations;

public class PrismResistanceProfile : IMeshResistanceProfile
{
    public Dictionary<string, float> ApplyResistance(Dictionary<string, float> moodDeltas, string contributorPhase)
    {
        float resistanceFactor = contributorPhase == "Curator" ? 0.8f : 1.0f;
        var resisted = new Dictionary<string, float>();
        foreach (var kvp in moodDeltas)
        {
            resisted[kvp.Key] = kvp.Value * resistanceFactor;
        }
        return resisted;
    }

    #region Prism implementation of IMeshResistanceProfile.
    /// <summary>
    /// Applies phase-based dampening to mood deltas before propagation.
    /// JM ✦ Prism Architect ✦ 2025-09-08
    /// </summary>
    #endregion
}