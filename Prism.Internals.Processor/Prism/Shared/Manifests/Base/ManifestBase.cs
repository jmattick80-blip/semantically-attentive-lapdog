using GalleryDrivers.Prism.Shared.Interfaces.Manifests;

namespace GalleryDrivers.Prism.Shared.Manifests.Base
{
    public abstract class ManifestBase : IManifest
    {
        protected ManifestBase(string manifestId, string displayName, string description)
        {
            ManifestId = manifestId;
            DisplayName = displayName;
            Description = description;
        }

        public string ManifestId { get;}
        public string DisplayName { get; }
        public string Description { get; }

        public virtual bool IsNarratable => true;
    }
}