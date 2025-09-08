using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Data;
using Prism.Shared.Contracts.Envelopes.Base;
using Prism.Shared.Contracts.Interfaces.Envelopes;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Manifests.Types.Intents;
using Prism.Shared.Contracts.Sessions.Session.Types;

namespace Prism.Shared.Contracts.Envelopes.Types
{
    [Serializable]
    public abstract class IntentEnvelope : PrismSystemEnvelopeBase, IIntentEnvelope
    {
        public string IntentId { get; protected internal set; } = string.Empty;
        public string DisplayName { get; protected internal set; } = string.Empty;
        public string Description { get; protected set; } = string.Empty;
        public string RoleContext { get; protected internal set; } = string.Empty;
        public string[] Tags { get; protected internal set; } = Array.Empty<string>();
        public IntentManifest SourceManifest { get; protected set; }
        public PrismSession Session { get; protected set; }
        public List<ITrait> Traits { get; protected internal set; } = new List<ITrait>();

        // Internal note tracking
        private readonly List<string> _validationNotes = new();

        public IReadOnlyList<string> ValidationNotes => _validationNotes.AsReadOnly();
        public PayloadPackage PayloadPackage { get; set; }

        public void AddNotes(List<string> notes)
        {
            if (notes == null || notes.Count == 0)
                return;

            foreach (var note in notes)
            {
                if (!string.IsNullOrWhiteSpace(note))
                {
                    _validationNotes.Add(note.Trim());
                }
            }
        }

        public void AddNote(string note)
        {
            if (!string.IsNullOrWhiteSpace(note))
            {
                _validationNotes.Add(note.Trim());
            }
        }

        public void ClearNotes()
        {
            _validationNotes.Clear();
        }

        public override string ToNarration() =>
            $"[{Timestamp:HH:mm:ss}] Intent: {DisplayName} → Role: {RoleContext} → Tags: {string.Join(", ", Tags)}";
    }
    
}