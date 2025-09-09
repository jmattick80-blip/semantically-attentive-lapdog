using System.Collections.Generic;
using Prism.Shared.Contracts.Events;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Manifests.Types.Intents;
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
        List<ITrait> Traits { get; }
        Dictionary<string, string> ToneTags { get; }
        Dictionary<string, double> LayerWeights { get; }
        List<RippleEvent> RippleHistory { get; }
        string ToNarration();
        void AddNotes(List<string> routingNotes);
        void AddNote(string note);
        void ClearNotes();
    }
}