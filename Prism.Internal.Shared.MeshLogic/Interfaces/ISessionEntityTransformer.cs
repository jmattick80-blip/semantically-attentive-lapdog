using Prism.Shared.Contracts.Interfaces;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Internal.Shared.MeshLogic.Interfaces;

public interface ISessionEntityTransformer : IEntityTransformer
{
    ISessionEntity Transform(ISessionEntity entity, Dictionary<string, object> parameters);
    
}