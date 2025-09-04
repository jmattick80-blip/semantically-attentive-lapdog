using Prism.Shared.Contracts.Interfaces.Traits;

namespace Prism.Shared.Contracts.Interfaces.Traits.Base
{
    public abstract class PrismTraitBase : ITrait
    {
        public string TraitId { get; }
        public string TraitName { get; }
        public string Description { get; }
        public bool IsActive { get; private set; }

        protected PrismTraitBase(string traitId, string traitName, string description)
        {
            TraitId = traitId;
            TraitName = traitName;
            Description = description;
            IsActive = false;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
        
        public virtual void Modulate(TraitModulationContext traitModulationContext)
        {
            // No-op by default. Subclasses may override for emotional consequence.
        }
    }
}