using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Services;

public class ReaderService : IReaderService
{
    private readonly DatabaseContext _context;
    
    public ReaderService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<User> GetUserWithId(int id)
    {
        return await _context.Readers.FirstAsync(user => user.Id == id);
    }

    public async Task<User> GetUserWithName(string name)
    {
        return await _context.Readers.FirstAsync(user => user.FullName == name);
    }

    public async Task RemoveReader(User user)
    {
        _context.Remove(user);

        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllReaders()
    {
        return await _context.Readers.ToListAsync();
    }

    public async Task AddReader(User user)
    {
        await _context.Readers.AddAsync(user);
    }
}