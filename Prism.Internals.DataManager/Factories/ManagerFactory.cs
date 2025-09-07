using Prism.Shared.Contracts.Config;
using Prism.Shared.Contracts.Interfaces.Managers;
using Prism.Internals.DataManager.Managers;

namespace Prism.Internals.DataManager.Factories;

public static class ManagerFactory
{
    public static List<IPrismManager> CreateFromConfig(List<MeshComponentConfig> configMeshComponents)
    {
        var managers = new List<IPrismManager>();

        foreach (var component in configMeshComponents)
        {
            var manager = CreateManager(component.Manager);
            managers.Add(manager);
        }

        return managers;
    }

    private static IPrismManager CreateManager(string managerType)
    {
        return managerType switch
        {
            "ProfileManager" => new ProfileManager(),
            "RippleManager" => new RippleManager(),
            _ => throw new NotSupportedException($"Unknown manager type: {managerType}")
        };
    }
    #region ManagerFactory Summary (Sprint 5 – September 07, 2025)
        // ManagerFactory orchestrates the creation of IPrismManager instances from mesh configuration.
        // Supports modular manager instantiation for profile hydration, ripple consequence routing, and emotional governance.
        // Currently supports ProfileManager and RippleManager, with fallback handling for unknown types.
        // Enables prefab-safe simulation scaffolding and contributor-safe runtime orchestration.
        // JM ✦ Prism Architect ✦ September 07, 2025
    #endregion
}