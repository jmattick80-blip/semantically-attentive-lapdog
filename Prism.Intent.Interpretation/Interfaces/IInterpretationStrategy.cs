using Prism.Intent.Identity.Fingerprint;
using Prism.Intent.Interpretation.Config;
using Prism.Shared.Contracts;

namespace Prism.Intent.Interpretation.Interfaces
{
    public interface IInterpretationStrategy
    {
        /// <summary>
        /// Interprets contributor intent using fingerprint, tone history, and manifest rules.
        /// </summary>
        PrismResult Interpret(
            string intentName,
            ContributorFingerprint fingerprint,
            List<FingerprintTone> toneHistory,
            InterpretationManifest manifest);
    }

    #region IInterpretationStrategy Summary (August 31, 2025)
    // IInterpretationStrategy defines how Prism interprets contributor intent across tone, emotion, and phase.
    // It uses fingerprint metadata, tone history, and manifest rules to generate narratable consequence.
    // This stub scaffolds Sprint 3’s interpretation layer and prepares Prism for mesh activation.
    #endregion
}