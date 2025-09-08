using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Registries.Base
{
    /// <summary>
    /// Base class for envelope-aware manifest registries.
    /// Supports prefab-safe hydration, emotional scaffolding, and contributor-safe orchestration.
    /// Designed to be inherited by phase-specific registries (e.g., Onboarding, Runtime, Review).
    /// </summary>
    public abstract class BaseManifestRegistry<TManifest> : IManifestRegistry<TManifest> where TManifest : IManifest
    {
        protected readonly Dictionary<string, TManifest> ManifestMap = new();
        protected readonly List<Cluster> SystemClusters = new();
        protected IEnumerable<ITrait> Traits = Enumerable.Empty<ITrait>();

        protected BaseManifestRegistry(IntentEnvelope envelope, IManifestHydrator<TManifest> hydrator)
        {
            var hydrated = HydrateFromEnvelope(envelope, hydrator);
            if (hydrated != null && !string.IsNullOrWhiteSpace(hydrated.ManifestId))
            {
                ManifestMap[hydrated.ManifestId] = hydrated;
                Console.WriteLine($"🧬 Hydrated and registered manifest: {hydrated.ManifestId}");
            }
            else
            {
                Console.WriteLine("⚠️ No valid manifest hydrated from envelope.");
            }
        }

        public virtual TManifest Resolve() => ManifestMap.Values.FirstOrDefault();

        public virtual void RegisterManifest(TManifest manifest)
        {
            if (manifest != null && !string.IsNullOrWhiteSpace(manifest.ManifestId))
            {
                ManifestMap[manifest.ManifestId] = manifest;
                Console.WriteLine($"📦 Manifest registered: {manifest.ManifestId}");
            }
        }

        public virtual void RemoveManifest(string manifestId)
        {
            if (ManifestMap.Remove(manifestId))
                Console.WriteLine($"🧹 Manifest removed: {manifestId}");
        }

        public virtual TManifest GetManifestById(string manifestId) =>
            ManifestMap.TryGetValue(manifestId, out var manifest) ? manifest : default;

        public virtual IEnumerable<TManifest> GetNarratableManifests() => ManifestMap.Values;

        public virtual IEnumerable<string> GetManifestIds() => ManifestMap.Keys;

        public virtual bool HasManifest(string manifestId) => ManifestMap.ContainsKey(manifestId);

        public abstract string GetNarrationHint(string manifestId);

        public virtual void AddSystemCluster(Cluster cluster)
        {
            if (cluster != null)
            {
                SystemClusters.Add(cluster);
                Console.WriteLine($"🔗 Cluster added: {cluster.ClusterId}");
            }
        }

        public virtual void PropagateTraitBundle(IEnumerable<ITrait> traits)
        {
            Traits = traits ?? Enumerable.Empty<ITrait>();
            Console.WriteLine($"🧬 Traits propagated: {string.Join(", ", Traits.Select(t => t.TraitName))}");
        }

        public virtual void ClearSystemClusters()
        {
            SystemClusters.Clear();
            Console.WriteLine("🧼 System clusters cleared.");
        }

        protected virtual TManifest HydrateFromEnvelope(IntentEnvelope envelope, IManifestHydrator<TManifest> hydrator)
        {
            if (envelope == null || hydrator == null)
                return default;

            var manifest = hydrator.HydrateFromEnvelope(envelope);
            return manifest;
        }
    }

    #region BaseManifestRegistry – End Summary (Sprint 5 – September 1, 2025)
    /// <summary>
    /// BaseManifestRegistry provides envelope-aware hydration, emotional scaffolding,
    /// and contributor-safe orchestration for Prism OS manifests.
    /// It interprets the IntentEnvelope using a provided IManifestHydrator<TManifest>,
    /// registers the hydrated manifest, and supports trait propagation and cluster binding.
    ///
    /// This class is designed to be inherited by phase-specific registries such as:
    /// - OnboardingManifestRegistry
    /// - RuntimeManifestRegistry
    /// - ReviewManifestRegistry
    ///
    /// It ensures fallback behavior is narratable, emotional context is opt-in,
    /// and orchestration is extensible across contributor flows.
    ///
    /// Related Interfaces:
    /// - IManifest
    /// - IEmotionallyReactiveManifest
    /// - IManifestRegistry<TManifest>
    /// - IManifestHydrator<TManifest>
    /// - IntentEnvelope
    /// - Cluster
    /// - ITrait
    /// </summary>
    #endregion
}