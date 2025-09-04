using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Sessions.Session.SessionDependencies;

namespace Prism.Shared.Contracts.Envelopes.Validators;

public class EnvelopeValidatoryRegistry : IEnvelopeValidatorRegistry
{
    private readonly Dictionary<string, EnvelopeValidatorDescriptor> _descriptorMap;
    private readonly DefaultEnvelopeValidator _defaultValidator;

    public EnvelopeValidatoryRegistry()
    {
        _defaultValidator = new DefaultEnvelopeValidator();
        _descriptorMap = new Dictionary<string, EnvelopeValidatorDescriptor>();
    }

    public void RegisterDescriptor(EnvelopeValidatorDescriptor descriptor)
    {
        if (descriptor != null && !string.IsNullOrWhiteSpace(descriptor.ContextId))
        {
            _descriptorMap[descriptor.ContextId] = descriptor;
        }
    }

    public IEnvelopeValidator GetForContext(string contextId)
    {
        if (_descriptorMap.TryGetValue(contextId, out var descriptor))
        {
            return descriptor.Factory();
        }

        _defaultValidator.InflateWithContext(contextId, "Unregistered", "Neutral");
        return _defaultValidator;
    }

    public IEnumerable<EnvelopeValidatorDescriptor> GetAllDescriptors() => _descriptorMap.Values;
    #region EnvelopeValidatoryRegistry – End Summary

// This registry interprets context identifiers and returns narratable envelope validators.
// Contributors can register descriptors that define tone, type, and fallback behavior.
// If no validator is found, a default validator is inflated with context-aware metadata and fallback notes.
// All validation flows are narratable, extensible, and safe for future editors.
// The system ensures that every envelope is validated with clarity, even when context is unknown.

    #endregion
}