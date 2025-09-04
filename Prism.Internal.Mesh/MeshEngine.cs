using Prism.Shared.Contracts;

namespace Prism.Internal.Mesh;

public static class MeshEngine
{
    // Simulates emotional propagation across mesh layers
    public static Dictionary<string, float> Propagate(
        string exhibitId,
        Dictionary<string, float> moodDelta,
        SessionContext session)
    {
        if (string.IsNullOrWhiteSpace(exhibitId))
            return new Dictionary<string, float>();

        var contributorId = session.ContributorId;
        var profile = session.MeshProfile;

        if (profile == null)
        {
            Console.WriteLine($"⚠️ MeshEngine: No profile found for contributor '{contributorId}'");
            return moodDelta;
        }

        var result = new Dictionary<string, float>();

        foreach (var layer in moodDelta.Keys)
        {
            var delta = moodDelta[layer];
            var weight = profile.LayerWeights?.GetValueOrDefault(layer) ?? 1.0f;

            var modulated = delta * weight;
            result[layer] = modulated;

            Console.WriteLine($"🌐 MeshEngine: Layer '{layer}' delta {delta:F2} × weight {weight:F2} → {modulated:F2}");
        }

        Console.WriteLine($"🧠 MeshEngine: Propagation complete for '{exhibitId}' ({contributorId})");
        return result;
    }
}