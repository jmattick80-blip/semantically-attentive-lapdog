namespace Prism.Shared.Contracts.Interfaces.Manifests
{
    public interface IManifest
    {
        string ManifestId { get; set; }
        string DisplayName { get; }
        string Description { get; }
        bool IsNarratable { get; }
    }
}