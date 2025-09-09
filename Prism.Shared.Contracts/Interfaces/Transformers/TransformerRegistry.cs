using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Interfaces.MeshLogic;

namespace Prism.Shared.Contracts.Interfaces.Transformers
{
    public static class TransformerRegistry
    {
        // Internal registry: key → transformer factory
        private static readonly ConcurrentDictionary<string, Func<IEntityTransformer>> _registry = new();

        /// <summary>
        /// Registers a transformer factory with a resolution key.
        /// </summary>
        public static void Register(string key, Func<IEntityTransformer> factory)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Transformer key cannot be null or empty.");

            _registry[key] = factory;
            Console.WriteLine($"🔗 Transformer registered → {key}");
        }

        /// <summary>
        /// Resolves a transformer by key. Returns null if not found.
        /// </summary>
        public static IEntityTransformer? Resolve(string key)
        {
            if (_registry.TryGetValue(key, out var factory))
                return factory();

            Console.WriteLine($"⚠️ Transformer not found for key: {key}");
            return null;
        }

        /// <summary>
        /// Returns all registered transformer keys.
        /// </summary>
        public static IReadOnlyList<string> Keys => _registry.Keys.ToList();

        /// <summary>
        /// Clears all transformer mappings. Use with caution.
        /// </summary>
        public static void Reset()
        {
            _registry.Clear();
            Console.WriteLine("⚠️ TransformerRegistry reset. All mappings cleared.");
        }
    }
}