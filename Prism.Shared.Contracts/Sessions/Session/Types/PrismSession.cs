using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Shared.Contracts.Agents;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Events;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Routing;

namespace Prism.Shared.Contracts.Sessions.Session.Types
{
    public abstract class PrismSession : IPrismSession
    {
        protected readonly IEnvelopeValidator Validator;
        protected readonly IManifestRegistryResolver RegistryResolver;
        protected readonly ICallbackDispatcher CallbackDispatcher;
        protected readonly ITraitRouter TraitRouter;

        // Core session metadata
        public string SessionId { get; protected set; }
        public string SessionToken { get; protected set; }
        public DateTime Timestamp { get; protected set; }
        public string ContributorId { get; protected set; }
        public string Role { get; protected set; }
        public string ClusterId { get; protected set; }
        public string TraceId { get; protected set; }
        public bool IsRegistered { get; protected set; }

        // Contributor context
        public string CuratorRole { get; protected set; } = string.Empty;
        public List<NpcDefinition> NpcDefinitions { get; protected set; } = new();

        // Trait interface
        public string TraitId { get; protected set; }
        public string TraitName { get; protected set; }
        public string Description { get; protected set; }
        public bool IsActive { get; protected set; }

        // Emotional mesh context
        public string MoodVector { get; protected set; } = "neutral";
        public Dictionary<string, float>? LayerWeights { get; protected set; }
        public Dictionary<string, string>? ToneTags { get; protected set; }
        public List<string>? Tags { get; protected set; }
        public List<RippleEvent>? RippleHistory { get; set; }

        // Breadcrumbs
        private readonly List<string> _breadcrumbs = new();
        public IEnumerable<string> Breadcrumbs => _breadcrumbs;

        protected PrismSession(
            IEnvelopeValidator validator,
            IManifestRegistryResolver registryResolver,
            ICallbackDispatcher callbackDispatcher,
            ITraitRouter traitRouter,
            string contributorId,
            string role,
            List<NpcDefinition> npcDefinitions)
        {
            Validator = validator;
            RegistryResolver = registryResolver;
            CallbackDispatcher = callbackDispatcher;
            TraitRouter = traitRouter;
            ContributorId = contributorId;
            Role = role;
            NpcDefinitions = npcDefinitions ?? new();
        }

        // 🔄 Session Lifecycle
        public virtual async Task StartSessionAsync()
        {
            Activate();
            Timestamp = DateTime.UtcNow;
            SessionToken = GenerateSessionToken();
            Register();

            _breadcrumbs.Add($"🧠 Session started at {Timestamp:O} with token {SessionToken}");
            _breadcrumbs.Add($"📦 NPCs loaded: {NpcDefinitions.Count}");

            await Task.CompletedTask;
        }

        public virtual async Task EndSessionAsync()
        {
            Deactivate();
            Unregister();
            _breadcrumbs.Add($"🛑 Session ended at {DateTime.UtcNow:O}");
            await Task.CompletedTask;
        }

        // 🔗 Cluster Binding
        public virtual void BindToCluster(string clusterId)
        {
            ClusterId = clusterId;
            _breadcrumbs.Add($"🔗 Bound to cluster {clusterId} at {DateTime.UtcNow:O}");
        }

        // 📝 Registration
        public virtual void Register()
        {
            IsRegistered = true;
            _breadcrumbs.Add("✅ Session registered");
        }

        public virtual void Unregister()
        {
            IsRegistered = false;
            _breadcrumbs.Add("❎ Session unregistered");
        }

        // 📦 Envelope Handling
        public void OnIntentEnvelopeCreated(IntentEnvelope envelope)
        {
            if (envelope == null)
            {
                Console.WriteLine("⚠️ Envelope is null during emotional routing.");
                return;
            }

            Console.WriteLine($"📨 Envelope received with IntentId: {envelope.IntentId}");
            Console.WriteLine($"🧬 Trait count: {envelope.Traits?.Count() ?? 0}");

            if (!Validator.Validate(envelope))
            {
                _breadcrumbs.Add($"❌ Envelope validation failed: {envelope.DisplayName}");
                return;
            }

            var registry = RegistryResolver?.Resolve<IIntentManifest>(envelope);
            if (registry == null)
            {
                Console.WriteLine("❌ RegistryResolver returned null.");
                _breadcrumbs.Add($"❌ Registry resolution failed for intent: {envelope.IntentId}");
                return;
            }

            var manifest = registry.GetManifestById(envelope.IntentId);
            if (manifest == null)
            {
                Console.WriteLine($"❌ Manifest not found for intentId: {envelope.IntentId}");
                _breadcrumbs.Add($"❌ Manifest not found: {envelope.IntentId}");
                return;
            }

            // 🧠 Route traits through centralized TraitRouter
            if (envelope.Traits?.Any() == true)
            {
                TraitRouter.Route(envelope.Traits, manifest, BuildMeshProfile(envelope.Traits));
                Console.WriteLine($"🧬 Traits routed via TraitRouter to manifest: {manifest.DisplayName}");
            }
            else
            {
                Console.WriteLine("⚠️ No traits found to route.");
            }

            var narration = manifest.GetNarrationHint(envelope.IntentId);
            var result = ResultsEnvelope.Success(
                narration,
                envelope.Traits,
                manifest,
                GetSessionContext(),
                envelope.PayloadPackage
            );

            CallbackDispatcher?.Dispatch(result);
            _breadcrumbs.Add($"📨 Envelope processed: {envelope.DisplayName} → {manifest.DisplayName}");
        }

        // 🧬 Trait Interface
        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;

        public void Modulate(TraitModulationContext traitModulationContext)
        {
            throw new NotImplementedException();
        }

        // 🔐 Session Token Generator
        protected virtual string GenerateSessionToken()
        {
            var guidFragment = Guid.NewGuid().ToString("N").Substring(0, 8);
            var timeHash = Timestamp.ToString("yyyyMMddHHmmss");
            return $"{guidFragment}-{timeHash}";
        }

        // 🧾 Session Context Builder
        protected virtual ISessionContext GetSessionContext()
        {
            return new SessionContext
            {
                SessionId = SessionId,
                ContributorId = ContributorId,
                CuratorRole = CuratorRole,
                CreatedAt = Timestamp,
                GalleryId = ClusterId,
                GallerySeedNumber = 0,
                MeshSnapshotId = string.Empty,
                Status = IsActive ? "Active" : "Inactive",
                TraitTriggerMap = new Dictionary<string, string>()
            };
        }

        // 🧬 MeshProfile Builder for Trait Routing
        protected virtual MeshProfile BuildMeshProfile(IEnumerable<ITrait> traits)
        {
            var concreteTraits = traits
                .OfType<PrismTrait>()
                .ToList();

            return new MeshProfile
            {
                ContributorId = ContributorId,
                IntentType = Role,
                MoodVector = MoodVector ?? "neutral",
                Timestamp = DateTime.UtcNow,
                ClusterId = ClusterId ?? "unclustered",
                Tags = Tags ?? new List<string>(),
                ToneTags = ToneTags ?? new Dictionary<string, string>(),
                LayerWeights = LayerWeights ?? new Dictionary<string, float>(),
                RippleHistory = RippleHistory ?? new List<RippleEvent>(),
                Traits = concreteTraits
            };
        }
    }
}