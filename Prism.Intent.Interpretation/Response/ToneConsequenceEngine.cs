using Prism.Intent.Identity.Fingerprint;
using Prism.Intent.Interpretation.Config;
using Prism.Shared.Contracts;

namespace Prism.Intent.Interpretation.Response
{
    public class ToneConsequenceEngine
    {
        private readonly ToneConsequenceManifest _manifest;

        public ToneConsequenceEngine(ToneConsequenceManifest manifest)
        {
            _manifest = manifest;
        }

        /// <summary>
        /// Applies emotional consequences of a PrismResult based on tone history.
        /// </summary>
        public PrismResult ApplyToneConsequence(
            PrismResult original,
            List<FingerprintTone> toneHistory,
            ContributorFingerprint fingerprint)
        {
            var modulated = original.Clone();

            if (toneHistory.Count == 0)
                return modulated;

            var recentTone = toneHistory[^1];
            var toneTag = $"ToneConsequence:{recentTone.Type}";

            modulated.Tags.Add(toneTag);

            var consequenceLine = _manifest.GetResponse(fingerprint.Role, recentTone.Type.ToString());
            modulated.Feedback += $" {consequenceLine}";

            return modulated;
        }
    }

    #region ToneConsequenceEngine Summary (August 31, 2025)
    // Applies designer-authored consequence lines based on contributor tone and role.
    // Removes hardcoded phrasing and enables simulation-grade emotional feedback.
    // Refactor completes Sprint 3’s consequence layer for mesh-aware response modulation.
    #endregion
}