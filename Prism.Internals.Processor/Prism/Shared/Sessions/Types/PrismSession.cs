using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryDrivers.Prism.Shared.Envelopes.Base;
using GalleryDrivers.Prism.Shared.Envelopes.Types;
using GalleryDrivers.Prism.Shared.Interfaces.Manifests;
using GalleryDrivers.Prism.Shared.Interfaces.Session;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;

namespace GalleryDrivers.Prism.Shared.Sessions.Types
{
    public abstract class PrismSession : IPrismSession, ITraceable, IClusterBindable, ISessionRegisterable
    {
        protected readonly IEnvelopeValidator Validator;
        protected readonly IManifestRegistryRouter RegistryRouter;
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

        protected PrismSession(
            IEnvelopeValidator validator,
            IManifestRegistryRouter registryRouter,
            ICallbackDispatcher callbackDispatcher, string contributorId, string role)
        {
            Validator = validator;
            RegistryRouter = registryRouter;
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
            if (!Validator.Validate(envelope))
            {
                _breadcrumbs.Add($"❌ Envelope validation failed: {envelope.DisplayName}");
                return;
            }

            var registry = RegistryRouter.Resolve<IIntentManifest>(envelope);
            var manifest = registry.GetManifestById(envelope.IntentId);

            manifest.PropagateTraitBundle(envelope.Traits);

            var narration = manifest.GetNarrationHint(envelope.IntentId);
            var result = ResultsEnvelope.Success(narration, envelope.Traits);

            CallbackDispatcher.Dispatch(result);
            _breadcrumbs.Add($"📨 Envelope processed: {envelope.DisplayName} → {manifest.DisplayName}");
        }

        // 🧬 Trait Interface
        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;

        // 🔐 Session Token Generator
        protected virtual string GenerateSessionToken()
        {
            var guidFragment = Guid.NewGuid().ToString("N").Substring(0, 8);
            var timeHash = Timestamp.ToString("yyyyMMddHHmmss");
            return $"{guidFragment}-{timeHash}";

        }
    }
}