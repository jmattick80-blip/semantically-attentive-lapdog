using Prism.Intent.Identity.Fingerprint;
using Prism.Intent.Interpretation.Config;
using Prism.Shared.Contracts;

namespace Prism.Intent.Interpretation.Response
{
    public class ResponseNarrator
    {
        private readonly ToneResponseManifest _toneManifest;
        private readonly InterpretationResponseManifest _interpretationManifest;

        public ResponseNarrator(
            ToneResponseManifest toneManifest,
            InterpretationResponseManifest interpretationManifest)
        {
            _toneManifest = toneManifest;
            _interpretationManifest = interpretationManifest;
        }

        /// <summary>
        /// Builds a narratable PrismResult from interpreted meaning and contributor fingerprint.
        /// </summary>
        public PrismResult Narrate(
            string interpretation,
            ContributorFingerprint fingerprint,
            List<string> traceTags = null)
        {
            var toneLine = _toneManifest.GetResponse(fingerprint.Role, fingerprint.Tone.Type.ToString());
            var interpretationLine = _interpretationManifest.GetResponse(
                interpretation,
                fingerprint.Role,
                fingerprint.Phase.ToString());

            var feedback = $"{toneLine} {interpretationLine}";

            var result = new PrismResult(feedback)
            {
                Tags = traceTags ?? new List<string>()
            };

            result.Tags.Add($"Narration:{interpretation}");
            result.Tags.Add($"Tone:{fingerprint.Tone.Type}");
            result.Tags.Add($"Phase:{fingerprint.Phase}");

            return result;
        }
    }

    #region ResponseNarrator Summary (August 31, 2025)
    // ResponseNarrator uses designer-authored tone and interpretation manifests to generate narratable feedback.
    // Supports NPC emitters, role-aware modulation, and phase-sensitive consequence.
    // Refactor completes Sprint 3’s voice layer and prepares Prism for authored mesh activation.
    #endregion
}