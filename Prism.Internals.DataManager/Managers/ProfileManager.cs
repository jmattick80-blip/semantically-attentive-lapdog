using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces.Managers;

namespace Prism.Internals.DataManager.Managers
{
    public class ProfileManager : IPrismManager
    {
        private List<MeshProfile> _profiles = new();

        public string ManagerId { get; set; } = "ProfileManager";
        public string Description { get; set; } = "Handles contributor profile hydration and trait mapping.";

        public Task InitializeAsync(List<MeshProfile> profiles)
        {
            if (profiles.Count == 0)
            {
                Console.WriteLine("⚠️ ProfileManager: No profiles provided during initialization.");
                return Task.CompletedTask;
            }

            _profiles = profiles;
            Console.WriteLine($"🧠 ProfileManager initialized with {_profiles.Count} profiles.");

            // Optional: log contributor IDs or trait counts
            foreach (var profile in _profiles)
            {
                Console.WriteLine($"🔍 Profile: {profile.ContributorId ?? "Unknown"} | Traits: {profile.Traits?.Count ?? 0}");
            }

            return Task.CompletedTask;
        }
    }
}