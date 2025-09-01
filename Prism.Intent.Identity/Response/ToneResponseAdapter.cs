using Prism.Intent.Identity.Fingerprint;
using Prism.Intent.Identity.Phase;
using Prism.Shared.Contracts;

namespace Prism.Intent.Identity.Response
{
    public class ToneResponseAdapter : IToneModulator
    {
        private readonly IPhaseContext _phaseContext;

        public ToneResponseAdapter(IPhaseContext phaseContext)
        {
            _phaseContext = phaseContext;
        }

        public PrismResult Modulate(PrismResult original, ContributorFingerprint fingerprint)
        {
            var modulated = original.Clone();

            switch (fingerprint.Tone.Type)
            {
                case ToneType.Frustrated:
                    modulated.Feedback = $"We hear your frustration. {original.Feedback}";
                    modulated.Tags.Add("Tone:Frustrated");
                    break;

                case ToneType.Reflective:
                    modulated.Feedback = $"Let’s reflect together. {original.Feedback}";
                    modulated.Tags.Add("Tone:Reflective");
                    break;

                case ToneType.Playful:
                    modulated.Feedback = $"Here’s a playful nudge: {original.Feedback}";
                    modulated.Tags.Add("Tone:Playful");
                    break;

                case ToneType.Directive:
                    modulated.Feedback = $"Action acknowledged. {original.Feedback}";
                    modulated.Tags.Add("Tone:Directive");
                    break;

                case ToneType.Curious:
                    modulated.Feedback = $"Great question. Let’s explore: {original.Feedback}";
                    modulated.Tags.Add("Tone:Curious");
                    break;

                case ToneType.Neutral:
                    modulated.Feedback = original.Feedback;
                    modulated.Tags.Add("Tone:Neutral");
                    break;
            }

            if (_phaseContext.RequiresFallback())
            {
                modulated.Feedback += $" (Phase: {_phaseContext.GetPhase()} fallback applied)";
                modulated.Tags.Add("PhaseFallback");
            }

            return modulated;
        }
    }

    #region ToneResponseAdapter Summary (August 31, 2025)
    // ToneResponseAdapter modulates PrismResult feedback based on contributor tone and lifecycle phase.
    // It uses IPhaseContext to determine whether fallback narration should be applied.
    // This stub supports Sprint 2’s empathy layer and prepares Prism for adaptive, phase-aware consequence.
    #endregion
}