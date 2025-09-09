using Prism.Shared.Contracts.Enums;

namespace Prism.Shared.Contracts.Interfaces.Envelopes
{
    public interface IEnvelope
    {
        string SystemHash { get; }
        SystemType Type { get; }
        SystemIntent Intent { get; set; }
        SystemState State { get; }
        string UnityId { get; set; }

        #region IEnvelope Summary Date 2025.08.16
        /// <summary>
        /// IEnvelope defines a traceable, narratable system wrapper.
        /// Used for CLI exports, overlay narration, and contributor diagnostics.
        /// Implemented by SystemEnvelope and InputEnvelope.
        /// </summary>
        #endregion
    }
}