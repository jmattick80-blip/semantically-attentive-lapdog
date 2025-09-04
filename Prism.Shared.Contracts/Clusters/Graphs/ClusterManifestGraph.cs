using System.Collections.Generic;
using System.Linq;

namespace Prism.Shared.Contracts.Clusters.Graphs
{
    public class ClusterManifestGraph
    {
        private readonly Dictionary<string, List<string>> _clusterLinks = new Dictionary<string, List<string>>();

        public void LinkClusters(string parentId, string childId)
        {
            if (!_clusterLinks.ContainsKey(parentId))
                _clusterLinks[parentId] = new List<string>();

            _clusterLinks[parentId].Add(childId);
        }

        public IEnumerable<string> GetChildren(string parentId)
        {
            return _clusterLinks.TryGetValue(parentId, out var children) ? children : Enumerable.Empty<string>();
        }

        public IEnumerable<string> GetAllParents()
        {
            return _clusterLinks.Keys;
        }

        public void ClearGraph()
        {
            _clusterLinks.Clear();
        }
    }
}