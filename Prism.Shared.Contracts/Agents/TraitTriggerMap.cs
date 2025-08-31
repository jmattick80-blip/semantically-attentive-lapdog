using System.Collections.Generic;

namespace Prism.Shared.Contracts.Agents
{
    public class TraitTriggerMap
    {
        public List<TraitTrigger> Triggers { get; set; } = new  List<TraitTrigger>();
    }

    public class TraitTrigger
    {
        public string TraitName { get; set; } = string.Empty;
        public string TriggerKey { get; set; } = string.Empty;
        public string TriggerValue { get; set; } = string.Empty;
    }
}