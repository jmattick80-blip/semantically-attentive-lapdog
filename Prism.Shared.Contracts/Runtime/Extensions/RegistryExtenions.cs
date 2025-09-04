using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Registries;
using Prism.Shared.Contracts.Interfaces.Traits;

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