using System;
using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;

namespace GalleryDrivers.Prism.Shared.Clusters.Base
{
    /// <summary>
    /// Represents a base cluster used to organize and bind manifests within Prism.
    /// Provides foundational logic for manifest registration, trait activation, and narratable logging.
    /// </summary>
    public abstract class ClusterBase
    {
        protected internal IClusterManifest Manifest { get; }

        private readonly List<IManifest> _children = new List<IManifest>();

        protected IEnumerable<IManifest> Children => _children;

        protected ClusterBase(IClusterManifest manifest)
        {
            Manifest = manifest ?? throw new ArgumentNullException(nameof(manifest));
        }

        protected internal void AddChild(IManifest manifest)
        {
            _children.Add(manifest);
            Log($"📦 Manifest added to cluster: {manifest.DisplayName}");
        }

        protected virtual void ActivateDefaultTraits()
        {
            // Override in derived classes to bind traits
        }

        protected virtual void Log(string message)
        {
            // Replace with your logging system or annotation service
            Console.WriteLine(message);
        }
    }
}