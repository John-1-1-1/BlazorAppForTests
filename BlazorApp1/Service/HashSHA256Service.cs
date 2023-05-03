using System.Security.Cryptography;
using System.Text;

namespace BlazorApp1.Service; 

public static class HashSha256Service {
    public static string CreateSha256(string input)
    {
        using SHA256 hash = SHA256.Create();
        return Convert.ToHexString(
            hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
    }
}
