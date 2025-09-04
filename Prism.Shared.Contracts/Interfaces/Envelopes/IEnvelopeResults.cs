using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Interfaces.Envelopes
{
    public interface IEnvelopeResults
    {
        IManifest Manifest { get; }
        ISessionContext Session { get; }
        object Payload { get; } // Optional: could be typed later
    }
}