using Prism.Intent.Identity.Fingerprint;

namespace Prism.Intent.Identity.Fingerprint
{
    /// <summary>
    /// Provides contributor fingerprint data for session hydration and envelope enrichment.
    /// Implementations may resolve identity from headers, tokens, or contextual metadata.
    /// </summary>
    public interface IFingerprintProvider
    {
        /// <summary>
        /// Resolves the contributor fingerprint for the current session or request context.
        /// </summary>
        ContributorFingerprint Resolve();
    }

    #region IFingerprintProvider Summary (August 31, 2025)
    // This interface defines the contract for resolving contributor identity and tone.
    // It supports dependency injection and mocking for onboarding, testing, and trace hydration.
    // Implementations may vary by context (e.g. API, simulation, editor), but all feed the emotional mesh.
    #endregion
}