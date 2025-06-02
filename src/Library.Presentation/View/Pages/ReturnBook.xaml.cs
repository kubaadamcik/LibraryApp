using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Pages;

public partial class ReturnBook : Page
{
    private IReaderService _readerService;
    private IBookService _bookService;
    private ILibraryService _libraryService;
    private IBookTransactionService _bookTransactionService;
    private List<Reader> _readers { get; set; }

    public ReturnBook(IReaderService readerService, IBookTransactionService bookTransactionService)
    {
        InitializeComponent();
        _readerService = readerService;
        _bookTransactionService = bookTransactionService;

        UpdateListboxes();
    }

    private async void UpdateListboxes()
    {
        _readers = await _readerService.GetAllReaders();

        LbReaders.Items.Clear();
        LbBooks.Items.Clear();

        foreach (var reader in _readers)
        {
            LbReaders.Items.Add(reader.FullName);
        }
    }

    private void NavigateBack(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private async void ReturnBook_Click(object sender, RoutedEventArgs e)
    {
        // Implementace vrácení knihy
    }

    private async void ShowBorrowedBooks(object sender, SelectionChangedEventArgs e)
    {
        ListBox listbox = (ListBox)sender;

        Reader reader = _readers[listbox.SelectedIndex];

        List<BookTransaction> transactions = await _bookTransactionService.GetReaderTransactions(reader.Id);

        LbBooks.Items.Clear();

        foreach (var transaction in transactions)
        {
            Book book = await _bookService.GetBookWithId(transaction.BookId);
            LbBooks.Items.Add(book.Title);
        }
    }
}