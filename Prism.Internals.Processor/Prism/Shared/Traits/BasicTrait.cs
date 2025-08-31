using GalleryDrivers.Prism.Shared.Interfaces.Traits;

namespace GalleryDrivers.Prism.Shared.Traits
{
    public class BasicTrait : ITrait
    {
        public string TraitId { get; }
        public string TraitName { get; }
        public string Description { get; }
        public bool IsActive { get; private set; }

        public BasicTrait(string traitId, string traitName, string description)
        {
            TraitId = traitId;
            TraitName = traitName;
            Description = description;
            IsActive = false;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}