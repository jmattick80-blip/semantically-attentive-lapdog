using System.Collections.Generic;

namespace Prism.Shared.Contracts.Config;

public class MeshComponentConfig
{
    public string Manager { get; set; }
    public List<AdapterConfig> Adapters { get; set; }
}