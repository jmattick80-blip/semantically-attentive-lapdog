using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Manifests;

namespace Prism.Shared.Contracts.Interfaces.Registries
{
    public interface IManifestRegistryBase
    {
        IEnumerable<IManifest> GetNarratableManifests();
        string GetNarrationHint(string manifestId);
        IEnumerable<string> GetManifestIds();
        bool HasManifest(string manifestId);
    }

}