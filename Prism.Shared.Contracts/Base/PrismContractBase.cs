using System;

namespace Prism.Shared.Contracts.Base
{
    namespace Prism.Shared.Contracts
    {
        public abstract class PrismContractBase
        {
            public Guid RequestId { get; set; }
            public string Slug { get; set; } = string.Empty;
            public DateTime Timestamp { get; set; } = DateTime.UtcNow;

            #region Summary
            // PrismContractBase provides shared metadata for semantic artifacts.
            // Includes RequestId for traceability, Slug for narratable pairing, and Timestamp for audit/replay.
            // Inherited by requests, results, and future semantic types.
            #endregion
        }
    }
    // ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 🧠 Summary Region: PrismIntentRequest
//
// Encapsulates contributor intent for simulation routing.
// Includes semantic intent, target entity, verb, payload, and session context.
// Inherits shared metadata from PrismContractBase for traceability and replay.
//
// ┌─────────────────────────────────────────────────────────────────────────┐
// │ Responsibilities                                                       │
// ├─────────────────────────────────────────────────────────────────────────┤
// │ • Carry contributor intent and payload                                 │
// │ • Bind to session context and target entity                            │
// │ • Support ripple emission and consequence routing                      │
// └─────────────────────────────────────────────────────────────────────────┘
//
// 🔗 Dependencies:
// - Prism.Shared.Contracts.Base (PrismContractBase)
// - Prism.Shared.Contracts.Interfaces (IPrismIntentRequest, ISessionContext)
//
// 🧩 Emotional Consequence:
// - Narrates contributor action with context and payload
// - Used in runtime processor, registry adapter, and mesh router
// - Prefab-safe and multiplayer-ready
//
// ✦ Maintainer: Jeremy M.
// ✦ Last Audited: Sprint 5 – 2025-09-07
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
}