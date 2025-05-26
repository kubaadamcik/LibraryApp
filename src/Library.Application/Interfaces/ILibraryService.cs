using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface ILibraryService
{
    public Task<bool> BorrowBook(int bookId, int readerId);
    public Task<bool> ReturnBook(int bookId, int readerId);
}