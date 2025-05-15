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

    public async Task<Book?> GetBookWithId(int id)
    {
        return await _context.Books.FindAsync(id);;
    }

    public async Task AddBook(Book book)
    {
        await _context.Books.AddAsync(book);

        Console.WriteLine("Kniha má být přidaná");

        await _context.SaveChangesAsync();
    }

    public async Task<string?> RemoveBookWithId(int id)
    {
        Book? book = await GetBookWithId(id);

        if (book is null) return "Kniha nebyla nalezena";

        _context.Books.Remove(book);

        await _context.SaveChangesAsync();

        return null;
    }
    
    public async Task BorrowBook(int bookId)
    {
        var book = await GetBookWithId(bookId);
        
        if (book is null) return;
        
        book.Count--;
        
        _context.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task ReturnBook(int bookId)
    {
        var book = await GetBookWithId(bookId);
        
        if (book is null) return;

        book.Count++;

        _context.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Book>> SearchBooks (string prompt)
    {
        List<Book> books = await _context.Books.Where(b =>
            b.Title.Contains(prompt, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(prompt, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();

        return books;
    }

    
}