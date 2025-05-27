using System.Windows;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Dialogs;

public partial class ShowReaderTransactions  : Window
{
    private ILibraryService _libraryService { get; set; }
    private IBookTransactionService _bookTransactionService { get; set; }
    private List<Book> _books { get; set; }
    private int readerId { get; set; }
    public ShowReaderTransactions(ILibraryService libraryService, IBookTransactionService bookTransactionService, int readerId)
    {
        InitializeComponent();

        _libraryService = libraryService;
        _bookTransactionService = bookTransactionService;

        this.readerId = readerId;

        GetBorrowedBooks();
    }

    private async Task GetBorrowedBooks()
    {
        _books = await _bookTransactionService.GetReaderBorrowedBooks(readerId);

        LbBooks.Items.Clear();
        
        foreach (var book in _books)
        {
            LbBooks.Items.Add(book.Title);
        }
    }

    private void ReturnBook(object sender, RoutedEventArgs e)
    {
        var book = _books[LbBooks.SelectedIndex];
        
    }
}