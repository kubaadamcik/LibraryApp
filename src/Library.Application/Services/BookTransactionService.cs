using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence;

namespace Library.Application.Services;

public class BookTransactionService(DatabaseContext context, IBookService bookService, IReaderService readerService)
    : IBookTransactionService
{
    public async Task<BookTransaction> CreateTransaction(int bookId, int readerId)
    {
        BookTransaction bookTransaction = new BookTransaction()
        {
            Book = await bookService.GetBookWithId(bookId), BookId = bookId,
            Reader = await readerService.GetUserWithId(readerId), ReaderId = readerId
        };

        await context.BookTransactions.AddAsync(bookTransaction);

        await context.SaveChangesAsync();

        return bookTransaction;
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