using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces;
using Prism.Shared.Contracts.Interfaces.Requests;

namespace Prism.Internal.Registry
{
    public static class PrismIntentResultFactory
    {
        public static IPrismIntentResult CommitSuccess(IPrismIntentRequest request, SessionMetadata metadata)
        {
            var result = CreateBaseResult(request, true, "CommitSuccess", "Session committed successfully.");
            result.Consequence["SessionMetadata"] = metadata;
            result.Consequence["RegistryRefs"] = new List<string> { request.Session.SessionId };
            return result;
        }

        public static IPrismIntentResult CommitFailure(IPrismIntentRequest request, string reason)
        {
            return CreateBaseResult(request, false, "CommitFailure", reason);
        }
        
        private static PrismIntentResult CreateBaseResult(IPrismIntentRequest request, bool success, string resultCode, string message)
        {
            return new PrismIntentResult
            {
                Request = request,
                Success = success,
                ResultCode = resultCode,
                Message = message,
                Slug = new string(request.Slug.Reverse().ToArray()),
                Timestamp = DateTime.UtcNow,
                Consequence = new()
            };
        }
    }
    #region Summary
    // PrismIntentResultFactory centralizes the creation of narratable, multiplayer-safe intent results.
    // It ensures consistent formatting, slug reversal, timestamping, and consequence scaffolding.
    // Used across registry, mesh, and processor layers to return semantic feedback for contributor actions.
    // This factory supports success and failure flows, and can be extended for preview, rollback, or audit scenarios.
    // Part of PrismOS’s semantic backbone—every result tells a story, and every story is traceable.
    #endregion

}