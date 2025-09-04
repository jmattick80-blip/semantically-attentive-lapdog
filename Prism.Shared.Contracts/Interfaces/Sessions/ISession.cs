using System;
using Prism.Shared.Contracts.Interfaces.Runtime;

namespace Prism.Shared.Contracts.Interfaces.Sessions
{
    public interface ISession : IRuntime
    {
        string SessionId { get; }
        DateTime Timestamp { get; }
    }
}