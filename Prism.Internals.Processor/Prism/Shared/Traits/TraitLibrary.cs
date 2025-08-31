using GalleryDrivers.Prism.Shared.Interfaces.Traits;

namespace GalleryDrivers.Prism.Shared.Traits
{
    /// <summary>
    /// TraitLibrary provides centralized access to core trait instances.
    /// Traits are modular, narratable, and used for runtime filtering,
    /// contributor onboarding, and simulation scaffolds.
    /// </summary>
    public static class TraitLibrary
    {
        
        // 🧭 Trait used to mark onboarding-related manifests and clusters
        public static ITrait Onboarding => new BasicTrait(
            traitId: "trait.onboarding",
            traitName: "Onboarding",
            description: "Used for contributor onboarding flows and simulation scaffolds."
        );
        
        public static ITrait ContributorSafe => new BasicTrait(
            traitId: "trait.contributor_safe",
            traitName: "Contributor Safe",
            description: "Ensures safety and stability when contributors are active."
        );

        // 🎯 Trait used to mark intent resolution systems
        public static ITrait IntentBound => new BasicTrait(
            traitId: "trait.intent",
            traitName: "Intent Bound",
            description: "Handles contributor intent resolution and trait propagation."
        );

        // 🖼️ Trait used to surface narratable systems in overlays
        public static ITrait Narratable => new BasicTrait(
            traitId: "trait.narratable",
            traitName: "Narratable",
            description: "Marks systems that should be surfaced in runtime overlays and diagnostics."
        );

        // 🧪 Trait used for async readiness and simulation scaffolds
        public static ITrait AsyncReady => new BasicTrait(
            traitId: "trait.async",
            traitName: "Async Ready",
            description: "Supports async orchestration and contributor-safe simulation."
        );

        // 🧩 Trait used for role switching and input map isolation
        public static ITrait RoleAware => new BasicTrait(
            traitId: "trait.role",
            traitName: "Role Aware",
            description: "Supports role switching, input map isolation, and contributor context."
        );
        
        // ⚙️ Trait used to mark system-level manifests and orchestration clusters
        public static ITrait SystemLevel => new BasicTrait(
            traitId: "trait.system_level",
            traitName: "System Level",
            description: "Marks manifests responsible for global system orchestration, shutdown, and contributor lifecycle."
        );
    }
}