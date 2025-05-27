using System.Windows;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Dialogs;

public partial class ShowReaderTransactions  : Window
{
    private ILibraryService _libraryService { get; set; }
    private IBookTransactionService _bookTransactionService { get; set; }
    private int readerId { get; set; }
    public ShowReaderTransactions(ILibraryService libraryService, IBookTransactionService bookTransactionService, int readerId)
    {
        InitializeComponent();

        _libraryService = libraryService;
        _bookTransactionService = bookTransactionService;

        this.readerId = readerId;

        FetchTransactions();
    }

    private async Task<List<BookTransaction>> FetchTransactions()
    {
        await _bookTransactionService.CountReaderBorrowedBooks(readerId);

        // TODO
        return null;
    }
}