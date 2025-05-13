using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Services;

public class ReaderService(DatabaseContext context) : IReaderService
{
    public event Func<Task> ContextChanged;

    public async Task<Reader> GetUserWithId(int id)
    {
        return await context.Readers.FirstAsync(user => user.Id == id);
    }

    public async Task<Reader> GetUserWithName(string name)
    {
        return await context.Readers.FirstAsync(user => user.FullName == name);
    }

    public async Task RemoveReader(Reader reader)
    {
        context.Readers.Remove(reader);

        await context.SaveChangesAsync();

        ContextChanged.Invoke();
    }

    public async Task<List<Reader>> GetAllReaders()
    {
        return await context.Readers.Include(r => r.ReaderInfo).ToListAsync();
    }

    public async Task<bool> AddReader(Reader reader)
    {
        if (await context.Readers.AnyAsync(r => r.Email == reader.Email)) return false;

        await context.Readers.AddAsync(reader);

        await context.SaveChangesAsync();

        ContextChanged.Invoke();

        return true;
    }
}