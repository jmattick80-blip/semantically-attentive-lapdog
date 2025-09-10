using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Clusters.Base;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Registries.Base
{
    /// <summary>
    /// Base class for envelope-aware manifest registries.
    /// Supports prefab-safe hydration, emotional scaffolding, and contributor-safe orchestration.
    /// </summary>
    public abstract class BaseManifestRegistry<TManifest> : IManifestRegistry<TManifest> where TManifest : IManifest
    {
        protected readonly Dictionary<string, TManifest> _manifests = new();
        protected readonly List<Cluster> SystemClusters = new();
        protected IEnumerable<ITrait> Traits = Enumerable.Empty<ITrait>();

        protected SemanticIntentEnvelope Envelope { get; }
        protected IManifestHydrator<TManifest> Hydrator { get; }

        protected BaseManifestRegistry(SemanticIntentEnvelope envelope, IManifestHydrator<TManifest> hydrator)
        {
            Envelope = envelope ?? throw new ArgumentNullException(nameof(envelope));
            Hydrator = hydrator ?? throw new ArgumentNullException(nameof(hydrator));
        }

        /// <summary>
        /// Safely hydrates and registers the manifest after construction.
        /// Validates emotional context before hydration.
        /// </summary>
        public void InitializeFromEnvelope()
        {
            Console.WriteLine($"🧠 Envelope type: {Envelope.GetType().Name}");
            Console.WriteLine($"📦 Payload traits: {string.Join(", ", Envelope.PayloadPackage?.Traits ?? new List<string>())}");

            if (Envelope.PayloadPackage?.Traits == null || !Envelope.PayloadPackage.Traits.Any())
            {
                Console.WriteLine("⚠️ Envelope missing traits—hydration aborted.");
                return;
            }

            var hydrated = HydrateFromEnvelope(Envelope, Hydrator);
            if (hydrated != null && !string.IsNullOrWhiteSpace(hydrated.ManifestId))
            {
                _manifests[hydrated.ManifestId] = hydrated;
                Console.WriteLine($"🧬 Hydrated and registered manifest: {hydrated.ManifestId}");
            }
            else
            {
                Console.WriteLine("⚠️ No valid manifest hydrated from envelope.");
            }
        }

        public virtual TManifest Resolve() => _manifests.Values.FirstOrDefault();

        public virtual void RegisterManifest(TManifest manifest)
        {
            if (manifest != null && !string.IsNullOrWhiteSpace(manifest.ManifestId))
            {
                _manifests[manifest.ManifestId] = manifest;
                Console.WriteLine($"📦 Manifest registered: {manifest.ManifestId}");
            }
        }

        public virtual void RemoveManifest(string manifestId)
        {
            if (_manifests.Remove(manifestId))
                Console.WriteLine($"🧹 Manifest removed: {manifestId}");
        }

        public virtual TManifest GetManifestById(string manifestId) =>
            _manifests.TryGetValue(manifestId, out var manifest) ? manifest : default;

        public virtual IEnumerable<TManifest> GetNarratableManifests() => _manifests.Values;

        public virtual IEnumerable<string> GetManifestIds() => _manifests.Keys;

        public virtual bool HasManifest(string manifestId) => _manifests.ContainsKey(manifestId);

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

        public IEnumerable<TManifest> GetAllManifests() => _manifests.Values;

        protected virtual TManifest HydrateFromEnvelope(SemanticIntentEnvelope envelope, IManifestHydrator<TManifest> hydrator)
        {
            if (envelope == null || hydrator == null)
                return default;

            return hydrator.HydrateFromEnvelope(envelope);
        }
    }

    #region BaseManifestRegistry – Refactored September 10, 2025
    /// <summary>
    /// BaseManifestRegistry provides envelope-aware hydration, emotional scaffolding,
    /// and contributor-safe orchestration for Prism OS manifests.
    ///
    /// Refactor Notes:
    /// • Accepts SemanticIntentEnvelope explicitly to preserve emotional context
    /// • Validates traits before hydration to prevent silent failure
    /// • Ensures prefab-safe registry behavior and ripple traceability
    ///
    /// Emotional Consequence:
    /// • Prevents null hydration and registry drift
    /// • Enables ripple lineage and narratable manifest registration
    /// • Restores contributor-safe orchestration across runtime flows
    ///
    /// ✦ Maintainer: Jeremy M.
    /// ✦ Last Audited: Sprint 5 – 2025-09-10
    /// </summary>
    #endregion
}