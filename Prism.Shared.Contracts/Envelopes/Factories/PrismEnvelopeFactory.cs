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
        public SemanticIntentEnvelope Create<T>(
            Action<SemanticIntentEnvelope> initializer,
            EnvelopeMetadata metadata,
            PrismSession session = null) where T : IntentEnvelope, new()
        {
            var envelope = new SemanticIntentEnvelope();
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
            PrismSession session,
            Dictionary<string, object> payload) // Add this parameter
                                               // )
        {
            return Create<SemanticIntentEnvelope>(
                envelope =>
                {
                    envelope.IntentId = intentId; // Default for bootstrapping

                    Console.WriteLine($"🧾 Set IntentId directly: {intentId}");

                    // Extract traits from payload
                    if (payload.TryGetValue("Traits", out var traitsObj) && traitsObj is IEnumerable<object> traitList)
                    {
                        envelope.Traits = traitList
                            .Select(t => new PrismTrait(t.ToString()))
                            .Cast<ITrait>()
                            .ToList();
                        Console.WriteLine($"🧬 Bound traits: {string.Join(", ", envelope.Traits.Select(t => t.TraitName))}");
                    }

                    // Build PayloadPackage from full payload
                    envelope.PayloadPackage = new PayloadPackage
                    {
                        Traits = envelope.Traits.Select(t => t.TraitName).ToList(),
                        Overlays = payload.TryGetValue("Overlays", out var overlaysObj) && overlaysObj is IEnumerable<object> overlays
                            ? overlays.Select(o => o.ToString()).ToList()
                            : new List<string>(),
                        MoodVector = payload.TryGetValue("MoodVector", out var moodObj) && moodObj is Dictionary<string, object> moodDict
                            ? moodDict.ToDictionary(kvp => kvp.Key, kvp => Convert.ToSingle(kvp.Value))
                            : new Dictionary<string, float>()
                    };

                },
                metadata,
                session
            );
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

