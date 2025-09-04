using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Interfaces.MeshLogic;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Transformers
{
    public class TransformerPipeline
    {
        private readonly List<IEntityTransformer> _transformers;

        public TransformerPipeline(IEnumerable<IEntityTransformer> transformers)
        {
            _transformers = transformers.ToList();
        }

        public SessionEntity ApplyAll(SessionEntity entity, Dictionary<string, object> payload)
        {
            foreach (var transformer in _transformers)
            {
                var transformed = transformer.Transform(entity, payload) as SessionEntity;
                if (transformed != null)
                {
                    entity = transformed;
                }
            }

            return entity;
        }

        public SessionEntity ModulateFromTriggers(Dictionary<string, List<string>> rawTriggerMap, SessionContext requestSession)
        {
            if (rawTriggerMap.Count == 0)
            {
                Console.WriteLine("❌ Trigger map was empty or null.");
                return null;
            }

            var entity = new SessionEntity
            {
                EntityId = Guid.NewGuid().ToString(),
                SessionId = requestSession.SessionId,
                Timestamp = DateTime.UtcNow,
                EntityType = PrismSelectorTypes.EntityType.Session,
                Traits = new List<PrismTrait>(),
                IsDraft = true
            };

            foreach (var kvp in rawTriggerMap)
            {
                foreach (var trigger in kvp.Value)
                {
                    var trait = new PrismTrait(
                        traitId: Guid.NewGuid().ToString(),
                        traitName: kvp.Key,
                        description: $"Imported from trigger: {trigger}"
                    );

                    trait.Source = "TriggerMap";
                    trait.Tone = "Neutral";


                    trait.Modulate(new TraitModulationContext
                    {
                        ToneHint = "Neutral",
                        Source = "TriggerMap",
                        ScenarioTag = "InitialInjection"
                    });

                    trait.Activate();
                    entity.Traits.Add(trait);
                }
            }

            Console.WriteLine($"📥 Injected {entity.Traits.Count} traits from trigger map.");

            var transformedEntity = ApplyAll(entity, new Dictionary<string, object>
            {
                { "SessionContext", requestSession },
                { "RawTriggers", rawTriggerMap }
            });

            Console.WriteLine($"🧠 Transformed entity contains {transformedEntity.Traits.Count} traits.");

            return transformedEntity;
        }
    }

    #region TransformerPipeline Summary
    /// <summary>
    /// TransformerPipeline applies a sequence of IEntityTransformer instances to a session-scoped entity.
    /// It modulates traits using descriptor-driven context and supports prefab-safe emotional scaffolding.
    /// ModulateFromTriggers accepts raw trigger maps and session context, producing a narratable SessionEntity
    /// enriched with PrismTraits. This pipeline supports mood deltas, overlay injection, and future consequence routing.
    /// </summary>
    /// LastModified: 2025-09-03
    /// JM ✦ Prism Architect ✦ 2025-09-03
    #endregion
}