using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Envelopes.Validators;

public class EnvelopeValidatorDescriptor
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string ContextId { get; set; }
    public string Tone { get; set; }
    public Func<IEnvelopeValidator> Factory { get; set; }

    public List<string> FallbackNotes { get; set; } = new();
}