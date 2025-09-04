using Prism.Internals.Orchestration.Registries;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Events;
using Prism.Shared.Contracts.Interfaces.Managers;
using Prism.Shared.Contracts.Orchestration;
using Prism.Shared.Contracts.Providers;

namespace Prism.Internals.Orchestration.Coordinators;

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
        if (ripple == null || string.IsNullOrWhiteSpace(ripple.SourceContributorId))
        {
            Console.WriteLine("⚠️ MeshCoordinator: Invalid ripple event.");
            return;
        }

        _rippleLog.Add(ripple);
        Console.WriteLine($"🌊 Ripple emitted: {ripple.RippleType} from {ripple.SourceContributorId} at {ripple.EmittedAt:u}");
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