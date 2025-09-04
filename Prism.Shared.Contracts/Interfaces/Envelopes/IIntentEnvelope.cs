using System.Collections.Generic;
using Prism.Shared.Contracts.Manifests.Types.Intents;
using Prism.Shared.Contracts.Sessions;
using Prism.Shared.Contracts.Sessions.Session.Types;

namespace Prism.Shared.Contracts.Interfaces.Envelopes
{
    public interface IIntentEnvelope : IEnvelope
    {
        string IntentId { get; }
        string RoleContext { get; }
        string[] Tags { get; }
        IntentManifest SourceManifest { get; }
        PrismSession Session { get; }
        string ToNarration(); // Optional override
        void AddNotes(List<string> routingNotes);
    }
}