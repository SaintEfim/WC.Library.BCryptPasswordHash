namespace WC.Library.BCryptPasswordHash;

public interface IBCryptPasswordHasher
{
    public string Hash(string data);
    public bool Verify(string data, string hashedData);
}