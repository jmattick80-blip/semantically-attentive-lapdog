using System;

namespace Prism.Shared.Contracts.Events;

public class RippleEvent
{
    public string SourceContributorId { get; set; }
    public string RippleType { get; set; }
    public DateTime EmittedAt { get; set; }
}
