using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prism.Shared.Contracts.Interfaces.Providers;

public interface IMeshProfileProvider
{
    Task<IEnumerable<MeshProfile>> GetProfilesAsync();
}