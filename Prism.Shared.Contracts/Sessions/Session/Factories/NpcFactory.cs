using System.Collections.Generic;
using Prism.Shared.Contracts.Agents;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Sessions.Session.Factories;

public class NpcFactory : INpcFactory
{
    public List<NpcDefinition> BuildFromSeed(int seed)
    {
        // For now, return a static list or use seed to vary tone/role
        return new List<NpcDefinition>
        {
            new NpcDefinition { NpcId = "npc-001", DisplayName = "Tom" }
        };
    }
}