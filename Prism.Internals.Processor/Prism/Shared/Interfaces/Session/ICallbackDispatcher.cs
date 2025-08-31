using GalleryDrivers.Prism.Shared.Interfaces.Envelopes;

namespace GalleryDrivers.Prism.Shared.Interfaces.Session
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