using GalleryDrivers.Prism.Shared.Interfaces.Session;

namespace GalleryDrivers.Prism.Shared.Sessions.Types
{
    public class RuntimeSession : PrismSession
    {
        public RuntimeSession(
            IEnvelopeValidator validator,
            IManifestRegistryRouter registryRouter,
            ICallbackDispatcher callbackDispatcher,
            string contributorId,
            string role)
            : base(validator, registryRouter, callbackDispatcher, contributorId, role)
        {
            SessionId = System.Guid.NewGuid().ToString();
            TraitId = "trait.session.runtime";
            TraitName = "Runtime Session";
            Description = "Tracks contributor state, scenario tags, and emotional simulation context.";
        }
    }
}