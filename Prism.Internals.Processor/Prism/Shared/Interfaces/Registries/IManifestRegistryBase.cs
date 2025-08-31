using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;

namespace GalleryDrivers.Prism.Shared.Interfaces.Registries
{
    public interface IManifestRegistryBase
    {
        IEnumerable<IManifest> GetNarratableManifests();
        string GetNarrationHint(string manifestId);
        IEnumerable<string> GetManifestIds();
        bool HasManifest(string manifestId);
    }

}