using Prism.Internal.Shared.MeshLogic.Interfaces;

namespace Prism.Internal.Shared.MeshLogic.Routing
{
    public static class TransformerValidator
    {
        public static bool ValidatePayload(IEntityTransformer transformer, Dictionary<string, object> payload, out string error)
        {
            error = string.Empty;

            if (!transformer.IsRequired)
                return true;

            var requiredKeys = GetRequiredKeys(transformer.TransformerType);

            foreach (var key in requiredKeys)
            {
                if (!payload.ContainsKey(key))
                {
                    error = $"Transformer '{transformer.TransformerType}' requires payload key '{key}' but it was missing.";
                    return false;
                }
            }

            return true;
        }

        private static List<string> GetRequiredKeys(string transformerType)
        {
            return transformerType switch
            {
                "Mood" => new() { "MoodDelta" },
                "Trait" => new() { "Traits" },
                "Overlay" => new() { "Overlay" },
                _ => new()
            };
        }
    }
}