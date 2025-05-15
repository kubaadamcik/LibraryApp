using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class LibraryService(Reader reader) : ILibraryService
{
    // TODO: Implement these methods
    public Task<bool> BorrowBook(int bookId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ReturnBook(int bookId)
    {
        throw new NotImplementedException();
    }
}