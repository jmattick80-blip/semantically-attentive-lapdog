using System.Collections.Generic;

namespace GalleryDrivers.Prism.Shared.Interfaces.Traits
{
    public interface ITraitBindable
    {
        IReadOnlyList<ITrait> DefaultTraits { get; }
        IReadOnlyList<string> SignalBindings { get; }


        void PropagateTraitBundle(IEnumerable<ITrait> traits);
    }
}