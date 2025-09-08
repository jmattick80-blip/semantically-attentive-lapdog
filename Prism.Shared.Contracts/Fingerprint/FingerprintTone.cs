namespace Prism.Shared.Contracts.Fingerprint
{
    public class FingerprintTone
    {
        /// <summary>
        /// The contributor’s tone classification.
        /// </summary>
        public ToneType Type { get; }

        /// <summary>
        /// Optional intensity or nuance modifier (e.g. “mild frustration” vs. “urgent frustration”).
        /// </summary>
        public string Modifier { get; }

        public FingerprintTone(ToneType type, string modifier = null)
        {
            Type = type;
            Modifier = modifier;
        }

        public override string ToString()
        {
            return Modifier == null ? Type.ToString() : $"{Modifier} {Type}";
        }
    }

    /// <summary>
    /// Enumerates common contributor tones used for emotional modulation.
    /// </summary>
    public enum ToneType
    {
        Neutral,
        Curious,
        Frustrated,
        Reflective,
        Playful,
        Directive
    }

    #region Audit Summary (September 7, 2025)
    

    // currently in use by intent controller.

    #endregion
    #region FingerprintTone Summary (August 31, 2025)
    // FingerprintTone represents a contributor’s emotional engagement style.
    // It is used by tone adapters to modulate feedback and scaffold emotional consequence.
    // This stub supports Sprint 2’s emotional intake system and prepares Prism for tone-aware response.
    #endregion
}