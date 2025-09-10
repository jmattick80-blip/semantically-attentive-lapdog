using System;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Sessions.Session.Types;

namespace Prism.Shared.Contracts.Envelopes.Types
{
    public class SemanticIntentEnvelope : IntentEnvelope
    {
        public SemanticIntentEnvelope() { }
        
        public SemanticIntentEnvelope(string intentId, PrismSession session)
        {
            IntentId = intentId;
            Intent = SystemIntent.Semantic;
            Session = session;
            DisplayName = intentId;
            RoleContext = session?.CuratorRole ?? "Unknown";
            Tags = session?.Tags?.ToArray() ?? Array.Empty<string>();
        }
    }    
    #region Summary
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 🧠 Summary Region: SemanticIntentEnvelope
//
// Represents a contributor-driven semantic intent envelope.
// Used to route structured intent data through Prism’s emotional mesh,
// enabling prefab-safe transformation, trait propagation, and consequence routing.
//
// ┌─────────────────────────────────────────────────────────────────────────┐
// │ Responsibilities                                                       │
// ├─────────────────────────────────────────────────────────────────────────┤
// │ • Inherit contributor metadata and payload from IntentEnvelope         │
// │ • Serve as default envelope for semantic resolution flows              │
// │ • Support emotional mesh activation and replay logging                 │
// └─────────────────────────────────────────────────────────────────────────┘
//
// 🔗 Dependencies:
// - IntentEnvelope (base class)
// - EnvelopeMetadata, PayloadPackage, PrismSession
//
// 🧩 Emotional Consequence:
// - Enables narratable contributor intent routing
// - Supports prefab-safe envelope creation and mesh propagation
// - Ideal for registry hydration, dashboard feedback, and replay systems
//
// ✦ Maintainer: Jeremy M.
// ✦ Last Audited: Sprint 5 – 2025-09-07
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    #endregion
}

