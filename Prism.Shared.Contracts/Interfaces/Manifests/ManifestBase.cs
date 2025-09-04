namespace Prism.Shared.Contracts.Interfaces.Manifests
{
    public abstract class ManifestBase : IManifest
    {
        protected ManifestBase(string manifestId, string displayName, string description)
        {
            ManifestId = manifestId;
            DisplayName = displayName;
            Description = description;
        }

        public string ManifestId { get; set; }
        public string DisplayName { get; }
        public string Description { get; }

        public virtual bool IsNarratable => true;
    }
}