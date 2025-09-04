using System;
using Prism.Shared.Contracts.Interfaces.Envelopes;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Sessions.Session.CallbackResolvers
{
    /// <summary>
    /// Dispatches envelope results to session handlers, contributor overlays, or feedback systems.
    /// Currently stubbed for traceability and fallback safety.
    /// </summary>
    public class CallbackDispatcher : ICallbackDispatcher
    {
        public void Dispatch(IEnvelopeResults result)
        {
            if (result == null)
            {
                Console.WriteLine("⚠️ Envelope result is null—dispatch aborted.");
                return;
            }

            var manifestId = result.Manifest?.ManifestId ?? "unknown";
            var sessionId = result.Session?.SessionId ?? "no-session";

            Console.WriteLine($"📤 Dispatching manifest '{manifestId}' for session '{sessionId}'");

            // TODO: Route to session feedback, contributor overlay, or tone-reactive handler
        }
    }
}