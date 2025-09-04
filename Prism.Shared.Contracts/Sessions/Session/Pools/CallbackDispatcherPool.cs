using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Sessions.Session.CallbackResolvers;

namespace Prism.Shared.Contracts.Sessions.Session.Pools;

public class CallbackDispatcherPool : ICallbackDispatcherPool
{
    private readonly Dictionary<string, ICallbackDispatcher> _pool = new();

    public ICallbackDispatcher Get(string contributorId)
    {
        if (!_pool.ContainsKey(contributorId))
        {
            _pool[contributorId] = new CallbackDispatcher(); // Or inject dependencies here
        }

        return _pool[contributorId];
    }
}