using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface ILibraryService
{
    public Task<bool> BorrowBook(int bookId);
    public Task<bool> ReturnBook(int bookId);
}