using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.MeshLogic;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Sessions.Session.Types
{
    public class RuntimeSession : PrismSession
    {
        public List<IEntityTransformer> EntityTransformers { get; set; } = new();

        public RuntimeSession(
            IEnvelopeValidator validator,
            IManifestRegistryResolver registryResolver,
            ICallbackDispatcher callbackDispatcher,
            string contributorId,
            string role,
            string curatorRole,
            string phase)
            : base(validator, registryResolver, callbackDispatcher, contributorId, role)
        {
            SessionId = Guid.NewGuid().ToString();
            TraitId = "trait.session.runtime";
            TraitName = "Mappers Session";
            Description = "Tracks contributor state, scenario tags, and emotional simulation context.";

            CuratorRole = curatorRole;
            Phase = phase;
        }
    }
}