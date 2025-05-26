using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Services;

public class BookTransactionService(DatabaseContext context, IBookService bookService, IReaderService readerService)
    : IBookTransactionService
{
    public async Task<BookTransaction> CreateTransaction(int bookId, int readerId)
    {
        var book = await bookService.GetBookWithId(bookId);
        var reader = await readerService.GetUserWithId(readerId);

        var bookTransaction = new BookTransaction
        {
            BookId = bookId,
            ReaderId = readerId
        };

        await context.BookTransactions.AddAsync(bookTransaction);
        await context.SaveChangesAsync();

        return bookTransaction;
    }

    public async Task<int> CountReaderBorrowedBooks(int readerId)
    {
        var transactions =  context.BookTransactions.Where(t => t.ReaderId == readerId);

        return await transactions.CountAsync();
    }

    public async Task<int> CountBorrowedBooks(int bookId)
    {
        var transactions = context.BookTransactions.Where(t => t.BookId == bookId);

        return await transactions.CountAsync();
    }

    public async Task MarkAsReturned(int readerId, int bookId)
    {
        BookTransaction bookTransaction = await context.BookTransactions.FirstAsync(t => t.ReaderId == readerId && t.BookId == bookId);

        bookTransaction.Return();
    }
}