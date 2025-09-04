using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Envelopes.Base;

namespace Prism.Shared.Contracts.Sessions.Session.Routers
{
    public class SessionTokenRouter
    {
        private readonly Dictionary<string, List<string>> _tokenToRegistryMap = new Dictionary<string, List<string>>();

        public void RegisterToken(string tokenId, params string[] registryIds)
        {
            if (!_tokenToRegistryMap.ContainsKey(tokenId))
                _tokenToRegistryMap[tokenId] = new List<string>();

            _tokenToRegistryMap[tokenId].AddRange(registryIds);
        }

        public IEnumerable<string> ResolveRegistries(string tokenId)
        {
            return _tokenToRegistryMap.TryGetValue(tokenId, out var registries)
                ? (IEnumerable<string>)registries
                : Array.Empty<string>();
        }

        public void EmitToRegistries<T>(
            string tokenId,
            Func<string, T> envelopeFactory,
            Action<string, T> registryEmitter) where T : PrismSystemEnvelopeBase
        {
            foreach (var registryId in ResolveRegistries(tokenId))
            {
                var envelope = envelopeFactory(registryId);
                registryEmitter(registryId, envelope);
            }
        }

        public void ClearTokens()
        {
            _tokenToRegistryMap.Clear();
        }
    }
}