using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Clusters.Base;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;

namespace GalleryDrivers.Prism.Shared.Interfaces.Registries.Activators
{
    /// <summary>
    /// Activates and deactivates bundles of clusters and traits within a manifest registry.
    /// </summary>
    /// <typeparam name="TManifest">The manifest type managed by the registry.</typeparam>
    public class RegistryBundleActivator<TManifest> where TManifest : IManifest
    {
        private readonly IManifestRegistry<TManifest> _manifest;

        public RegistryBundleActivator(IManifestRegistry<TManifest> manifest)
        {
            _manifest = manifest;
        }

        /// <summary>
        /// Registers clusters and propagates traits to the manifest registry.
        /// </summary>
        /// <param name="clusters">The clusters to register.</param>
        /// <param name="traits">The traits to propagate.</param>
        public void ActivateBundle(IEnumerable<Cluster> clusters, IEnumerable<ITrait> traits)
        {
            foreach (var cluster in clusters)
            {
                _manifest.AddSystemCluster(cluster);
            }

            _manifest.PropagateTraitBundle(traits);
        }

        /// <summary>
        /// Clears all registered clusters from the manifest registry.
        /// </summary>
        public void DeactivateAll()
        {
            _manifest.ClearSystemClusters();
        }
    }
}