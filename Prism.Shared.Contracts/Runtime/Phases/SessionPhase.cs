using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Shared.Contracts.Agents;
using Prism.Shared.Contracts.Enums;
using Prism.Shared.Contracts.Interfaces.Runtime.Phases;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Routing;
using Prism.Shared.Contracts.Runtime.Imports;
using Prism.Shared.Contracts.Runtime.Phases.Base;
using Prism.Shared.Contracts.Sessions.Session.Types;

namespace Prism.Shared.Contracts.Runtime.Phases
{
    public class SessionPhase : RuntimePhaseBase, IRuntimePhase
    {
        private readonly IEnvelopeValidator _validator;
        private readonly IManifestRegistryResolver _resolver;
        private readonly ICallbackDispatcher _dispatcher;
        private readonly string _contributorId;
        private readonly string _role;
        private readonly List<NpcDefinition> _npcDefinitions;

        public SessionPhase(
            IEnvelopeValidator validator,
            IManifestRegistryResolver resolver,
            ICallbackDispatcher dispatcher,
            string contributorId,
            string role,
            List<NpcDefinition> npcDefinitions)
            : base(null)
        {
            _validator = validator;
            _resolver = resolver;
            _dispatcher = dispatcher;
            _contributorId = contributorId;
            _role = role;
            _npcDefinitions = npcDefinitions;
        }

        public RuntimeSession CreatedSession { get; private set; }

        public override async Task<PrismResult> RunAsync()
        {
            CreatedSession = new RuntimeSession(
                _validator,
                _resolver,
                _dispatcher,
                _contributorId,
                _role,
                curatorRole: "Curator",
                phase: "Exploration");

            await CreatedSession.StartSessionAsync();

            CreatedSession.TraitTriggerMap = TraitTriggerImporter.BuildFromNpcDefinitions(_npcDefinitions);

            // 🧠 Route entity transformers based on phase and role
            var transformers = CuratorPhaseRouter.Route(
                entityType: PrismSelectorTypes.EntityType.ContributorFingerprint, // or whatever fits the session context
                curatorRole: _role,
                phase: CreatedSession.Phase);


            CreatedSession.EntityTransformers = transformers;

            SummaryLines.Add("🧠 Session initialized.");
            SummaryLines.Add("🧬 TraitTriggerMap hydrated from NPC definitions.");
            SummaryLines.Add($"🔀 {transformers.Count} entity transformers routed for phase '{CreatedSession.Phase}' and role '{_role}'.");

            return new PrismResult(NarrateSummary(), CreatedSession);
        }
    }

    #region SessionPhase Summary 2025.08.29
    /// <summary>
    /// SessionPhase initializes the runtime session, hydrates trait-trigger maps,
    /// and routes entity transformers based on contributor role and simulation phase.
    /// It uses CuratorPhaseRouter to select phase-specific transformation logic,
    /// enabling narratable, prefab-safe startup for Prism OS.
    /// </summary>
    /// JM ✦ Prism Architect ✦ 2025-09-01
    #endregion
}