using System;
using System.Collections.Generic;
using Prism.Shared.Contracts;

namespace Prism.Internals.Globals
{
    public static class SessionManager
    {
        private static readonly Dictionary<string, SessionContext> _sessionRegistry = new();

        public static bool ValidateSession(string sessionId)
        {
            return !string.IsNullOrEmpty(sessionId) && _sessionRegistry.ContainsKey(sessionId);
        }

        public static SessionContext? GetSession(string sessionId)
        {
            return _sessionRegistry.TryGetValue(sessionId, out var session) ? session : null;
        }

        public static SessionContext CreateSession(string sessionId, string galleryId, int gallerySeedNumber)
        {
            var context = new SessionContext
            {
                SessionId = sessionId,
                GalleryId = galleryId,
                GallerySeedNumber = gallerySeedNumber,
                CuratorPhase = PrismConstants.DefaultCuratorPhase,
                CreatedAt = DateTime.UtcNow,
                Status = "Active",
                MeshSnapshotId = GlobalContext.CurrentMeshSnapshotId 
                                 ?? $"{PrismConstants.DefaultMeshSnapshotPrefix}{galleryId}_{gallerySeedNumber}"
            };

            _sessionRegistry[sessionId] = context;
            return context;
        }

        public static void UpdateSessionGallery(string sessionId, string galleryId, int seed)
        {
            if (_sessionRegistry.TryGetValue(sessionId, out var session))
            {
                session.GalleryId = galleryId;
                session.GallerySeedNumber = seed;
                session.MeshSnapshotId = $"{PrismConstants.DefaultMeshSnapshotPrefix}{galleryId}_{seed}";
            }
        }
    }
}