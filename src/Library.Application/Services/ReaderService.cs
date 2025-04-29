using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class ReaderService : IReaderService
{
    public async Task<User> GetUserWithId(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserWithName(string name)
    {
        throw new NotImplementedException();
    }

    public Task RemoveReader(User user)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllReaders()
    {
        throw new NotImplementedException();
    }

    public Task AddReader(User user)
    {
        throw new NotImplementedException();
    }
}