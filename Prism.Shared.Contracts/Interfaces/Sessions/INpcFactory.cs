using System.Collections.Generic;
using Prism.Shared.Contracts.Agents;

namespace Prism.Shared.Contracts.Interfaces.Sessions;

public interface INpcFactory
{
    List<NpcDefinition> BuildFromSeed(int gallerySeedNumber);
}