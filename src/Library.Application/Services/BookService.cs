using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Services;

// Toto je asi na špatném místě

public class BookService : IBookService
{
    private DatabaseContext _context { get; set; }

    public BookService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> GetBookWithId(int id)
    {
        Book book = await _context.Books.FirstAsync(b => b.Id == id);

        return book;
    }

    public async Task AddBook(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveBookWithId(int id)
    {
        Book? book = await GetBookWithId(id);

        if (book is null) return;

        _context.Books.Remove(book);

        await _context.SaveChangesAsync();
    }
}