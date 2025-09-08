using System.Collections.Generic;
using Prism.Shared.Contracts.Agents;
using Prism.Shared.Contracts.Interfaces.Routers;
using Prism.Shared.Contracts.Interfaces.Sessions;
using Prism.Shared.Contracts.Manifests.Factories;

namespace Prism.Shared.Contracts.Sessions.Session.Services
{
    public class SessionDependencyResolver : ISessionDependencyResolver
    {
        private readonly IEnvelopeValidatorRegistry _validatorRegistry;
        private readonly IManifestRouterFactory _routerFactory;
        private readonly ICallbackDispatcherPool _dispatcherPool;
        private readonly INpcFactory _npcFactory;

        public SessionDependencyResolver(
            IEnvelopeValidatorRegistry validatorRegistry,
            IManifestRouterFactory routerFactory,
            ICallbackDispatcherPool dispatcherPool,
            INpcFactory npcFactory)
        {
            _validatorRegistry = validatorRegistry;
            _routerFactory = routerFactory;
            _dispatcherPool = dispatcherPool;
            _npcFactory = npcFactory;
        }

        public IEnvelopeValidator ResolveValidator(SessionContext context)
        {
            return _validatorRegistry.GetForContext(context.GalleryId);
        }

        public IManifestFlowRouter ResolveRouter(SessionContext context)
        {
            return _routerFactory.Create(context.CuratorPhase);
        }
        
        public IManifestRegistryResolver ResolveRegistryResolver(SessionContext context)
        {
            return new ManifestRegistryResolverFactory().Create(context.CuratorPhase);
        }


        public ICallbackDispatcher ResolveDispatcher(SessionContext context)
        {
            return _dispatcherPool.Get(context.ContributorId);
        }

        public List<NpcDefinition> ResolveNpcDefinitions(SessionContext context)
        {
            return _npcFactory.BuildFromSeed(context.GallerySeedNumber);
        }
    }
}