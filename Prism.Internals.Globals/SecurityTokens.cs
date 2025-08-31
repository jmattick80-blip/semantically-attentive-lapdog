namespace Prism.Internals.Globals;

public static class SecurityTokens
{
    private static readonly Dictionary<string, string> _tokenRegistry = new();

    public static bool ValidateToken(string token)
    {
        return !string.IsNullOrEmpty(token) && _tokenRegistry.ContainsKey(token);
    }

    public static string GenerateToken(string adapterId)
    {
        var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        _tokenRegistry[token] = adapterId;
        return token;
    }
}