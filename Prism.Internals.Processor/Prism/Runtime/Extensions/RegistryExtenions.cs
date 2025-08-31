using System.Collections.Generic;
using System.Linq;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Interfaces.Registries;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;

namespace GalleryDrivers.Prism.Runtime.Extensions
{
    public static class RegistryExtensions
    {
        /// <summary>
        /// Filters registries whose narratable manifests contain all specified traits.
        /// </summary>
        public static IEnumerable<IManifestRegistry<TManifest>> WithTraits<TManifest>(
            this IEnumerable<IManifestRegistry<TManifest>> registries,
            IEnumerable<ITrait> requiredTraits)
            where TManifest : IManifest, ITraitBindable
        {
            var enumerable = requiredTraits.ToList();
            if (!enumerable.Any())
                return registries;

            return registries.Where(registry =>
                registry.GetNarratableManifests().Any(manifest =>
                    enumerable.All(trait =>
                        manifest.DefaultTraits.Any(t => t.TraitId == trait.TraitId))));
        }
    }
}