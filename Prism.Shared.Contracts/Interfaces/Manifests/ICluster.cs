using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Sessions;
using Prism.Shared.Contracts.Sessions.Session.Types;

namespace Prism.Shared.Contracts.Interfaces.Manifests
{
    public interface ICluster
    {
        string ClusterId { get; }
        bool IsNarratable { get; }
        IEnumerable<ITrait> GetActiveTraits();
        IEnumerable<string> GetSupportedInterfaces();
        void BindToSession(PrismSession session);
        void ActivateCluster();
        void DeactivateCluster();
        void ReceiveTraits(IEnumerable<ITrait> traits);
    }
}