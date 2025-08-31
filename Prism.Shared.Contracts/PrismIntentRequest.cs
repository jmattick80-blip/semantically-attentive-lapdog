using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Base.Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces;
using Prism.Shared.Contracts.Interfaces.Requests;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts
{
    public class PrismIntentRequest : PrismContractBase,IPrismIntentRequest
    {
        public ISemanticIntent Intent { get; set; } = default;
        public ISessionEntity TargetEntity { get; set; } = default;
        public string Verb { get; set; } = string.Empty;
        public Dictionary<string, object> Payload { get; set; } = new Dictionary<string, object>();
        public SessionContext Session { get; set; } = default;
        
        #region Summary
        // PrismIntentRequest encapsulates a semantic input to the simulation.
        // It includes the actor (Intent), the target (Entity), the action (Verb),
        // and any parameters (Payload), all scoped to a session.
        // Slug and RequestId provide traceability and testability.
        #endregion
    }
}