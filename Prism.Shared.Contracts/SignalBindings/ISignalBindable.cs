using System.Collections.Generic;

namespace Prism.Shared.Contracts.SignalBindings;

public interface ISignalBindable
{
    IEnumerable<string> GetSignalBindings();
}
