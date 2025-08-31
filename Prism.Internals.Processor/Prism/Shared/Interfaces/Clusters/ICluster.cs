using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;
using GalleryDrivers.Prism.Shared.Sessions.Types;

namespace GalleryDrivers.Prism.Shared.Interfaces.Clusters
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
    }
}