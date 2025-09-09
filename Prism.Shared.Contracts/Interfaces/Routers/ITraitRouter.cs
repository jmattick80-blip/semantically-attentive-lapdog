using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Interfaces.Routers;

public interface ITraitRouter
{
    void Route(IEnumerable<ITrait> traits, IIntentManifest manifest, MeshProfile mesh);
}