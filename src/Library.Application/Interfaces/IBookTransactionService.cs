using System.Collections.ObjectModel;
using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IBookTransactionService
{
    public Task<BookTransaction> CreateTransaction(int bookId, int readerId);
    public Task<int> CountReaderBorrowedBooks(int readerId);
    public Task<List<Book>> GetReaderBorrowedBooks(int readerId);
    public Task<int> CountBorrowedBooks(int bookId);
    public Task MarkAsReturned(int bookId, int readerId);
}