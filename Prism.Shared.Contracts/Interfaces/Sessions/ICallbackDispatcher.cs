using Prism.Shared.Contracts.Interfaces.Envelopes;

namespace Prism.Shared.Contracts.Interfaces.Sessions
{
    public interface ICallbackDispatcher
    {
        /// <summary>
        /// Dispatches the result of an envelope processing operation to the appropriate callback handler.
        /// </summary>
        /// <param name="result">The result to dispatch, typically containing emotional feedback, trait updates, or overlay triggers.</param>
        void Dispatch(IEnvelopeResults result);
    }
}