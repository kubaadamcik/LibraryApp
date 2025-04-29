using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IReaderService
{
    public Task<User> GetUserWithId(int id);
    public Task<User> GetUserWithName(string name);
    public Task AddReader(User user);
    public Task<List<User>> GetAllReaders();
    public Task RemoveReader(User user);
}