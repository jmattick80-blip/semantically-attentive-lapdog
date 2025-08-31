using Prism.Internal.Shared.MeshLogic.Transformers.Base;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Internal.Shared.MeshLogic
{
    public class MoodTransformer : SessionEntityTransformerBase
    {
        public MoodTransformer() : base(true) { }

        public override string TransformerType => "Mood";
        
        public override ISessionEntity Transform(ISessionEntity entity, Dictionary<string, object> parameters)
        {
            if (entity is not SessionEntityState state)
                throw new InvalidOperationException("Unsupported entity type.");

            if (!parameters.TryGetValue("MoodDelta", out var deltaObj) || deltaObj is not Dictionary<string, float> moodDelta)
                throw new ArgumentException("Missing or invalid MoodDelta.");

            var transformedMood = TransformMood(state.MoodVector, moodDelta);

            return new SessionEntityState
            {
                EntityId = state.EntityId,
                EntityType = state.EntityType,
                SessionId = state.SessionId,
                MoodVector = transformedMood,
                Metadata = MergeMetadata(state.Metadata, new() { { "MoodVector", transformedMood } }),
                IsDraft = state.IsDraft,
                Timestamp = GetTimestamp()
            };
        }

        private Dictionary<string, float> TransformMood(Dictionary<string, float> current, Dictionary<string, float> delta)
        {
            var result = new Dictionary<string, float>(current);
            foreach (var kvp in delta)
            {
                result[kvp.Key] = result.ContainsKey(kvp.Key)
                    ? result[kvp.Key] + kvp.Value
                    : kvp.Value;
            }
            return result;
        }
    }
    #region MoodTransformer Summary 2025.08.28
    // MoodTransformer applies emotional deltas to session-scoped entities.
    // It updates the MoodVector and embeds it in metadata for mesh propagation, NPC reactions, and curator overlays.
    // This transformer supports narratable consequence, multiplayer-safe mutation, and legacy-grade emotional logic.
    // It is typically marked as required, ensuring emotional mesh integrity across sessions and contributor flows.
    #endregion
}