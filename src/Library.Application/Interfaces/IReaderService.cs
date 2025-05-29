using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IReaderService
{
    public Task<Reader> GetReaderWithId(int id);
    public Task<Reader> GetReaderWithName(string name);
    public Task<bool> AddReader(Reader reader);
    public Task<List<Reader>> GetAllReaders();
    public Task RemoveReader(Reader reader);

}