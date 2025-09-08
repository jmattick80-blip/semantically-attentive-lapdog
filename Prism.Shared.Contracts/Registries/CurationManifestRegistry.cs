using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Registries.Base;

namespace Prism.Shared.Contracts.Registries
{
    /// <summary>
    /// Registry for managing manifests during the curation phase.
    /// Hydrates from envelope and supports contributor review and emotional traceability.
    /// </summary>
    public class CurationManifestRegistry<TManifest> : BaseManifestRegistry<TManifest> where TManifest : IManifest
    {
        public CurationManifestRegistry(IntentEnvelope envelope, IManifestHydrator<TManifest> hydrator)
            : base(envelope, hydrator) { }

        public override string GetNarrationHint(string manifestId) =>
            HasManifest(manifestId)
                ? $"Manifest '{manifestId}' is curated and ready for review."
                : $"No curated manifest found for ID '{manifestId}'.";
    }

    #region CurationManifestRegistry – End Summary (Sprint 5 – September 1, 2025)
    /// <summary>
    /// CurationManifestRegistry orchestrates emotionally reactive manifests during the review phase.
    /// It hydrates from an IntentEnvelope using a provided IManifestHydrator<TManifest>,
    /// registers the curated manifest, and supports narration hints for contributor feedback.
    ///
    /// This registry is used when contributors inspect, annotate, or validate system behavior.
    /// It ensures emotional traceability, prefab-safe hydration, and narratable fallback logic.
    ///
    /// Related Interfaces:
    /// - IManifest
    /// - IManifestHydrator<TManifest>
    /// - IntentEnvelope
    /// - BaseManifestRegistry<TManifest>
    /// </summary>
    #endregion
}