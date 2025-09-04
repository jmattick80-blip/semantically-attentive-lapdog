namespace Prism.Shared.Contracts.Interfaces.Types
{
    public interface IIntentResolver
    {
        PrismResult Resolve(PrismIntentRequest request);
    }
}