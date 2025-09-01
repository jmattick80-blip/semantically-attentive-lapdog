using System.Collections.Generic;
using Prism.Shared.Contracts.Base.Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces.Requests;

namespace Prism.Shared.Contracts
{
    public class PrismIntentResult : PrismContractBase, IPrismIntentResult
    {
        public IPrismIntentRequest Request { get; set; }
        public bool Success { get; set; }
        public string ResultCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, object> Consequence { get; set; } = new Dictionary<string, object>();
        
        #region Summary
        // PrismIntentResult is the narratable response to a PrismIntentRequest.
        // It includes outcome flags, feedback, and consequence data.
        // Slug is the reversed identifier of the original request for pairing.
        // Used for audit logging, contributor feedback, and multiplayer orchestration.
        #endregion
    }
}