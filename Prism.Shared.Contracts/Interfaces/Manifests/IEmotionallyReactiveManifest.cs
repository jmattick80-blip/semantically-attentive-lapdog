using System.Collections.Generic;

namespace Prism.Shared.Contracts.Interfaces.Manifests;

public interface IEmotionallyReactiveManifest : IManifest
{
    List<string> Traits { get; set; }
    List<string> Overlays { get; set; }
    Dictionary<string, float> MoodVector { get; set; }
}