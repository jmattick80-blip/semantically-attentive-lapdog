using Prism.Intent.Identity.Fingerprint;
using Prism.Shared.Contracts.Fingerprint;
using Prism.Shared.Contracts.Phase;
using Prism.Shared.Contracts.Tone;

namespace Prism.Intent.Identity.Phase
{
    /// <summary>
    /// Hydrates registry logic using contributor fingerprint, phase context, and authored fallback narration.
    /// </summary>
    public class PhaseRegistryHydrator
    {
        private readonly IPhaseContext _context;
        private readonly PhaseFallbackManifest _fallbackManifest;

        public PhaseRegistryHydrator(IPhaseContext context, PhaseFallbackManifest fallbackManifest)
        {
            _context = context;
            _fallbackManifest = fallbackManifest;
        }

        /// <summary>
        /// Hydrates registry logic based on contributor fingerprint and authored fallback narration.
        /// </summary>
        public void Hydrate(string registryName, ContributorFingerprint fingerprint, PhaseManifest manifest)
        {
            manifest.RegistryName = registryName;
            manifest.Tags ??= new List<string>();

            var phase = _context.GetPhase();
            var tone = fingerprint.Tone.Type.ToString();
            var role = fingerprint.Role;

            manifest.ValidationMode = _context.GetValidationMode();
            manifest.Tags.Add($"Phase:{phase}");
            manifest.Tags.Add($"Tone:{tone}");
            manifest.Tags.Add($"Role:{role}");
            manifest.Tags.Add("MeshConsequence:Hydrated");

            manifest.FallbackMessage = _fallbackManifest.GetFallback(phase, role, tone)
                ?? "Let’s continue."; // Default if no authored fallback found
        }
    }

    #region PhaseRegistryHydrator Summary (Sprint 4 – August 31, 2025)
    // PhaseRegistryHydrator adapts registry logic using contributor fingerprint and authored fallback narration.
    // It tags mesh consequence, tone, and role for emotional routing and replay.
    // Refactor completes Sprint 4’s registry hydration layer and prepares Prism for simulation-grade consequence.
    #endregion
}