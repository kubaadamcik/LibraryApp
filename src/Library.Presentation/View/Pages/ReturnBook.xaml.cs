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
    private List<BookTransaction> _transactions { get; set; }
    
    // Opravený konstruktor - přidán ILibraryService parametr
    public ReturnBook(IReaderService readerService, IBookTransactionService bookTransactionService, IBookService bookService, ILibraryService libraryService)
    {
        InitializeComponent();
        _readerService = readerService;
        _bookTransactionService = bookTransactionService;
        _bookService = bookService;
        _libraryService = libraryService; // Inicializace _libraryService

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
        // Odstraněno nesprávné převádění sender na ListBox
        // Přidány potřebné kontroly null
        if (LbReaders.SelectedIndex < 0 || LbBooks.SelectedIndex < 0 || 
            _readers == null || _transactions == null ||
            LbReaders.SelectedIndex >= _readers.Count || 
            LbBooks.SelectedIndex >= _transactions.Count)
            return;  
        
        await _libraryService.ReturnBook(_readers[LbReaders.SelectedIndex].Id, _transactions[LbBooks.SelectedIndex].BookId);
        UpdateListboxes();
    }

    private async void ShowBorrowedBooks(object sender, SelectionChangedEventArgs e)
    {
        ListBox listbox = (ListBox)sender;

        if (listbox.SelectedIndex < 0 || _readers == null || listbox.SelectedIndex >= _readers.Count)
            return;

        Reader reader = _readers[listbox.SelectedIndex];

        _transactions = await _bookTransactionService.GetReaderTransactions(reader.Id);

        LbBooks.Items.Clear();

        foreach (var transaction in _transactions)
        {
            if (transaction.IsReturned == false)
            {
                Book book = await _bookService.GetBookWithId(transaction.BookId);
                LbBooks.Items.Add(book.Title);
            }
        }
    }
}