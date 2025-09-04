using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Registries.Base;

namespace GalleryDrivers.Prism.Shared.Registries
{
    /// <summary>
    /// Registry for managing manifests during the assembly phase.
    /// Hydrates from envelope and supports orchestration readiness.
    /// </summary>
    public class AssemblyManifestRegistry<TManifest> : BaseManifestRegistry<TManifest> where TManifest : IManifest
    {
        public AssemblyManifestRegistry(IntentEnvelope envelope, IManifestHydrator<TManifest> hydrator)
            : base(envelope, hydrator) { }

        public override string GetNarrationHint(string manifestId) =>
            HasManifest(manifestId)
                ? $"Manifest '{manifestId}' is assembled and ready for orchestration."
                : $"No assembly manifest found for ID '{manifestId}'.";
    }
}