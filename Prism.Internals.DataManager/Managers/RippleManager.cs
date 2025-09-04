using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Interfaces.Managers;

namespace Prism.Internals.DataManager.Managers;

public class RippleManager : IPrismManager
{
    public Task InitializeAsync(List<MeshProfile> profiles)
    {
        throw new NotImplementedException();
    }

    public string ManagerId { get; set; }
    public string Description { get; set; }
}