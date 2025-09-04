using System.Text.Json;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Providers;

namespace Prism.Internals.DataManager.Adapters;

public class SignalMeshAdapter : IMeshProfileProvider
{
    private readonly string _signalEndpoint;
    private readonly HttpClient _http;

    public SignalMeshAdapter(string configSource)
    {
        _signalEndpoint = configSource ?? throw new ArgumentNullException(nameof(configSource));
        _http = new HttpClient(); // Optionally inject this for testability
    }

    public async Task<IEnumerable<MeshProfile>> GetProfilesAsync()
    {
        try
        {
            var response = await _http.GetAsync(_signalEndpoint);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"⚠️ SignalMeshAdapter: Failed to fetch from {_signalEndpoint} ({response.StatusCode})");
                return Enumerable.Empty<MeshProfile>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var profiles = JsonSerializer.Deserialize<List<MeshProfile>>(json);

            Console.WriteLine($"📡 SignalMeshAdapter: Received {profiles?.Count ?? 0} profiles from {_signalEndpoint}");
            return profiles ?? Enumerable.Empty<MeshProfile>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ SignalMeshAdapter: Error fetching {_signalEndpoint}: {ex.Message}");
            return Enumerable.Empty<MeshProfile>();
        }
    }
}