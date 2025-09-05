using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces.Managers;

namespace Prism.Internals.DataManager.Managers
{
    public class RippleManager : IPrismManager
    {
        private readonly List<RippleProfile> _rippleProfiles = new();

        public string ManagerId { get; set; } = "RippleManager";
        public string Description { get; set; } = "Tracks contributor ripple readiness and emotional consequence propagation.";

        public Task InitializeAsync(List<MeshProfile> profiles)
        {
            if (profiles == null || profiles.Count == 0)
            {
                Console.WriteLine("⚠️ RippleManager: No profiles provided during initialization.");
                return Task.CompletedTask;
            }

            foreach (var profile in profiles)
            {
                var rippleProfile = new RippleProfile
                {
                    ContributorId = profile.ContributorId,
                    TraitCount = profile.Traits?.Count ?? 0,
                    IsRippleReady = (profile.Traits?.Any(t => t.IsActive) ?? false)
                };

                _rippleProfiles.Add(rippleProfile);

                Console.WriteLine($"🌊 RippleProfile created for {rippleProfile.ContributorId} | Traits: {rippleProfile.TraitCount} | Ready: {rippleProfile.IsRippleReady}");
            }

            return Task.CompletedTask;
        }
    }

    public class RippleProfile
    {
        public string ContributorId { get; set; }
        public int TraitCount { get; set; }
        public bool IsRippleReady { get; set; }
    }
}