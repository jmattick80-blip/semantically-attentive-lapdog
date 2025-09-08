using System.Collections.Generic;
using Prism.Shared.Contracts.Base.Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces.Requests;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Sessions;

namespace Prism.Shared.Contracts
{
    public class PrismIntentRequest : PrismContractBase, IPrismIntentRequest
    {
        public SemanticIntent Intent { get; set; } = new SemanticIntent(); // 👈 Concrete type
        public SessionEntity TargetEntity { get; set; } = new SessionEntity(); // 👈 Optional: also switch from interface
        public string Verb { get; set; } = string.Empty;
        public Dictionary<string, object> Payload { get; set; } = new Dictionary<string, object>();
        public SessionContext Session { get; set; } = new SessionContext();
    }
}