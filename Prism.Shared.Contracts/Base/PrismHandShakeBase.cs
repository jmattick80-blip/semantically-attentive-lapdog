using System;
using Prism.Shared.Contracts.Interfaces.Requests;

namespace Prism.Shared.Contracts.Base
{
    public class PrismHandshake
    {
        public IPrismIntentRequest Request { get; set; } = null;
        public IPrismIntentResult Result { get; set; } = null;
        public string Channel { get; set; } = "Registry"; // e.g. "Mesh", "Validator", "Scenario"
        public string Version { get; set; } = "1.0.0";
        public DateTime ExchangedAt { get; set; } = DateTime.UtcNow;

        #region Summary
        // PrismHandshake represents a full semantic exchange between systems.
        // Includes the original request, narratable result, and routing metadata.
        // Used for audit logs, contributor dashboards, multiplayer overlays, and replay systems.
        #endregion
    }
}