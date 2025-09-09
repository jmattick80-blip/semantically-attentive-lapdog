using System.Collections.Generic;
using Prism.Shared.Contracts.Events;

namespace Prism.Shared.Contracts;

public class SessionLaunchPayload
{
    public string SessionId { get; set; }
    public string SessionToken { get; set; }
    public string ContributorId { get; set; }
    public string Role { get; set; }
    public Dictionary<string, string> ToneTags { get; set; }
    public Dictionary<string, double> LayerWeights { get; set; }
    public List<RippleEvent> RippleHistory { get; set; }
    public string[] Tags { get; set; }
    public string Description { get; set; }
    public string MoodVector { get; set; }
    public List<string> Breadcrumbs { get; set; }
}