namespace Prism.Shared.Contracts.Enums
{
    public static class PrismSelectorTypes
    {
        public enum EntityType
        {
            GallerySeed,
            MeshSnapshot,
            CuratorNote,
            ContributorFingerprint,
            Unknown,
            Exhibit
        }

        public enum MoodSourceType
        {
            Default,         // Standard emotional source—used when no specific type is defined
            None,            // No emotional influence—used for neutral or silent sources
            Ambient,         // Passive tone setter—background emotional influence
            Interactive,     // Responds to contributor input—triggers overlays or narration
            Reflective,      // Mirrors contributor state—used in feedback or memory recall
            Transformative,  // Alters emotional mesh—used in phase shifts or tone pivots
            Silent,          // Suppresses emotional output—can silence nearby sources
            Unknown          // Fallback-safe default—used when no source type is defined
        }

        public enum MoodModifier
        {
            // Temporal & Rhythmic
            Pulsing,         // Emits rhythmic emotional signals—used for timed overlays or tone shifts
            Rhythmic,        // Follows contributor pacing or mesh tempo—used for dynamic tone shaping
            Fading,          // Gradual emotional transitions—used for smooth overlays or tone shifts
            Drifting,        // Wandering emotional states—used for contemplative or surreal tones
            Seasonal,        // Adapts tone based on time, phase, or environmental context
            PhaseAware,      // Behaves differently across simulation phases—used in routing or overlays

            // Spatial & Influence
            Expanding,       // Broadens emotional influence over time—used for immersive ambiance
            Contracting,     // Narrows emotional focus—used for intimate or intense moments
            Dampen,          // Suppresses emotional output—used to mute nearby sources or tone adapters

            // Expressive Tone
            Vibrant,         // Bright, lively emotional expressions—used for joyful or exciting moments
            Mellow,          // Soft, soothing emotional tones—used for calm or peaceful scenes
            Intense,         // Strong, powerful emotional states—used for dramatic or climactic moments
            Subtle,          // Light, understated emotional cues—used for nuanced or complex tones
            Dashing,         // Quick, energetic emotional bursts—used for rapid reactions or highlights

            // Behavioral
            ToneAdaptive,    // Responds to contributor mood or mesh state—used in reflective narration
            Persistent,      // Maintains emotional state across sessions or interactions
            Silent,          // Suppresses narration or tone emission—used for fallback-safe nodes

            None,            // No modification—used for neutral or unaltered sources
            Default          // Standard behavior—used when no specific modifier is defined
        }

        public enum MoodIntensity
        {
            Default,         // Standard emotional intensity—used when no specific intensity is defined
            None,            // No emotional presence—used for silent or neutral sources
            Low,             // Gentle emotional presence—used for ambient or subtle tone
            Medium,          // Balanced emotional output—default for most sources
            High,            // Strong emotional presence—used for dramatic or immersive scenes
            Custom           // User-defined intensity—used for runtime tuning or editor overrides
        }

        public enum MoodDuration
        {
            Default,         // Standard duration—used when no specific timing is defined
            None,            // No duration—used for instantaneous or one-off emotional cues
            Transient,       // Short-lived emotional states—used for momentary overlays or reactions
            Sustained,       // Lasting emotional tones—used for phase-wide narration or ambiance
            Persistent,      // Enduring emotional states—used for session-wide mood setting
            Custom           // User-defined duration—used when specific timing is required
        }
    }
}