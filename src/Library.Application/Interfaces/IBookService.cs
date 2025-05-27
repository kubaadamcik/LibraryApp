using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IBookService
{
    public Task<List<Book>> GetAllBooks();
    public Task<Book?> GetBookWithId(int id);
    public Task AddBook(Book book);
    public Task<string?> RemoveBookWithId(int id);
    public Task BorrowBook(int bookId);
    public Task ReturnBook(int bookId);
}