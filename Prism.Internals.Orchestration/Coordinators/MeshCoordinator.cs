using Prism.Internals.Orchestration.Registries;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Events;
using Prism.Shared.Contracts.Interfaces.Managers;
using Prism.Shared.Contracts.Interfaces.Orchestration;
using Prism.Shared.Contracts.Interfaces.Providers;

namespace Prism.Internals.Orchestration.Coordinators
{
    public class MeshCoordinator : IPrismCoordinator
    {
        private readonly List<IPrismManager> _managers;
        private readonly List<IMeshProfileProvider> _adapters;
        private readonly MeshLayerRegistry _layerRegistry;

        // 🌊 Ripple history tracking
        private readonly List<RippleEvent> _rippleLog = new();

        public MeshCoordinator(
            List<IPrismManager> managers,
            List<IMeshProfileProvider> adapters,
            MeshLayerRegistry layerRegistry)
        {
            _managers = managers ?? throw new ArgumentNullException(nameof(managers));
            _adapters = adapters ?? throw new ArgumentNullException(nameof(adapters));
            _layerRegistry = layerRegistry ?? throw new ArgumentNullException(nameof(layerRegistry));
        }

        public async Task<List<MeshProfile>> OrchestrateMeshAsync()
        {
            var profiles = await CollectProfilesAsync();

            foreach (var manager in _managers)
            {
                await manager.InitializeAsync(profiles);
                Console.WriteLine($"✅ {manager.ManagerId} initialized: {manager.Description}");
            }

            Console.WriteLine($"🕸️ MeshCoordinator: {profiles.Count} contributors placed.");
            return profiles;
        }

        private async Task<List<MeshProfile>> CollectProfilesAsync()
        {
            var collected = new List<MeshProfile>();

            foreach (var adapter in _adapters)
            {
                var profiles = await adapter.GetProfilesAsync();
                var meshProfiles = profiles.ToList();
                Console.WriteLine($"📦 Adapter '{adapter.GetType().Name}' provided {meshProfiles.Count} profiles.");
                collected.AddRange(meshProfiles);
            }

            return collected;
        }

        // 🌊 Emit ripple into mesh log
        public void EmitRipple(RippleEvent ripple)
        {
            if (string.IsNullOrWhiteSpace(ripple.SourceContributorId))
            {
                Console.WriteLine("⚠️ MeshCoordinator: Invalid ripple event.");
                return;
            }

            _rippleLog.Add(ripple);
            Console.WriteLine(
                $"🌊 Ripple emitted: {ripple.RippleType} from {ripple.SourceContributorId} at {ripple.EmittedAt:u}");
        }

        // 🔍 Query ripple history by contributor
        public List<RippleEvent> GetRecentRipples(string contributorId)
        {
            if (string.IsNullOrWhiteSpace(contributorId))
                return new List<RippleEvent>();

            return _rippleLog
                .Where(r => r.SourceContributorId == contributorId)
                .OrderByDescending(r => r.EmittedAt)
                .ToList();
        }
    }

    #region MeshCoordinator
    // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    // 🧠 Summary Region: MeshCoordinator
    //
    // Coordinates mesh behavior across managers, adapters, and layer registry.
    // Collects contributor mesh profiles, initializes managers, and logs ripple events.
    // Enables emotional traceability and prefab-safe orchestration.
    //
    // ┌─────────────────────────────────────────────────────────────────────────┐
    // │ Responsibilities                                                       │
    // ├─────────────────────────────────────────────────────────────────────────┤
    // │ • Collect mesh profiles from IMeshProfileProvider adapters              │
    // │ • Initialize IPrismManager instances with contributor profiles          │
    // │ • Emit and query ripple events for emotional traceability              │
    // │ • Hydrate mesh layers via MeshLayerRegistry                            │
    // └─────────────────────────────────────────────────────────────────────────┘
    //
    // 🔗 Dependencies:
    // - Prism.Shared.Contracts (Profiles, Events, Interfaces)
    // - Prism.Internals.Orchestration.Registries (MeshLayerRegistry)
    //
    // 🧩 Emotional Consequence:
    // - Ripple events are logged with contributor ID and timestamp
    // - Manager initialization is narratable and prefab-safe
    // - Mesh profile orchestration supports multiplayer consequence flows
    //
    // ✦ Maintainer: Jeremy M.
    // ✦ Last Audited: Sprint 5 – 2025-09-07
    // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

    #endregion
}



