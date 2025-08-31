using System;
using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Interfaces.Envelopes;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;
using GalleryDrivers.Prism.Shared.Manifests.Types.Intents;
using GalleryDrivers.Prism.Shared.Sessions.Types;

namespace GalleryDrivers.Prism.Shared.Envelopes.Base
{
    [Serializable]
    public abstract class IntentEnvelope : PrismSystemEnvelopeBase, IIntentEnvelope
    {
        public string IntentId { get; protected set; } = string.Empty;
        public string DisplayName { get; protected internal set; } = string.Empty;
        public string Description { get; protected set; } = string.Empty;
        public string RoleContext { get; protected internal set; } = string.Empty;
        public string[] Tags { get; protected internal set; } = Array.Empty<string>();
        public IntentManifest SourceManifest { get; protected set; }
        public PrismSession Session { get; protected set; }
        public IEnumerable<ITrait> Traits { get; protected set; } = new List<ITrait>();
        
        public override string ToNarration() =>
            $"[{Timestamp:HH:mm:ss}] Intent: {DisplayName} → Role: {RoleContext} → Tags: {string.Join(", ", Tags)}";
    }
}