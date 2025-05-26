using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class LibraryService(Reader reader,
    IBookService bookService,
    IBookTransactionService transactionService) : ILibraryService
{
    public async Task<bool> BorrowBook(int bookId)
    {
        var book = await bookService.GetBookWithId(bookId);
        if (book is null || book.Count < 1) return false;
        
        await bookService.BorrowBook(bookId);
        await transactionService.CreateTransaction(bookId, reader.Id);
        
        return true;
    }

    public async Task<bool> ReturnBook(int bookId)
    {
        var book = await bookService.GetBookWithId(bookId);
        if (book is null) return false;
        
        await bookService.ReturnBook(bookId);
        await transactionService.MarkAsReturned(reader.Id, bookId);
        
        return true;
    }
}