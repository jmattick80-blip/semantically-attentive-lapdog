using System.Collections.Generic;
using Prism.Shared.Contracts.Agents;

namespace Prism.Shared.Contracts.Sessions.Session.SessionDependencies;

public interface INpcFactory
{
    List<NpcDefinition> BuildFromSeed(int gallerySeedNumber);
}