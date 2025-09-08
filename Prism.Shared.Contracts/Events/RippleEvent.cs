using System;

namespace Prism.Shared.Contracts.Events
{
    public class RippleEvent
    {
        public string SourceContributorId { get; set; }
        public string RippleType { get; set; }
        public DateTime EmittedAt { get; set; }
    }

    #region RippleEvent Summary

    //🔍 Observation
    //RippleEvent is a lightweight data contract representing contributor-triggered ripple
    //emissions. It includes contributor ID, ripple type, and timestamp. Structurally sound
    //and prefab-safe, but currently lacks integration into emotional mesh logging or replay systems.
    #endregion
    
}


