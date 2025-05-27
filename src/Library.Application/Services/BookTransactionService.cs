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
        var reader = await readerService.GetReaderWithId(readerId);

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

    public async Task<List<Book>> GetReaderBorrowedBooks(int readerId)
    {
        var transactions = context.BookTransactions.Where(t => t.ReaderId == readerId);

        List<Book> books = null;

        foreach (var transaction in transactions)
        {
            books.Add(await bookService.GetBookWithId(transaction.BookId));
        }

        return books;
    }

    public async Task<int> CountBorrowedBooks(int bookId)
    {
        var transactions = context.BookTransactions.Where(t => t.BookId == bookId);

        return await transactions.CountAsync();
    }

    public async Task MarkAsReturned( int bookId, int readerId)
    {
        BookTransaction bookTransaction = await context.BookTransactions.FirstAsync(t => t.ReaderId == readerId && t.BookId == bookId);

        bookTransaction.IsReturned = true;
        bookTransaction.ReturnedDate = DateTime.Now;

        await context.SaveChangesAsync();
    }
}