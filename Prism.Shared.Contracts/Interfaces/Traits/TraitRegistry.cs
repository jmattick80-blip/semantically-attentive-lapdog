using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Prism.Shared.Contracts.Interfaces.Traits
{
    public static class TraitRegistry
    {
        private static readonly ConcurrentDictionary<string, PrismTrait> _traits = new();

        /// <summary>
        /// Registers a trait into the global registry. Overwrites if ID already exists.
        /// </summary>
        public static void Register(PrismTrait trait)
        {
            if (string.IsNullOrWhiteSpace(trait.TraitId))
                throw new ArgumentException("Trait must have a valid ID.");

            _traits[trait.TraitId] = trait;
            Console.WriteLine($"🧬 Trait registered: {trait.TraitName} ({trait.TraitId})");
        }

        /// <summary>
        /// Retrieves a trait by ID. Returns null if not found.
        /// </summary>
        public static PrismTrait? Get(string traitId)
        {
            _traits.TryGetValue(traitId, out var trait);
            return trait;
        }

        /// <summary>
        /// Returns all registered traits as a read-only list.
        /// </summary>
        public static IReadOnlyList<PrismTrait> All => _traits.Values.ToList();

        /// <summary>
        /// Clears all traits from the registry. Use with caution.
        /// </summary>
        public static void Reset()
        {
            _traits.Clear();
            Console.WriteLine("⚠️ TraitRegistry reset. All traits cleared.");
        }
    }
}