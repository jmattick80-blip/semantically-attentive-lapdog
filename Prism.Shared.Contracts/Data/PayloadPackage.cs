using System.Collections.Generic;

namespace Prism.Shared.Contracts.Data
{
    public class PayloadPackage
    {
        /// <summary>
        /// Traits applied during transformation (e.g. "Reactive", "Narratable").
        /// </summary>
        public List<string> Traits { get; set; } = new List<string>();

        /// <summary>
        /// Overlays or visual effects triggered by this payload (e.g. "StartupGlow").
        /// </summary>
        public List<string> Overlays { get; set; } = new  List<string>();

        /// <summary>
        /// Mood vector used for emotional mesh propagation (e.g. "Curiosity": 0.8).
        /// </summary>
        public Dictionary<string, float> MoodVector { get; set; } = new  Dictionary<string, float>();

        /// <summary>
        /// Optional metadata block for scenario editors, dashboards, or consequence logs.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; } = new  Dictionary<string, object>();
    }
    #region PayloadPackage Summary
    // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 🧠 Summary Region: PayloadPackage
//
// Represents a transformation payload used in simulation flows.
// Includes traits, overlays, mood vectors, and optional metadata
// for emotional mesh propagation and contributor feedback.
//
// ┌─────────────────────────────────────────────────────────────────────────┐
// │ Responsibilities                                                       │
// ├─────────────────────────────────────────────────────────────────────────┤
// │ • Carry traits applied during transformation                           │
// │ • Trigger overlays or visual effects                                   │
// │ • Propagate mood vectors into emotional mesh                           │
// │ • Store metadata for dashboards and replay systems                     │
// └─────────────────────────────────────────────────────────────────────────┘
//
// 🔗 Dependencies:
// - None (pure data contract)
//
// 🧩 Emotional Consequence:
// - Enables narratable transformation logic
// - Supports ripple consequence and contributor feedback
// - Prefab-safe and scenario-editor ready
//
// ✦ Maintainer: Jeremy M.
// ✦ Last Audited: Sprint 5 – 2025-09-07
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    #endregion
}