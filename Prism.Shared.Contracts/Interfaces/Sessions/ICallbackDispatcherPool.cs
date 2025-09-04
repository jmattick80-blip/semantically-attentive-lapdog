namespace Prism.Shared.Contracts.Interfaces.Sessions;

public interface ICallbackDispatcherPool
{
    ICallbackDispatcher Get(string contributorId);
}