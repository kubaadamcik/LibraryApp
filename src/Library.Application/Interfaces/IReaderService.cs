using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IReaderService
{
    public event Func<Task> ContextChanged;
    public Task<Reader> GetUserWithId(int id);
    public Task<Reader> GetUserWithName(string name);
    public Task<bool> AddReader(Reader reader);
    public Task<List<Reader>> GetAllReaders();
    public Task RemoveReader(Reader reader);

}