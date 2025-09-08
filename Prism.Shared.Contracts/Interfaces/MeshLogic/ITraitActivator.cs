using System.Collections.Generic;

namespace Prism.Shared.Contracts.Interfaces.MeshLogic;


public interface ITraitActivator
{
    /// <summary>
    /// Returns activated traits based on ripple signals.
    /// </summary>
    IEnumerable<string> ActivateTraits(Dictionary<string, float> rippleSignals, string contributorId);
}
/// <summary>
/// Activates traits based on ripple signals and contributor context.
/// Used to trigger emotional consequence and mesh-layer feedback.
/// JM ✦ Prism Architect ✦ 2025-09-08
/// </summary>