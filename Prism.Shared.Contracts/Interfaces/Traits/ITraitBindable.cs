using System.Collections.Generic;

namespace Prism.Shared.Contracts.Interfaces.Traits
{
    public interface ITraitBindable
    {
        IReadOnlyList<ITrait> DefaultTraits { get; }
        IReadOnlyList<string> SignalBindings { get; }


        void PropagateTraitBundle(IEnumerable<ITrait> traits);
    }
}