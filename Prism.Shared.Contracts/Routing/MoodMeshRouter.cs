using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Requests;

namespace Prism.Shared.Contracts.Routing
{
    public static class MoodMeshRouter
    {
        public static void Emit(
            IPrismIntentResult result,
            string contributorId,
            string phase,
            Dictionary<string, string>? moodMap)
        {
            if (string.IsNullOrWhiteSpace(contributorId))
            {
                Log("⚠️ MoodMeshRouter: Invalid result or contributor ID.");
                return;
            }
            
            if (moodMap == null || moodMap.Count == 0)
            {
                Log($"🧠 MoodMeshRouter: No mood map provided. Defaulting to 'Neutral' for contributor '{contributorId}' in phase '{phase}'.");
                return;
            }

            var moodSignal = InferMood(result.Message, moodMap);
            Log($"🧠 MoodMeshRouter: Contributor '{contributorId}' in phase '{phase}' → Mood: {moodSignal}");
        }

        private static string InferMood(string message, Dictionary<string, string>? moodMap)
        {
            if (string.IsNullOrWhiteSpace(message) || moodMap == null || moodMap.Count == 0)
                return "Neutral";

            foreach (var kvp in moodMap)
            {
                if (message.Contains(kvp.Key))
                    return kvp.Value;
            }

            return "Neutral";
        }

        private static void Log(string line)
        {
            // Replace with actual mesh dispatch or feedback system
            Console.WriteLine(line);
        }
    }
}