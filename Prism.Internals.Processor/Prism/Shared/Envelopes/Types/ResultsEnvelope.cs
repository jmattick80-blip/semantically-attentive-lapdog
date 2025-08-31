using System.Collections.Generic;
using GalleryDrivers.Prism.Shared.Interfaces.Envelopes;
using GalleryDrivers.Prism.Shared.Interfaces.Traits;

namespace GalleryDrivers.Prism.Shared.Envelopes.Types
{
    public class ResultsEnvelope : IEnvelopeResults
    {
        public string Narration { get; }
        public IEnumerable<ITrait> Traits { get; }

        private ResultsEnvelope(string narration, IEnumerable<ITrait> traits)
        {
            Narration = narration;
            Traits = traits;
        }

        public static ResultsEnvelope Success(string narration, IEnumerable<ITrait> traits)
        {
            return new ResultsEnvelope(narration, traits);
        }
    }
}