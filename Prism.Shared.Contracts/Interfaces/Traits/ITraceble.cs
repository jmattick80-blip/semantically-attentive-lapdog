namespace Prism.Shared.Contracts.Interfaces.Traits
{
    public interface ITrait
    {
        string TraitId { get; }
        string TraitName { get; }
        string Description { get; }
        bool IsActive { get; }
        void Activate();
        void Deactivate();
        void Modulate(TraitModulationContext traitModulationContext);
    }
    
    public interface ITraceable : ITrait
    {
        
    }

    public interface IClusterBindable: ITrait
    {
        string ClusterId { get; }
        void BindToCluster(string clusterId);
    }

    public interface ISessionRegisterable: ITrait
    {
        void Register();
        void Unregister();
        bool IsRegistered { get; }
    }
}