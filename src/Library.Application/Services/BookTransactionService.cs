using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence;

namespace Library.Application.Services;

public class BookTransactionService(DatabaseContext context) : IBookTransactionService
{
    public Task<BookTransaction> CreateTransaction(int bookId, int readerId)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountReaderBorrowedBooks(int readerId)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountBorrowedBooks(int bookId)
    {
        throw new NotImplementedException();
    }

    public Task MarkAsReturned(int readerId, int bookId)
    {
        throw new NotImplementedException();
    }
}