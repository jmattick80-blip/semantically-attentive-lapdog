using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prism.Shared.Contracts.Interfaces.Managers;

public interface IPrismManager
{
    Task InitializeAsync(List<MeshProfile> profiles);
    string ManagerId { get; set; }
    string Description { get; set; }
}