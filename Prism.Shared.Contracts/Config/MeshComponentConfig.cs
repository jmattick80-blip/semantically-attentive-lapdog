using System.Collections.Generic;

namespace Prism.Shared.Contracts.Config
{
    public class MeshComponentConfig
    {
        public string Manager { get; set; }
        public List<AdapterConfig> Adapters { get; set; }
    }    
    #region MeshComponentConfig Summary
    // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 🧠 Summary Region: MeshComponentConfig
//
// Represents a mesh component configuration block.
// Defines manager identity and associated adapters.
//
// 🔗 Used In:
// - MeshConfigLoader
//    - Component hydration and adapter resolution
//
// 🧩 Emotional Consequence:
// - Enables modular mesh construction
//        - Supports contributor-safe adapter orchestration
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    #endregion
}

