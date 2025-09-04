using System.Collections.Generic;

namespace Prism.Shared.Contracts.Interfaces.MeshLogic;

public interface IEntityTransformer
{
    string TransformerType { get; }
    bool IsRequired { get; } // Signals whether this transformer must be applied
    object Transform(object entity, Dictionary<string, object> parameters);
}