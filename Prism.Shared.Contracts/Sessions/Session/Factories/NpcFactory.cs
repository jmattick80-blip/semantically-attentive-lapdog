using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Agents;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Sessions.Session.Factories
{
    public class NpcFactory : INpcFactory
    {
        public List<NpcDefinition> BuildFromSeed(int seed, SessionContext context)
        {
            // Simply return prefab-safe NPCs from context
            return context.NpcDefinitions
                .Select(npc => new NpcDefinition
                {
                    NpcId = npc.NpcId,
                    DisplayName = npc.DisplayName
                })
                .ToList();
        }
    }
}