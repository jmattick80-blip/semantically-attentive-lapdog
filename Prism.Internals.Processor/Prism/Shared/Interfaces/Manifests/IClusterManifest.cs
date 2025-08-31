using GalleryDrivers.Prism.Shared.Interfaces.Traits;

namespace GalleryDrivers.Prism.Shared.Interfaces.Manifests
{
    public interface IClusterManifest : IManifest, ITraitBindable
    {
        /// <summary>
        /// Provides a narration hint for this cluster, optionally based on signal context.
        /// </summary>
        /// <param name="signalId">The signal triggering the narration.</param>
        /// <returns>A contributor-safe narration string.</returns>
        string GetNarrationHint(string signalId);
    }
}