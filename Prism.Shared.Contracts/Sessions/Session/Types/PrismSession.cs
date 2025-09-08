using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Shared.Contracts.Envelopes;
using Prism.Shared.Contracts.Envelopes.Types;
using Prism.Shared.Contracts.Interfaces.Manifests;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Traits;

namespace Prism.Shared.Contracts.Sessions.Session.Types
{
    public abstract class PrismSession : IPrismSession, ITraceable, IClusterBindable, ISessionRegisterable
    {
        protected readonly IEnvelopeValidator Validator;
        protected readonly IManifestRegistryResolver RegistryResolver;
        protected readonly ICallbackDispatcher CallbackDispatcher;

        public string SessionId { get; protected set; }
        public string SessionToken { get; protected set; }
        public DateTime Timestamp { get; protected set; }
        public string ContributorId { get; protected set; }
        public string Role { get; protected set; }

        public string TraceId { get; protected set; }
        public IEnumerable<string> Breadcrumbs => _breadcrumbs;
        private readonly List<string> _breadcrumbs = new List<string>();

        public string ClusterId { get; protected set; }
        public bool IsRegistered { get; protected set; }

        // Trait interface backing
        public string TraitId { get; protected set; }
        public string TraitName { get; protected set; }
        public string Description { get; protected set; }
        public bool IsActive { get; protected set; }
        
        /// <summary>
        /// Trait-trigger mappings hydrated from external agent definitions.
        /// Used for emotional mesh routing, scenario consequence, and transformation logic.
        /// </summary>
        public Dictionary<string, List<string>> TraitTriggerMap { get; set; } = new();

        /// <summary>
        /// Contributor-assigned curator role (e.g. "Archivist", "Designer").
        /// Used for transformer resolution and scenario consequence.
        /// </summary>
        public string CuratorRole { get; protected set; } = string.Empty;

        /// <summary>
        /// Current phase of the session (e.g. "Annotation", "LivePlay").
        /// Used for phase-sensitive routing and emotional mesh propagation.
        /// </summary>
        public string Phase { get; protected set; } = string.Empty;

        
        protected PrismSession(
            IEnvelopeValidator validator,
            IManifestRegistryResolver registryResolver,
            ICallbackDispatcher callbackDispatcher, string contributorId, string role)
        {
            Validator = validator;
            RegistryResolver = registryResolver;
            CallbackDispatcher = callbackDispatcher;
            ContributorId = contributorId;
            Role = role;
        }

        // 🔄 Async Lifecycle
        public virtual Task StartSessionAsync()
        {
            Activate();
            Timestamp = DateTime.UtcNow;
            SessionToken = GenerateSessionToken();
            Register();

            _breadcrumbs.Add($"🧠 Session started at {Timestamp:O} with token {SessionToken}");
            _breadcrumbs.Add($"🧬 TraitTriggerMap initialized with {TraitTriggerMap.Count} entries.");
            return Task.CompletedTask;
        }


        public virtual Task EndSessionAsync()
        {
            Deactivate();
            Unregister();

            _breadcrumbs.Add($"🛑 Session ended at {DateTime.UtcNow:O}");
            return Task.CompletedTask;
        }


        // 🔗 Cluster Binding
        public virtual void BindToCluster(string clusterId)
        {
            ClusterId = clusterId;
            _breadcrumbs.Add($"🔗 Bound to cluster {clusterId} at {DateTime.UtcNow:O}");
        }

        // 📝 Registration Lifecycle
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

            if (envelope.Traits != null && envelope.Traits.Any())
            {
                manifest.PropagateTraitBundle(envelope.Traits);
                Console.WriteLine($"🧬 Traits propagated to manifest: {manifest.DisplayName}");
            }
            else
            {
                Console.WriteLine("⚠️ No traits found to propagate.");
            }

            var narration = manifest.GetNarrationHint(envelope.IntentId);
            var result = ResultsEnvelope.Success(
                narration,
                envelope.Traits,
                manifest,
                GetSessionContext(),
                envelope.PayloadPackage // or null if not available
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
        
        protected virtual ISessionContext GetSessionContext()
        {
            var flattenedMap = TraitTriggerMap.ToDictionary(
                kvp => kvp.Key,
                kvp => string.Join(", ", kvp.Value)
            );

            
            return new SessionContext
            {
                SessionId = SessionId,
                ContributorId = ContributorId,
                CuratorRole = CuratorRole,
                Phase = Phase,
                CreatedAt = Timestamp,
                GalleryId = ClusterId, // assuming ClusterId maps to GalleryId contextually
                GallerySeedNumber = 0, // stubbed; replace with actual seed if available
                MeshSnapshotId = string.Empty, // stubbed; populate if mesh tracking is active
                Status = IsActive ? "Active" : "Inactive",
                TraitTriggerMap = flattenedMap
            };
        }
    }
}