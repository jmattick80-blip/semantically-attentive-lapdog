using Prism.Intent.Identity.Fingerprint;
using Prism.Intent.Identity.Phase;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Tone;

namespace Prism.Intent.Identity.Response
{
    /// <summary>
    /// Modulates PrismResult feedback using designer-authored tone responses and phase-aware fallback narration.
    /// </summary>
    public class ToneResponseAdapter : IToneModulator
    {
        private readonly IPhaseContext _phaseContext;
        private readonly ToneResponseManifest _toneManifest;

        public ToneResponseAdapter(IPhaseContext phaseContext, ToneResponseManifest toneManifest)
        {
            _phaseContext = phaseContext;
            _toneManifest = toneManifest;
        }

        public PrismResult Modulate(PrismResult original, ContributorFingerprint fingerprint)
        {
            var modulated = original.Clone();

            var toneLine = _toneManifest.GetResponse(fingerprint.Role, fingerprint.Tone.Type.ToString());
            modulated.Feedback = $"{toneLine} {original.Feedback}";
            modulated.Tags.Add($"Tone:{fingerprint.Tone.Type}");

            if (_phaseContext.RequiresFallback())
            {
                var fallbackLine = $"(Phase: {_phaseContext.GetPhase()} fallback applied)";
                modulated.Feedback += $" {fallbackLine}";
                modulated.Tags.Add("PhaseFallback");
            }

            return modulated;
        }
    }

    #region ToneResponseAdapter Summary (Sprint 4 – August 31, 2025)
    // ToneResponseAdapter modulates PrismResult feedback using designer-authored tone responses.
    // It supports contributor role and tone, and applies fallback narration based on phase context.
    // Refactor completes Sprint 4’s emotional mesh routing layer and prepares Prism for authored consequence.
    #endregion
}