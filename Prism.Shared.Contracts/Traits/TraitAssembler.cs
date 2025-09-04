using System;
using System.Collections.Generic;
using Prism.Shared.Contracts.Interfaces.Traits;
using Prism.Shared.Contracts.Runtime.Imports;
using Prism.Shared.Contracts.Transformers;

namespace Prism.Shared.Contracts.Traits;

public class TraitAssembler : ITraitAssembler
{
    private readonly TransformerPipeline _pipeline;

    public TraitAssembler(TransformerPipeline pipeline) {
        _pipeline = pipeline;
    }

    public TraitMap BuildFrom(PrismIntentRequest request) {
        // Step 1: Import triggers from payload, session, overlays
        var triggers = TraitTriggerImporter.Import(request);

        // Step 2: Transform triggers into traits
        var transformedEntity = _pipeline.ModulateFromTriggers(triggers, request.Session);
        var transformedTraits = transformedEntity?.Traits ?? new List<PrismTrait>();

        // Step 3: Resolve conflicts and finalize trait map
        var traitMap = TraitResolver.Resolve(transformedTraits);

        // Step 4: Narrate emotional payload
        Console.WriteLine($"🧠 Assembled TraitMap: {traitMap.Describe()}");

        return traitMap;
    }
}