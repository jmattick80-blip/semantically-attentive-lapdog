using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Clusters.Types;

namespace GalleryDrivers.Prism.Shared.Overlays
{
    public class OverlayScaffold
    {
        public void RenderClusterOverlay(string clusterId, IEnumerable<string> traits)
        {
            
            foreach (var trait in traits)
            {
            }
        }

        public void RenderContributorAnnotation(string contributorId, string annotation)
        {
            
        }

        public void ClearOverlay()
        {
            
        }

        public static void Render(IntentCluster intentCluster)
        {
            
        }
        
        public static void Render(CoreCluster coreCluster)
        {
            
        }
    }
}