using Prism.Intent.Identity.Fingerprint;
using Prism.Intent.Identity.Phase;

namespace Prism.Intent.Identity.Phase
{
    public class PhaseRegistryHydrator
    {
        private readonly IPhaseContext _context;

        public PhaseRegistryHydrator(IPhaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Hydrates registry logic based on contributor phase and tone.
        /// </summary>
        public void Hydrate(string registryName, ContributorFingerprint fingerprint, PhaseManifest manifest)
        {
            manifest.RegistryName = registryName;
            manifest.Tags ??= new List<string>();

            var phase = _context.GetPhase();
            manifest.ValidationMode = _context.GetValidationMode();

            switch (phase)
            {
                case "Onboarding":
                    manifest.Tags.Add("Phase:Onboarding");
                    manifest.FallbackMessage = "Let’s walk through this together.";
                    break;

                case "Escalation":
                    manifest.Tags.Add("Phase:Escalation");
                    manifest.FallbackMessage = "We’ll resolve this quickly.";
                    break;

                case "Reflection":
                    manifest.Tags.Add("Phase:Reflection");
                    manifest.FallbackMessage = "Let’s consider all perspectives.";
                    break;

                default:
                    manifest.Tags.Add("Phase:Unspecified");
                    manifest.FallbackMessage = "Let’s continue.";
                    break;
            }
        }
    }

    #region PhaseRegistryHydrator Summary (August 31, 2025)
    // PhaseRegistryHydrator adapts registry logic based on contributor phase and tone.
    // It uses IPhaseContext to determine validation mode and fallback narration.
    // This stub supports Sprint 2’s lifecycle awareness and prepares Prism for adaptive consequence.
    #endregion
}