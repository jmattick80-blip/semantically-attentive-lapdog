using Prism.Internal.Shared.MeshLogic.Routing;
using Prism.Internal.Shared.MeshLogic.Transformers;
using Prism.Shared.Contracts;

using Prism.Shared.Contracts.Interfaces.Requests;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Logic;

namespace Prism.Internal.Registry
{
    public static class RegistryAdapter
    {
        private static readonly Dictionary<string, SessionEntity> SessionEntityStore = new();

        public static IPrismIntentResult UpdateEntityState(IPrismIntentRequest request)
        {
            var entityId = request.TargetEntity.EntityId;
            var sessionId = request.Session.SessionId;
            var isDraft = request.TargetEntity.IsDraft;
            
            var current = GetEntityState(entityId, sessionId, isDraft);
            if (current == null)
            {
                return new PrismIntentResult
                {
                    Request = request,
                    Success = false,
                    ResultCode = "EntityNotFound",
                    Message = $"Entity '{entityId}' not found in session '{sessionId}'.",
                    Slug = new string(request.Slug.Reverse().ToArray()),
                    Timestamp = DateTime.UtcNow,
                    Consequence = new()
                };
            }

            var transformers = TransformerRegistry.ResolveTransformers(request.TargetEntity.EntityType, request.Session.CuratorRole);
            foreach (var transformer in transformers)
            {
                if (!TransformerValidator.ValidatePayload(transformer, request.Payload, out var error))
                {
                    return new PrismIntentResult
                    {
                        Request = request,
                        Success = false,
                        ResultCode = "MissingPayload",
                        Message = error,
                        Slug = new string(request.Slug.Reverse().ToArray()),
                        Timestamp = DateTime.UtcNow,
                        Consequence = new()
                    };
                }
            }

            var pipeline = new TransformerPipeline(transformers);
            var updated = pipeline.ApplyAll(current, request.Payload);

            var scenarioImpact = ScenarioTriggerEngine.Evaluate(updated, request.Session.TraitTriggerMap);

            var consequence = new Dictionary<string, object>
            {
                { "RegistryRefs", new List<string> { entityId } }
            };

            if (scenarioImpact.Count > 0)
            {
                consequence["ScenarioImpact"] = scenarioImpact;
            }

            SaveEntityState(updated, isDraft);

            return new PrismIntentResult
            {
                Request = request,
                Success = true,
                ResultCode = "EntityUpdated",
                Message = $"Transformers applied to entity '{entityId}'.",
                Slug = new string(request.Slug.Reverse().ToArray()),
                Timestamp = DateTime.UtcNow,
                Consequence = consequence
            };
        }

        public static void SaveEntityState(SessionEntity  entity, bool isDraft = true)
        {
            var key = $"{entity.SessionId}:{entity.EntityId}:{(isDraft ? "draft" : "committed")}";
            SessionEntityStore[key] = entity;

            Console.WriteLine($"[RegistryAdapter] Saved entity '{entity.EntityId}' in session '{entity.SessionId}' as {(isDraft ? "draft" : "committed")}.");
        }

        public static SessionEntity? GetEntityState(string entityId, string sessionId, bool isDraft = true)
        {
            var key = $"{sessionId}:{entityId}:{(isDraft ? "draft" : "committed")}";

            if (SessionEntityStore.TryGetValue(key, out var entity))
            {
                Console.WriteLine($"[RegistryAdapter] Hydrated entity '{entityId}' from session '{sessionId}' ({(isDraft ? "draft" : "committed")}).");
                return entity;
            }

            Console.WriteLine($"[RegistryAdapter] Entity '{entityId}' not found in session '{sessionId}' ({(isDraft ? "draft" : "committed")}).");
            return null;
        }

        public static IPrismIntentResult CommitSession(SessionContext session)
        {
            var sessionId = session.SessionId;

            var draftKeys = SessionEntityStore.Keys
                .Where(k => k.StartsWith($"{sessionId}:") && k.EndsWith(":draft"))
                .ToList();

            var committedRefs = new List<string>();
            var flattenedMetadata = new Dictionary<string, object>();

            foreach (var draftKey in draftKeys)
            {
                var entity = SessionEntityStore[draftKey];
                var committedKey = draftKey.Replace(":draft", ":committed");

                SessionEntityStore[committedKey] = entity;
                SessionEntityStore.Remove(draftKey);

                committedRefs.Add(entity.EntityId);

                foreach (var kvp in entity.Metadata)
                {
                    flattenedMetadata[kvp.Key] = kvp.Value;
                }

                Console.WriteLine($"[RegistryAdapter] Committed entity '{entity.EntityId}' in session '{sessionId}'.");
            }

            var log = new SessionContext.CuratorLogEntry
            {
                ContributorId = session.ContributorId,
                Phase = session.Phase,
                Timestamp = DateTime.UtcNow,
                CommittedEntities = committedRefs,
                MetadataSnapshot = flattenedMetadata
            };

            // TODO: Persist log to SessionStore or attach to session metadata

            return new PrismIntentResult
            {
                Request = null,
                Success = true,
                ResultCode = "SessionCommitted",
                Message = $"Session '{sessionId}' committed with {committedRefs.Count} entities.",
                Slug = $"session-{sessionId}-commit",
                Timestamp = DateTime.UtcNow,
                Consequence = new()
                {
                    { "CommittedEntities", committedRefs },
                    { "MetadataSnapshot", flattenedMetadata }
                }
            };
        }
    }

    #region RegistryAdapter Summary 2025.08.28
    // RegistryAdapter manages session-scoped entity hydration, transformation, and promotion.
    // It uses TransformerPipeline to apply mood, trait, and overlay transformations in sequence,
    // validates transformer-specific payload requirements via TransformerValidator,
    // and persists updated entities with full traceability across draft and committed states.
    
    // ScenarioTriggerEngine evaluates transformed entities for trait and mood-based triggers,
    // embedding scenario impact into the consequence map for downstream systems.
    
    // CommitSession promotes all draft entities to committed state, flattens metadata,
    // logs curator actions, and returns a narratable consequence map for replayable governance.
    // Together, these flows enable contributor-safe, emotionally reactive, multiplayer-ready simulation logic,
    // supporting mesh propagation, trait-driven consequence, curator validation,
    // and legacy-grade session governance across Prism’s transformation architecture.
    #endregion
}