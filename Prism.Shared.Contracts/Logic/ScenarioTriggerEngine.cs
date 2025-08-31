using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Interfaces;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Logic
{
    public static class ScenarioTriggerEngine
    {
        public static Dictionary<string, object> Evaluate(ISessionEntity entity, Dictionary<string, string> traitMap)
        {
            var impact = new Dictionary<string, object>();

            // Trait-based triggers
            if (entity.Metadata.TryGetValue("Traits", out var traitsObj) && traitsObj is List<string> traits)
            {
                foreach (var trait in traits)
                {
                    if (traitMap.TryGetValue(trait, out var trigger))
                    {
                        var parts = trigger.Split(':');
                        if (parts.Length == 2)
                            impact[parts[0]] = parts[1];
                    }
                }
            }

            // Mood-based triggers (generic, not hardcoded)
            var elevatedMoods = entity.MoodVector
                .Where(kvp => kvp.Value > 0.8f)
                .Select(kvp => kvp.Key)
                .ToList();

            if (elevatedMoods.Count > 0)
            {
                impact["NPCShift"] = $"Elevated:{string.Join(",", elevatedMoods)}";
            }

            return impact;
        }
    }
}