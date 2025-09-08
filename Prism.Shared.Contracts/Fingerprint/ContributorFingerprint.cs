namespace Prism.Shared.Contracts.Fingerprint
{
    public class ContributorFingerprint
    {
        /// <summary>
        /// Unique contributor identifier (e.g. GUID, username, or semantic alias).
        /// </summary>
        public string ContributorId { get; }

        /// <summary>
        /// Optional contributor role or access tier (e.g. Designer, Curator, Observer).
        /// </summary>
        public string Role { get; }

        /// <summary>
        /// Emotional tone or engagement style (e.g. Curious, Frustrated, Reflective).
        /// Used by tone adapters to modulate feedback.
        /// </summary>
        public FingerprintTone Tone { get; }

        /// <summary>
        /// Optional session tag or phase marker (e.g. Onboarding, Escalation).
        /// </summary>
        public string Phase { get; }

        public ContributorFingerprint(string contributorId, string role, FingerprintTone tone, string phase = null)
        {
            ContributorId = contributorId;
            Role = role;
            Tone = tone;
            Phase = phase;
        }

        /// <summary>
        /// Returns a narratable summary of the fingerprint for trace logging.
        /// </summary>
        public override string ToString()
        {
            return $"{ContributorId} ({Role}) - Tone: {Tone}, Phase: {Phase ?? "Unspecified"}";
        }
    }
    #region ContributorFingerprint Summary (August 31, 2025)
    // ContributorFingerprint represents a contributor’s identity and emotional tone.
    // It is attached to envelopes and used to hydrate registries with context.
    // This module scaffolds Sprint 2’s emotional intake system.
    #endregion

}