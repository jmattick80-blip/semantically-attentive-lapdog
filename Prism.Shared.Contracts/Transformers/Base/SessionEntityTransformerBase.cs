using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.MeshLogic;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Interfaces.Transformers;

namespace Prism.Shared.Contracts.Transformers.Base
{
    public abstract class SessionEntityTransformerBase : ISessionEntityTransformer
    {
        protected SessionEntityTransformerBase(bool isRequired)
        {
            IsRequired = isRequired;
        }

        public abstract string TransformerType { get; }
        public bool IsRequired { get; }

        // Generic interface implementation
        public object Transform(object entity, Dictionary<string, object> parameters)
        {
            if (entity is not ISessionEntity sessionEntity)
                throw new InvalidOperationException($"Transformer '{TransformerType}' only supports ISessionEntity types.");

            return Transform(sessionEntity, parameters);
        }

        // Typed session entity transformation
        public abstract ISessionEntity Transform(ISessionEntity entity, Dictionary<string, object> parameters);

        // Utility: Timestamping
        protected DateTime GetTimestamp() => DateTime.UtcNow;

        // Utility: Metadata merging
        protected Dictionary<string, object> MergeMetadata(Dictionary<string, object> existing, Dictionary<string, object> updates)
        {
            var merged = new Dictionary<string, object>(existing);
            foreach (var kvp in updates)
            {
                merged[kvp.Key] = kvp.Value;
            }
            return merged;
        }
    }
}