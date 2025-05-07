using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IReaderService
{
    public event Func<Task> ContextChanged;
    public Task<User> GetUserWithId(int id);
    public Task<User> GetUserWithName(string name);
    public Task<bool> AddReader(User user);
    public Task<List<User>> GetAllReaders();
    public Task RemoveReader(User user);
    public Task BorrowBook();
    public Task ReturnBook();
}