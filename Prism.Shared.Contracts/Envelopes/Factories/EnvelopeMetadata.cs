using System;
using Prism.Shared.Contracts.Enums;

namespace Prism.Shared.Contracts.Envelopes.Factories;

public class EnvelopeMetadata
{
    public string EnvelopeId { get; }
    public string SystemHash { get; }
    public DateTime Timestamp { get; }
    public SystemType Type { get; }
    public SystemIntent Intent { get; }
    public SystemPhase Phase { get; }
    public SystemState State { get; }
    public string UnityId { get; }

    public EnvelopeMetadata(
        string envelopeId,
        string systemHash,
        DateTime timestamp,
        SystemType type,
        SystemIntent intent,
        SystemPhase phase,
        SystemState state,
        string unityId)
    {
        EnvelopeId = envelopeId;
        SystemHash = systemHash;
        Timestamp = timestamp;
        Type = type;
        Intent = intent;
        Phase = phase;
        State = state;
        UnityId = unityId;
    }
}