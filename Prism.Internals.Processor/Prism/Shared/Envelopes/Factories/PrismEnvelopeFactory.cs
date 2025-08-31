using System;
using System.Reflection;
using GalleryDrivers.Prism.Shared.Enums;
using GalleryDrivers.Prism.Shared.Envelopes.Base;
using GalleryDrivers.Prism.Shared.Envelopes.Types;
using GalleryDrivers.Prism.Shared.Sessions.Types;

namespace GalleryDrivers.Prism.Shared.Envelopes.Factories
{
    public class PrismEnvelopeFactory
    {
        private readonly PrismSession _session;

        public PrismEnvelopeFactory(PrismSession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public T Create<T>(
            Action<T> initializer,
            string envelopeId = null,
            string systemHash = null,
            DateTime? timestamp = null,
            SystemType type = SystemType.Generic,
            SystemIntent intent = SystemIntent.Resolve,
            SystemPhase phase = SystemPhase.Active,
            SystemState state = SystemState.Triggered,
            string unityId = "") where T : IntentEnvelope, new()
        {
            var envelope = new T();
            initializer?.Invoke(envelope);

            InvokeEnvelopeInitializer(
                envelope,
                envelopeId,
                systemHash,
                timestamp ?? DateTime.UtcNow,
                type,
                intent,
                phase,
                state,
                unityId
            );

            _session.OnIntentEnvelopeCreated(envelope); // 🔥 Session routing

            return envelope;
        }

        public InputIntentEnvelope CreateInputIntentEnvelope(
            string displayName,
            string roleContext,
            string[] tags,
            string unityId,
            string envelopeId = null,
            string systemHash = null,
            DateTime? timestamp = null,
            SystemType type = SystemType.Input,
            SystemIntent intent = SystemIntent.Resolve,
            SystemPhase phase = SystemPhase.Active,
            SystemState state = SystemState.Triggered)
        {
            return Create<InputIntentEnvelope>(
                envelope =>
                {
                    SetPrivateProperty(envelope, "DisplayName", displayName);
                    SetPrivateProperty(envelope, "RoleContext", roleContext);
                    SetPrivateProperty(envelope, "Tags", tags);
                },
                envelopeId,
                systemHash,
                timestamp,
                type,
                intent,
                phase,
                state,
                unityId
            );
        }
        
        public EmotionalIntentEnvelope CreateEmotionalIntentEnvelope(
            string emotionalTag,
            int strength,
            float range,
            float decayRate,
            string traitAffected,
            string emitterId,
            string displayName,
            string roleContext,
            string[] tags,
            string unityId,
            string envelopeId = null,
            string systemHash = null,
            DateTime? timestamp = null,
            SystemType type = SystemType.Emotion,
            SystemIntent intent = SystemIntent.Trigger,
            SystemPhase phase = SystemPhase.Active,
            SystemState state = SystemState.Engaged)
        {
            return Create<EmotionalIntentEnvelope>(
                envelope =>
                {
                    envelope.EmotionalTag = emotionalTag;
                    envelope.Strength = strength;
                    envelope.Range = range;
                    envelope.DecayRate = decayRate;
                    envelope.TraitAffected = traitAffected;
                    envelope.EmitterId = emitterId;
                    envelope.DisplayName = displayName;
                    envelope.RoleContext = roleContext;
                    envelope.Tags = tags;
                },
                envelopeId,
                systemHash,
                timestamp,
                type,
                intent,
                phase,
                state,
                unityId
            );
        }

        private void InvokeEnvelopeInitializer(
            PrismSystemEnvelopeBase envelope,
            string envelopeId,
            string systemHash,
            DateTime timestamp,
            SystemType type,
            SystemIntent intent,
            SystemPhase phase,
            SystemState state,
            string unityId)
        {
            var method = envelope.GetType().GetMethod(
                "InitializeEnvelope",
                BindingFlags.Instance | BindingFlags.NonPublic);

            if (method == null)
            {
                throw new InvalidOperationException(
                    $"Envelope of type {envelope.GetType().Name} does not implement a protected InitializeEnvelope method.");
            }

            if (envelopeId == null) return;
            if (systemHash != null)
                method.Invoke(envelope, new object[]
                {
                    envelopeId,
                    type,
                    intent,
                    phase,
                    state,
                    unityId,
                    timestamp,
                    systemHash
                });
        }
        private void SetPrivateProperty<T>(T target, string propertyName, object value)
        {
            var prop = typeof(T).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(target, value);
            }
        }

    }
}