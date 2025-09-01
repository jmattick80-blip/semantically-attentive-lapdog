using System.Collections.Generic;
using PrismSelectorTypes = Prism.Shared.Contracts.Enums.PrismSelectorTypes;

namespace Prism.Shared.Contracts.MoodProfiles
{
    public class MoodProfile
    {
        public PrismSelectorTypes.MoodSourceType MoodSourceType { get; set; }
        public List<PrismSelectorTypes.MoodModifier> Modifiers;
        public PrismSelectorTypes.MoodIntensity Intensity { get; set; }
        public float IntensityValue { get; set; }
        public PrismSelectorTypes.MoodDuration Duration { get; set; }
        public float DurationValue { get; set; }
        
        public MoodProfile(
            PrismSelectorTypes.MoodSourceType sourceType = PrismSelectorTypes.MoodSourceType.Unknown,
            List<PrismSelectorTypes.MoodModifier> modifiers = null,
            PrismSelectorTypes.MoodIntensity intensity = PrismSelectorTypes.MoodIntensity.Medium,
            float intensityValue = 0.5f,
            PrismSelectorTypes.MoodDuration duration = PrismSelectorTypes.MoodDuration.Transient,
            float durationValue = 0.5f)
        {
            MoodSourceType = sourceType;
            Modifiers = modifiers ?? new List<PrismSelectorTypes.MoodModifier>();
            Intensity = intensity;
            IntensityValue = intensityValue;
            Duration = duration;
            DurationValue = durationValue;
        }
    }
}