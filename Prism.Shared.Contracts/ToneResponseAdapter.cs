using Prism.Shared.Contracts.Fingerprint;
using Prism.Shared.Contracts.Tone;

namespace Prism.Shared.Contracts
{
    /// <summary>
    /// Modulates PrismResult feedback using designer-authored tone responses.
    /// </summary>
    public class ToneResponseAdapter : IToneModulator
    {
        
        private readonly ToneResponseManifest _toneManifest;

        public ToneResponseAdapter(ToneResponseManifest toneManifest)
        {
            _toneManifest = toneManifest;
        }

        public PrismResult Modulate(PrismResult original, ContributorFingerprint fingerprint)
        {
            var modulated = original.Clone();

            var toneLine = _toneManifest.GetResponse(fingerprint.Role, fingerprint.Tone.Type.ToString());
            modulated.Feedback = $"{toneLine} {original.Feedback}";
            modulated.Tags.Add($"Tone:{fingerprint.Tone.Type}");
            
            return modulated;
        }
    }

    #region ToneResponseAdapter Summary (Sprint 4 – August 31, 2025)
    // ToneResponseAdapter modulates PrismResult feedback using designer-authored tone responses.
    // It supports contributor role and tone, and applies fallback narration when no match is found.
    // Refactor completes Sprint 4’s emotional mesh routing layer and prepares Prism for authored consequences.
    #endregion
}