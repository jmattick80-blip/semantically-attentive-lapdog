namespace Prism.Shared.Contracts.Enums
{
    public static class PrismSelectorTypes
    {
        /// <summary>
        /// Defines the semantic role of an entity within Prism’s simulation mesh.
        /// Each type carries emotional consequence, contributor context, or routing behavior.
        /// </summary>
        public enum EntityType
        {
            GallerySeed,             // Foundational prefab for gallery simulations
            MeshSnapshot,            // Frozen emotional mesh state for auditing or replay
            CuratorNote,             // Contributor-authored emotional annotation
            ContributorFingerprint,  // Semantic imprint of contributor tone and trait history
            Unknown,                 // Fallback type for ambiguous or unclassified entities
            Exhibit,                 // Narratable unit within a gallery or simulation
            Session                  // Scoped contributor context with traits, mood
        }

        /// <summary>
        /// Defines the origin or behavioral role of an emotional source.
        /// Used to guide tone emission, overlay behavior, and contributor feedback.
        /// </summary>
        public enum MoodSourceType
        {
            Default,         // Standard emotional source—no specialization
            None,            // No emotional influence—neutral or silent
            Ambient,         // Passive tone setter—background influence
            Interactive,     // Responds to contributor input—triggers overlays
            Reflective,      // Mirrors contributor state—used in feedback
            
            Silent,          // Suppresses emotional output—fallback-safe
            Unknown          // Fallback-safe default—undefined source type
        }

        /// <summary>
        /// Defines how emotional tone is modulated within Prism’s simulation mesh.
        /// MoodModifiers influence overlays, narration, and contributor experience across time, space, and behavior.
        /// </summary>
        public enum MoodModifier
        {
            // ─── Temporal & Rhythmic ──────────────────────────────────────────────
            Pulsing,       // Emits rhythmic emotional signals
            Rhythmic,      // Follows contributor pacing or mesh tempo
            Fading,        // Gradual emotional transitions
            Drifting,      // Wandering emotional states

            // ─── Spatial & Influence ──────────────────────────────────────────────
            Expanding,     // Broadens emotional influence over time
            Contracting,   // Narrows emotional focus
            Dampen,        // Suppresses emotional output

            // ─── Expressive Tone ─────────────────────────────────────────────────
            Vibrant,       // Bright, lively emotional expressions
            Mellow,        // Soft, soothing emotional tones
            Intense,       // Strong, dramatic emotional states
            Subtle,        // Light, nuanced emotional cues
            Dashing,       // Quick, energetic emotional bursts

            // ─── Behavioral ──────────────────────────────────────────────────────
            ToneAdaptive,  // Responds to contributor mood or mesh state
            Persistent,    // Maintains emotional state across sessions
            Silent,        // Suppresses narration or tone emission

            // ─── Defaults ────────────────────────────────────────────────────────
            None,          // No modification—neutral source
            Default        // Standard behavior—no specific modifier
        }

        /// <summary>
        /// Defines the strength or presence of emotional tone emitted by a source.
        /// Used to guide overlay intensity, contributor feedback, and mesh modulation.
        /// </summary>
        public enum MoodIntensity
        {
            Default,   // Standard emotional intensity
            None,      // No emotional presence
            Low,       // Gentle emotional presence
            Medium,    // Balanced emotional output
            High,      // Strong emotional presence
            Custom     // User-defined intensity for runtime tuning
        }

        /// <summary>
        /// Defines the duration or lifespan of an emotional tone or overlay.
        /// Used to guide narration timing, and contributor experience.
        /// </summary>
        public enum MoodDuration
        {
            Default,     // Standard duration
            None,        // No duration—instantaneous cue
            Transient,   // Short-lived emotional state
            Sustained,   // Lasting tone across a roles actions
            Persistent,  // Enduring tone across a session
            Custom       // User-defined duration
        }
    }
    #region PrismSelectorTypes Summary
    /// <summary>
    /// PrismSelectorTypes defines prefab-safe enums for emotional routing, trait modulation,
    /// and contributor classification across Prism OS.
    /// These types are used in manifests, overlays, and session scaffolds to guide tone and consequence.
    /// </summary>
    /// LastModified: 2025-09-03
    /// JM ✦ Prism Architect ✦ 2025-09-03
    #endregion

}