namespace GalleryDrivers.Prism.Shared.Interfaces.Manifests
{
    public interface IManifest
    {
        string ManifestId { get; }
        string DisplayName { get; }
        string Description { get; }
        bool IsNarratable { get; }
    }
}