using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Agents;

namespace Prism.Shared.Contracts.Runtime.Imports
{
    public static class TraitTriggerImporter
    {
        /// <summary>
        /// Builds a trait-trigger map from a list of NPC definitions.
        /// Each NPC contributes emotional tags or scenario hints grouped by trait name.
        /// </summary>
        public static Dictionary<string, List<string>> BuildFromNpcDefinitions(List<NpcDefinition> npcDefinitions)
        {
            var triggerMap = new Dictionary<string, List<string>>();

            foreach (var npc in npcDefinitions)
            {
                foreach (var trigger in npc.TraitTriggerMap.Triggers)
                {
                    var traitName = trigger.TraitName;
                    var annotatedTrigger = $"npc:{npc.NpcId}:{trigger.TriggerKey}:{trigger.TriggerValue}";

                    if (!triggerMap.ContainsKey(traitName))
                        triggerMap[traitName] = new List<string>();

                    triggerMap[traitName].Add(annotatedTrigger);
                }
            }

            Console.WriteLine($"🧬 Built trigger map from {npcDefinitions.Count} NPCs.");
            return triggerMap;
        }

        private static string ExtractTraitName(string tag)
        {
            // Example: "curiosity.overlay.startup" → "curiosity"
            var parts = tag.Split('.');
            return parts.Length > 0 ? parts[0] : "unknown";
        }

        /// <summary>
        /// Imports raw trait triggers from a PrismIntentRequest.
        /// Expects a payload entry under "Triggers" containing a List of trigger strings.
        /// Groups triggers by trait name for modulation.
        /// </summary>
        public static Dictionary<string, List<string>> Import(PrismIntentRequest request)
        {
            var triggerMap = new Dictionary<string, List<string>>();

            if (request.Payload.TryGetValue("Triggers", out var raw) && raw is List<string> rawTriggers)
            {
                foreach (var trigger in rawTriggers)
                {
                    var traitName = ExtractTraitName(trigger);
                    var annotatedTrigger = $"payload:{trigger}";

                    if (!triggerMap.ContainsKey(traitName))
                        triggerMap[traitName] = new List<string>();

                    triggerMap[traitName].Add(annotatedTrigger);
                }
            }

            Console.WriteLine($"📦 Imported {triggerMap.Count} trait groups from intent payload.");
            return triggerMap;
        }

    }

    #region TraitTriggerImporter Summary
    /// <summary>
    /// TraitTriggerImporter organizes raw triggers into a narratable map of trait names and emotional origins.
    /// This overload builds from NPC definitions, supporting prefab-safe modulation and session scaffolding.
    /// </summary>
    /// LastModified: 2025-09-03
    /// JM ✦ Prism Architect ✦ 2025-09-03
    #endregion
}