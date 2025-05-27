using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class LibraryService(
    IReaderService readerService,
    IBookService bookService,
    IBookTransactionService transactionService) : ILibraryService
{
    public async Task<bool> BorrowBook(int bookId, int readerId)
    {
        var book = await bookService.GetBookWithId(bookId);
        if (book is null) return false;

        await bookService.BorrowBook(bookId);
        await transactionService.CreateTransaction(bookId, readerId);

        return true;
    }

    public async Task<bool> ReturnBook(int bookId, int readerId)
    {
        var book = await bookService.GetBookWithId(bookId);
        if (book is null) return false;

        await bookService.ReturnBook(bookId);
        await transactionService.MarkAsReturned(readerId, bookId);

        return true;
    }
}