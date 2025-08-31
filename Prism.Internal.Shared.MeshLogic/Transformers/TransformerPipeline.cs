using Prism.Internal.Shared.MeshLogic.Interfaces;
using Prism.Shared.Contracts.Interfaces;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Internal.Shared.MeshLogic.Transformers
{
    public class TransformerPipeline
    {
        private readonly List<IEntityTransformer> _transformers;

        public TransformerPipeline(IEnumerable<IEntityTransformer> transformers)
        {
            _transformers = transformers.ToList();
        }

        public ISessionEntity ApplyAll(ISessionEntity entity, Dictionary<string, object> payload)
        {
            foreach (var transformer in _transformers)
            {
                var transformed = transformer.Transform(entity, payload) as ISessionEntity;
                if (transformed != null)
                {
                    entity = transformed;
                }
            }

            return entity;
        }
    }
    #region Summary
// TransformerPipeline applies a sequence of IEntityTransformer instances to a session-scoped entity.
// Each transformer mutates the entity based on payload parameters, enabling modular consequence routing.
// This pipeline supports mood deltas, trait injection, curator overlays, and future transformation types.
// It ensures narratable, contributor-safe mutation across sessions, roles, and emotional mesh triggers.
    #endregion
}