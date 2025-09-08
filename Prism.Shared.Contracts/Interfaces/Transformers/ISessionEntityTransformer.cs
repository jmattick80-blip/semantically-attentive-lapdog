using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.MeshLogic;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Interfaces.Transformers;

public interface ISessionEntityTransformer : IEntityTransformer
{
    ISessionEntity Transform(ISessionEntity entity, Dictionary<string, object> parameters);
    
}