using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.MeshLogic;

namespace Prism.Internal.Shared.MeshLogic.Implementations;

public class PrismTraitActivator : ITraitActivator
{
    public IEnumerable<string> ActivateTraits(Dictionary<string, float> rippleSignals, string contributorId)
    {
        var activated = new List<string>();
        foreach (var kvp in rippleSignals)
        {
            if (kvp.Value > 0.5f)
            {
                activated.Add($"trait:{kvp.Key}");
            }
        }
        return activated;
    }

    #region Prism implementation of ITraitActivator.
    /// <summary>
    /// Activates traits based on ripple signal thresholds.
    /// JM ✦ Prism Architect ✦ 2025-09-08
    /// </summary>
    #endregion
}