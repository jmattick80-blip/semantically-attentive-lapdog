using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Envelopes.Validators;

public abstract class EnvelopeValidatorBase : IEnvelopeValidator
{
    protected EnvelopeValidatorDescriptor Descriptor { get; private set; }

    protected readonly List<string> ValidationNotes = new();

    public virtual void InflateFromDescriptor(EnvelopeValidatorDescriptor descriptor)
    {
        Descriptor = descriptor ?? new EnvelopeValidatorDescriptor
        {
            Name = "Unnamed Validator",
            Type = "Generic",
            Tone = "Neutral",
            ContextId = "Unspecified",
            FallbackNotes = new List<string>
            {
                "Validated using default rules.",
                "No context-specific validator was registered.",
                "Consider defining one for richer validation."
            }
        };
    }

    public string Name => Descriptor?.Name ?? "Unnamed";
    public string Type => Descriptor?.Type ?? "Generic";
    public string Tone => Descriptor?.Tone ?? "Neutral";
    public string ContextId => Descriptor?.ContextId ?? "Unspecified";

    public virtual bool Validate(IntentEnvelope envelope)
    {
        throw new NotImplementedException("Validation logic must be implemented by derived classes.");
    }

    public IEnumerable<string> GetValidationNotes()
    {
        if (ValidationNotes.Any())
            return ValidationNotes;

        return Descriptor?.FallbackNotes ?? new List<string>
        {
            $"Validated using default rules.",
            $"Context: {ContextId}",
            $"Validator Name: {Name}",
            $"Tone: {Tone}"
        };
    }
}