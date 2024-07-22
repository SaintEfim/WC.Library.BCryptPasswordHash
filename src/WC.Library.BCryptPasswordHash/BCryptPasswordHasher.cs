using Microsoft.Extensions.Logging;

namespace WC.Library.BCryptPasswordHash;

public class BCryptPasswordHasher : IBCryptPasswordHasher
{
    private readonly ILogger<BCryptPasswordHasher> _logger;

    public BCryptPasswordHasher(
        ILogger<BCryptPasswordHasher> logger)
    {
        _logger = logger;
    }

    public string Hash(
        string data)
    {
        if (!string.IsNullOrEmpty(data))
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(data, 12);
        }

        _logger.LogError("Parameter must not be null or empty.");
        throw new ArgumentException("Data must not be null or empty.", nameof(data));
    }

    public bool Verify(
        string data,
        string hashedData)
    {
        if (string.IsNullOrEmpty(data))
        {
            throw new ArgumentException("Data must not be null or empty.", nameof(data));
        }

        if (string.IsNullOrEmpty(hashedData))
        {
            throw new ArgumentException("Hashed data must not be null or empty.", nameof(hashedData));
        }

        try
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(data, hashedData);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error verifying hashed data.");
            throw;
        }
    }
}
