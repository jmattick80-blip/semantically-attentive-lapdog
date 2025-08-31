using GalleryDrivers.Prism.Shared.Interfaces.Traits;

namespace GalleryDrivers.Prism.Shared.Interfaces.Manifests
{
    public interface IIntentManifest : IManifest, ITraitBindable
    {
        string GetNarrationHint(string signalId); // might have to evolve to take context into account
    }
}