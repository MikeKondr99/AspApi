using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.ComponentModel.DataAnnotations;
using AspApi.Controllers;

namespace AspApi.Database;

public record class User : IHasKey<Guid> {

    // TODO FIX: Почему этот метод тут вообще
    public static string HashString(string password,byte[] salt)
    {
        // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        return hashed;
    }

    public static byte[] GenSalt()
    {
        // cryptographically strong random bytes.
        return RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
    }


    [Key]
    public Guid Id { get; set; } = Guid.Empty;

    public string Username { get; set; } = "";

    public string Password { get; set; } = ""; // for debug

    public string PasswordHash { get; set; } = "";

    public byte[] Salt { get; set; } = new byte[0];

    public string? FirstName { get; set; } = null;

    public string? LastName { get; set; } = null;
}