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
        private readonly ITraitRouter _traitRouter;

        public SessionDependencyResolver(
            IEnvelopeValidatorRegistry validatorRegistry,
            IManifestRouterFactory routerFactory,
            ICallbackDispatcherPool dispatcherPool,
            ITraitRouter traitRouter,
            INpcFactory npcFactory)
        {
            _validatorRegistry = validatorRegistry;
            _routerFactory = routerFactory;
            _dispatcherPool = dispatcherPool;
            _npcFactory = npcFactory;
            _traitRouter = traitRouter;
        }

        public IEnvelopeValidator ResolveValidator(SessionContext context)
        {
            return _validatorRegistry.GetForContext(context.GalleryId);
        }

        public IManifestFlowRouter ResolveRouter(SessionContext context)
        {
            return _routerFactory.Create();
        }
        
        public IManifestRegistryResolver ResolveRegistryResolver(SessionContext context)
        {
            var factory = new ManifestRegistryResolverFactory(_traitRouter);
            return factory.Create("assembly");
        }



        public ICallbackDispatcher ResolveDispatcher(SessionContext context)
        {
            return _dispatcherPool.Get(context.ContributorId);
        }

        public List<NpcDefinition> ResolveNpcDefinitions(SessionContext context)
        {
            return _npcFactory.BuildFromSeed(context.GallerySeedNumber, context);
        }

        public ITraitRouter ResolveTraitRouter(SessionContext context)
        {
            return _traitRouter;
        }
    }
}