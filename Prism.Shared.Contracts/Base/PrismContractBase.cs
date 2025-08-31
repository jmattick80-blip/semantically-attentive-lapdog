using System;

namespace Prism.Shared.Contracts.Base
{
    namespace Prism.Shared.Contracts
    {
        public abstract class PrismContractBase
        {
            public Guid RequestId { get; set; }
            public string Slug { get; set; } = string.Empty;
            public DateTime Timestamp { get; set; } = DateTime.UtcNow;

            #region Summary
            // PrismContractBase provides shared metadata for semantic artifacts.
            // Includes RequestId for traceability, Slug for narratable pairing, and Timestamp for audit/replay.
            // Inherited by requests, results, and future semantic types.
            #endregion
        }
    }
}