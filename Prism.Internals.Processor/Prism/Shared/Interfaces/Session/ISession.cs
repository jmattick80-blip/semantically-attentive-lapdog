using System;
using GalleryDrivers.Prism.Shared.Interfaces.Runtime;

namespace GalleryDrivers.Prism.Shared.Interfaces.Session
{
    public interface ISession : IRuntime
    {
        string SessionId { get; }
        DateTime Timestamp { get; }
    }
}