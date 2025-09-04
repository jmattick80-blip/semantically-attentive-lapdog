using System.Collections.Generic;

namespace Prism.Shared.Contracts.Registries.Resolvers;

public class RegistryResolverDescriptor
{
    public string StrategyName { get; set; }
    public string Phase { get; set; }
    public List<string> FallbackNotes { get; set; }
}