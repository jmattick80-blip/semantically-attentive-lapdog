namespace Prism.Internal.Shared.MeshLogic.Interfaces;

public interface IEntityTransformer
{
    string TransformerType { get; }
    bool IsRequired { get; } // Signals whether this transformer must be applied
    object Transform(object entity, Dictionary<string, object> parameters);
}