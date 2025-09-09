using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Interfaces.MeshLogic;

namespace Prism.Shared.Contracts.Interfaces.Transformers
{
    public class PrismTransformerResolver : ITransformerResolver
    {
        public List<IEntityTransformer> Resolve(PrismSelectorTypes.EntityType entityType, MeshProfile mesh)
        {
            var transformers = new List<IEntityTransformer>();

            // 🎛️ Extract emotional fingerprint
            var tone = mesh.ToneTags != null && mesh.ToneTags.TryGetValue("entry", out var entryTone)
                ? entryTone
                : "neutral";

            var mood = mesh.MoodVector?.ToLowerInvariant() ?? "neutral";
            var intent = mesh.IntentType?.ToLowerInvariant() ?? "default";

            // 🧬 Build resolution keys
            var baseKey = $"{entityType}:{intent}:{tone}:{mood}";
            var fallbackKey = $"{entityType}:{intent}:{tone}:fallback";

            // 🔍 Attempt resolution from registry
            var primary = TransformerRegistry.Resolve(baseKey);
            if (primary != null)
                transformers.Add(primary);

            var fallback = TransformerRegistry.Resolve(fallbackKey);
            if (fallback != null)
                transformers.Add(fallback);

            // 🧩 Tag-based overlays
            foreach (var tag in mesh.Tags ?? Enumerable.Empty<string>())
            {
                var tagKey = $"{entityType}:tag:{tag}";
                var tagTransformer = TransformerRegistry.Resolve(tagKey);
                if (tagTransformer != null)
                    transformers.Add(tagTransformer);
            }

            // 🧼 Deduplicate by TransformerType
            return transformers
                .GroupBy(t => t.TransformerType)
                .Select(g => g.First())
                .ToList();
        }
    }
}