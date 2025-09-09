using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Prism.Shared.Contracts.Data;
using Prism.Shared.Contracts.Envelopes.Base;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Sessions.Session.Types;

namespace Prism.Shared.Contracts.Envelopes.Factories
{
    public class PrismEnvelopeFactory
    {
        public T Create<T>(
            Action<T> initializer,
            EnvelopeMetadata metadata,
            PrismSession session = null) where T : IntentEnvelope, new()
        {
            var envelope = new T();
            initializer?.Invoke(envelope);

            InvokeEnvelopeInitializer(envelope, metadata);

            // 🔥 Emotional routing only if session is provided
            session?.OnIntentEnvelopeCreated(envelope);

            return envelope;
        }

        public SemanticIntentEnvelope CreateSemanticIntentEnvelope(
            string intentId,
            string intentHash,
            string rawIntentData,
            EnvelopeMetadata metadata,
            PrismSession session)
        {
            return Create<SemanticIntentEnvelope>(
                envelope =>
                {
                    envelope.IntentId = intentId; // Default for bootstrapping

                    Console.WriteLine($"🧾 Set IntentId directly: {intentId}");

                    if (envelope.Traits == null)
                    {
                        envelope.Traits = new List<ITrait>();
                        Console.WriteLine("🧬 Initialized empty trait bundle on envelope.");
                    }

                    envelope.PayloadPackage = new PayloadPackage
                    {
                        Traits = envelope.Traits.Select(t => t.TraitName).ToList(),
                        Overlays = new List<string> { "startup" },
                        MoodVector = new Dictionary<string, float> { { "curiosity", 0.9f } }
                    };
                },
                metadata,
                session
            );
        }


        public InputIntentEnvelope CreateInputIntentEnvelope(
            string displayName,
            string roleContext,
            string[] tags,
            EnvelopeMetadata metadata,
            PrismSession session = null)
        {
            return Create<InputIntentEnvelope>(
                envelope =>
                {
                    SetPrivateProperty(envelope, "DisplayName", displayName);
                    SetPrivateProperty(envelope, "RoleContext", roleContext);
                    SetPrivateProperty(envelope, "Tags", tags);
                },
                metadata,
                session
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
            EnvelopeMetadata metadata,
            PrismSession session = null)
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
                metadata,
                session
            );
        }

        public ResultsEnvelope CreateSuccess(
            string narration,
            IEnumerable<ITrait> traits,
            IManifest manifest,
            ISessionContext session,
            object payload = null)
        {
            return ResultsEnvelope.Success(narration, traits, manifest, session, payload);
        }

        public ResultsEnvelope CreateFailure(string narration, params string[] errors)
        {
            return ResultsEnvelope.Failure(narration, errors);
        }

        public ResultsEnvelope CreateFailureWithTraits(string narration, IEnumerable<ITrait> traits,
            IEnumerable<string> errors)
        {
            return ResultsEnvelope.FailureWithTraits(narration, traits, errors);
        }

        private void InvokeEnvelopeInitializer(
            PrismSystemEnvelopeBase envelope,
            EnvelopeMetadata metadata)
        {
            var method = envelope.GetType().GetMethod(
                "InitializeEnvelope",
                BindingFlags.Instance | BindingFlags.NonPublic);

            if (method == null)
            {
                throw new InvalidOperationException(
                    $"Envelope of type {envelope.GetType().Name} does not implement a protected InitializeEnvelope method.");
            }

            if (string.IsNullOrWhiteSpace(metadata.EnvelopeId))
            {
                throw new ArgumentException("Envelope ID must be provided for initialization.");
            }

            method.Invoke(envelope, new object[]
            {
                metadata.EnvelopeId,
                metadata.Type,
                metadata.Intent,
                metadata.State,
                metadata.UnityId,
                metadata.Timestamp,
                metadata.SystemHash
            });
        }

        private void SetPrivateProperty<T>(T target, string propertyName, object value)
        {
            var prop = typeof(T).GetProperty(propertyName,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);

            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(target, value);
                Console.WriteLine($"✅ Set property '{propertyName}' to '{value}'");
                return;
            }

            var field = typeof(T).GetField(propertyName,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);

            if (field != null)
            {
                field.SetValue(target, value);
                Console.WriteLine($"✅ Set field '{propertyName}' to '{value}'");
                return;
            }

            Console.WriteLine($"⚠️ Could not set '{propertyName}'—no matching property or field found.");
        }
    }
    #region PrismEnvelopeFactory Summary – Refactored September 1, 2025
    /// <summary>
    /// PrismEnvelopeFactory creates narratable envelopes for semantic, emotional, and input-driven intents.
    /// It no longer requires a PrismSession at construction, allowing envelopes to be created contextually.
    /// Emotional routing via OnIntentEnvelopeCreated is triggered only when a session is provided.
    /// This refactor enables prefab-safe envelope creation, modular testing, and contributor-aware feedback.
    /// Envelope initialization is performed via reflection, ensuring metadata consistency across envelope types.
    /// </summary>
    #endregion
}

