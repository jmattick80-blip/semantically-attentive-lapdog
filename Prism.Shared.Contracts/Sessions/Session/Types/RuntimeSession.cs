using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Agents;
using Prism.Shared.Contracts.Events;
using Prism.Shared.Contracts.Interfaces.MeshLogic;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Interfaces.Sessions;

namespace Prism.Shared.Contracts.Sessions.Session.Types
{
    public class RuntimeSession : PrismSession
    {
        // 🧠 Emotional Mesh Properties
        public Dictionary<string, string> ToneTags { get; set; } = new();
        public Dictionary<string, float> LayerWeights { get; set; } = new();
        public List<RippleEvent> RippleHistory { get; set; } = new();
        public List<string> Tags { get; set; } = new();

        public string CuratorRole { get; set; }

        public RuntimeSession(
            IEnvelopeValidator validator,
            IManifestRegistryResolver registryResolver,
            ICallbackDispatcher callbackDispatcher,
            ITraitRouter traitRouter,
            string contributorId,
            string role,
            string curatorRole,
            List<NpcDefinition> npcDefinitions = null,
            Dictionary<string, string> toneTags = null,
            List<RippleEvent> rippleHistory = null,
            List<string> tags = null,
            Dictionary<string, float> layerWeights = null)
            : base(validator, registryResolver, callbackDispatcher, traitRouter, contributorId, role, npcDefinitions)
        {
            SessionId = Guid.NewGuid().ToString();
            TraitId = "trait.session.runtime";
            TraitName = "Mappers Session";
            Description = "Tracks contributor state, scenario tags, and emotional simulation context.";

            CuratorRole = curatorRole;
            ToneTags = toneTags ?? new();
            RippleHistory = rippleHistory ?? new();
            Tags = tags ?? new();
            LayerWeights = layerWeights ?? new();
        }
    }
}