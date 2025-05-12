using Library.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Library.Application.Services;

public class PasswordHasher : IPasswordHasher
{
    public async Task<string> HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            string input = password;

        }


        throw new NotImplementedException();
    }

    public bool VerifyPassword(string password, string salt, string hashedPassword)
    {
        throw new NotImplementedException();
    }
}