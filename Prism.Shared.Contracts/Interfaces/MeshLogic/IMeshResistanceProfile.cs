using System.Collections.Generic;

namespace Prism.Shared.Contracts.Interfaces.MeshLogic;

public interface IMeshResistanceProfile
{
    /// <summary>
    /// Applies resistance to mood deltas before propagation.
    /// </summary>
    Dictionary<string, float> ApplyResistance(Dictionary<string, float> moodDeltas);
}
/// <summary>
/// Applies resistance or dampening to mesh propagation.
/// Used to shape consequence flow based system state.
/// JM ✦ Prism Architect ✦ 2025-09-08
/// </summary>