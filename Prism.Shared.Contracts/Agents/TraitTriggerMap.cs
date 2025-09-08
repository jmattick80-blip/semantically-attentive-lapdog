using System.Collections.Generic;

namespace Prism.Shared.Contracts.Agents
{
    public class TraitTriggerMap
    {
        public List<TraitTrigger> Triggers { get; set; } = new  List<TraitTrigger>();
    }

    public class TraitTrigger
    {
        public string TraitName { get; set; } = string.Empty;
        public string TriggerKey { get; set; } = string.Empty;
        public string TriggerValue { get; set; } = string.Empty;
    }
    // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 🧠 Summary Region: TraitTriggerMap & TraitTrigger
//
// Defines trait-based triggers used to modulate NPC behavior and scenario flow.
// Each trigger maps a trait to a key-value condition, enabling emotionally scoped
// reactions, transformation routing, and ripple consequence evaluation.
//
// ┌─────────────────────────────────────────────────────────────────────────┐
// │ Responsibilities                                                       │
// ├─────────────────────────────────────────────────────────────────────────┤
// │ • Store list of TraitTrigger entries                                   │
// │ • Define trait name, trigger key, and trigger value                    │
// │ • Support NPC reaction logic and scenario orchestration                │
// └─────────────────────────────────────────────────────────────────────────┘
//
// 🔗 Dependencies:
// - None (pure data contract)
//
// 🧩 Emotional Consequence:
// - Enables narratable trait-based reactions in simulation
// - Used in NPC definitions and mesh consequence routing
// - Prefab-safe and actively integrated into runtime flows
//
// ✦ Maintainer: Jeremy M.
// ✦ Last Audited: Sprint 5 – 2025-09-07
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
}