using System.Collections.ObjectModel;
using System.Windows;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Dialogs;

public partial class ShowReaderTransactions  : Window
{
    private ILibraryService _libraryService { get; set; }
    private IBookTransactionService _bookTransactionService { get; set; }
    public ObservableCollection<BookTransaction> Transactions { get; set; }
    
    public ShowReaderTransactions(ILibraryService libraryService, IBookTransactionService bookTransactionService, List<BookTransaction> transactions)
    {
        _libraryService = libraryService;
        _bookTransactionService = bookTransactionService;
        Transactions = new ObservableCollection<BookTransaction>(transactions);


        DataContext = this;

        InitializeComponent();
    }
    
    
    private async Task ReturnBook()
    {
        
    }
}