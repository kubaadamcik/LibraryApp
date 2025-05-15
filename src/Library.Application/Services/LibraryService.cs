using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class LibraryService(Reader reader,
    IBookService bookService,
    IReaderService readerService,
    IBookTransactionService transactionService) : ILibraryService
{
    // TODO: Implement these methods
    public async Task<bool> BorrowBook(int bookId)
    {
        var book = await bookService.GetBookWithId(bookId);
        if (book is null || book.Count < 1) return false;
        
        await bookService.BorrowBook(bookId);
        // TODO: Update  ReaderInfo
        // TODO: Use BookTransactionService here
        
        return true;
    }

    public async Task<bool> ReturnBook(int bookId)
    {
        var book = await bookService.GetBookWithId(bookId);
        if (book is null) return false;
        
        await bookService.ReturnBook(bookId);
        // TODO: Update  ReaderInfo
        // TODO: Use BookTransactionService here
        
        return true;
    }
}