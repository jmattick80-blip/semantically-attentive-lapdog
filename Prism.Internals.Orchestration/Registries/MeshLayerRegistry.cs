using Prism.Shared.Contracts.Config;
using Prism.Shared.Contracts.Interfaces.Orchestration;

namespace Prism.Internals.Orchestration.Registries
{
    public class MeshLayerRegistry : IPrismRegistry
    {
        private readonly Dictionary<string, MeshLayerState> _layers = new();

        public MeshLayerRegistry(List<MeshLayerConfig> configMeshLayers)
        {
            if (configMeshLayers.Count == 0)
            {
                Console.WriteLine("⚠️ MeshLayerRegistry: No layers to hydrate.");
                return;
            }

            foreach (var layer in configMeshLayers)
            {
                var name = layer.EffectiveName;

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("⚠️ MeshLayerRegistry: Skipping layer with missing LayerId and Name.");
                    continue;
                }

                RegisterLayer(name, layer.IsActive, layer.Weight, layer.Threshold);
            }

            Console.WriteLine($"✅ MeshLayerRegistry: Hydrated {_layers.Count} layers.");
        }

        public void RegisterLayer(string name, bool active, float weight = 1.0f, float threshold = 0.0f)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("⚠️ MeshLayerRegistry: Attempted to register layer with empty name.");
                return;
            }

            _layers[name.ToLower()] = new MeshLayerState
            {
                Name = name,
                IsActive = active,
                Weight = weight,
                Threshold = threshold
            };

            Console.WriteLine(
                $"🔗 Layer registered: {name} | Active: {active} | Weight: {weight} | Threshold: {threshold}");
        }

        public bool IsActive(string name) =>
            _layers.TryGetValue(name.ToLower(), out var layer) && layer.IsActive;

        public float GetWeight(string name) =>
            _layers.TryGetValue(name.ToLower(), out var layer) ? layer.Weight : 0f;

        public float GetThreshold(string name) =>
            _layers.TryGetValue(name.ToLower(), out var layer) ? layer.Threshold : 0f;

        public IEnumerable<MeshLayerState> GetAllLayers() => _layers.Values;

        public static MeshLayerRegistry CreateFromConfig(List<MeshLayerConfig> configMeshLayers)
        {
            return new MeshLayerRegistry(configMeshLayers);
        }
    }
}

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    // 🧠 Summary Region: MeshLayerRegistry (Refactored – September 10, 2025)
    //
    // Registers and manages mesh layers for emotional consequence routing.
    // Hydrates layer states from config using fallback logic for missing names.
    // Applies activation flags, weights, and thresholds for ripple scoring.
    //
    // ┌─────────────────────────────────────────────────────────────────────────┐
    // │ Responsibilities                                                       │
    // ├─────────────────────────────────────────────────────────────────────────┤
    // │ • Hydrate mesh layers from config using CreateFromConfig()             │
    // │ • Fallback to LayerId if Name is missing during hydration              │
    // │ • Register layers with activation state, weight, and threshold         │
    // │ • Query layer state for consequence routing and audit tooling          │
    // └─────────────────────────────────────────────────────────────────────────┘
    //
    // 🔗 Dependencies:
    // - Prism.Shared.Contracts.Config (MeshLayerConfig)
    // - Prism.Shared.Contracts.Orchestration (I