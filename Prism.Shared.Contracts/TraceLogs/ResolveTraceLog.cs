using System.Collections.Generic;
using Prism.Shared.Contracts.MoodProfiles;

namespace Prism.Shared.Contracts.TraceLogs
{
    public class ResolveTraceLog
    {
        public string EntityId;
        public string EntityType;
        public MoodProfile MoodProfile;
        public List<string> AppliedTraits;
        public List<string> IgnoredModifiers;
        public bool FallbackTriggered;
        public string NarrationSummary;
    }
}