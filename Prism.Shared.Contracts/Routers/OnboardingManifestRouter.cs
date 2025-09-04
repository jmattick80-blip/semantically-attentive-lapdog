using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Envelopes;
using Prism.Shared.Contracts.Routers.Base;

namespace Prism.Shared.Contracts.Routers
{
    public sealed class OnboardingManifestRouter : ManifestRouterBase
    {
        public OnboardingManifestRouter()
        {
            InflateFromDescriptor(new ManifestRouterDescriptor
            {
                StrategyName = "OnboardingManifestRouter",
                Phase = "onboarding",
                Tone = "gentle",
                FallbackNotes = new List<string>
                {
                    "Routing via onboarding strategy.",
                    "Envelope evaluated for contributor clarity and emotional tone.",
                    "Default tutorial flow applied if no specific onboarding path is defined."
                }
            });
        }

        public override ManifestRoutingResult Route(IIntentEnvelope envelope)
        {
            RoutingNotes.Add($"Evaluating envelope for onboarding clarity.");
            RoutingNotes.Add($"Role context: {envelope.RoleContext}");
            RoutingNotes.Add($"Tags: {string.Join(", ", envelope.Tags)}");

            var result = new ManifestRoutingResult
            {
                Target = "TutorialStage",
                Strategy = Phase,
                Tone = Tone,
                IsFallback = false
            };

            result.AddNotes(RoutingNotes);
            AnnotateEnvelope(envelope);

            return result;
        }
    }
}

#region OnboardingManifestRouter – End Summary (August 31, 2025)

// This sealed resolver interprets envelopes during the onboarding phase.
// It inherits tone, phase, and fallback notes from a descriptor.
// Routing decisions guide flow toward tutorials, tone calibration, or default scaffolding.
// The descriptor ensures narratable fallback behavior even if routing notes are missing.
// All routing logic is narratable, emotionally legible, and safe for future editors.
#endregion