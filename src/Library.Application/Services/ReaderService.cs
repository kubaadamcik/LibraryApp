using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Services;

public class ReaderService(DatabaseContext context) : IReaderService
{
    public event Func<Task> ContextChanged;

    public async Task<User> GetUserWithId(int id)
    {
        return await context.Readers.FirstAsync(user => user.Id == id);
    }

    public async Task<User> GetUserWithName(string name)
    {
        return await context.Readers.FirstAsync(user => user.FullName == name);
    }

    public async Task RemoveReader(User user)
    {
        context.Readers.Remove(user);

        await context.SaveChangesAsync();

        ContextChanged.Invoke();
    }

    public async Task BorrowBook()
    {
        throw new NotImplementedException();
    }

    public async Task ReturnBook()
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetAllReaders()
    {
        return await context.Readers.Include(r => r.ReaderInfo).ToListAsync();
    }

    public async Task<bool> AddReader(User user)
    {
        if (await context.Readers.AnyAsync(r => r.Email == user.Email)) return false;

        await context.Readers.AddAsync(user);

        await context.SaveChangesAsync();

        ContextChanged.Invoke();

        return true;
    }
}