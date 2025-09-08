using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Envelopes.Types;

namespace Prism.Shared.Contracts.Envelopes.Validators
{
    public class DefaultEnvelopeValidator : EnvelopeValidatorBase
    {
        public override bool Validate(IntentEnvelope envelope)
        {
            // If no notes were added during validation, use fallback descriptor notes
            var notes = ValidationNotes.Any()
                ? ValidationNotes
                : Descriptor?.FallbackNotes ?? new List<string>
                {
                    $"Validated using default rules.",
                    $"Context: {ContextId}",
                    $"Validator Name: {Name}",
                    $"Type: {Type}",
                    $"Tone: {Tone}",
                    $"Note: No context-specific validator was registered. Consider defining one for richer validation."
                };

            envelope.AddNotes(notes);
            return true;
        }

        public void InflateWithContext(string contextId, string name, string tone)
        {
            InflateFromDescriptor(new EnvelopeValidatorDescriptor
            {
                ContextId = contextId,
                Name = name ?? "Default Validator",
                Type = "Fallback",
                Tone = tone ?? "Neutral",
                FallbackNotes = new List<string>
                {
                    $"Validated using default rules.",
                    $"Context: {contextId}",
                    $"Validator Name: {name ?? "Default Validator"}",
                    $"Tone: {tone ?? "Neutral"}",
                    $"Note: No context-specific validator was registered. Consider defining one for richer validation."
                }
            });
        }

        #region DefaultEnvelopeValidator – End Summary (August 31, 2025)

        // This validator provides a narratable fallback when no context-specific validator is registered.
        // It inherits descriptor-driven identity and returns emotionally legible notes for contributors.
        // The InflateWithContext method allows safe, metadata-rich initialization without requiring a full descriptor.
        // All validation flows are contributor-safe, narratable, and extensible for future editors.

        #endregion
    }
}