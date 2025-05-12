namespace Library.Application.Interfaces;

public interface IPasswordHasher
{
    public Task<string> HashPassword(string password);
    public bool VerifyPassword(string password, string salt, string hashedPassword);
}