using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.ValueObjects;
using ZaverecnyProjekt.View.Dialogs;

namespace ZaverecnyProjekt.View.Pages;

public partial class ReaderManagement : Page
{
    private IReaderService _readerService;
    private IBookTransactionService _bookTransactionService;
    private ILibraryService _libraryService;
    private List<Reader> _readers { get; set; }


    public ReaderManagement(IReaderService readerService, IBookTransactionService bookTransactionService, ILibraryService libraryService)
    {
        InitializeComponent();

        _readerService = readerService;
        _bookTransactionService = bookTransactionService;
        _libraryService = libraryService;


        Loaded += OnLoaded;
    }

    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        await GetAllReaders();
    }

    private async Task GetAllReaders()
    {
        LbReaders.Items.Clear();

        _readers = await _readerService.GetAllReaders();

        foreach (var reader in _readers)
        {
            LbReaders.Items.Add(reader.FullName);
        }
    }

    private async void AddReader(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(TbReaderName.Text))
        {
            MessageBox.Show("Zadejte jméno čtenáře", "Chyba", MessageBoxButton.OK);
            return;
        }

        if (!Email.IsValid(TbReaderEmail.Text))
        {
            MessageBox.Show("Zadejte správně emailovou adresu", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        Reader reader = new Reader() {FullName = TbReaderName.Text, Email = TbReaderEmail.Text};

        if (!await _readerService.AddReader(reader))
        {
            MessageBox.Show("Uživatel se nevytvořil", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        await GetAllReaders();
    }

    private void RemovePlaceholder(object sender, RoutedEventArgs e)
    {
        TbReaderName.Text = string.Empty;
        TbReaderName.Opacity = 1;

    }

    private void ShowReaderInfo(object sender, SelectionChangedEventArgs e)
    {
        ListBox lb = sender as ListBox;

        if (lb.SelectedIndex == -1) return;

        Reader reader = _readers[lb.SelectedIndex];
    }

    private void NavigateBack(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void RemoveReader(object sender, RoutedEventArgs e)
    {
        _readerService.RemoveReader(_readers[LbReaders.SelectedIndex]);
    }

    private async void ShowReaderBorrowedBooks(object sender, RoutedEventArgs e)
    {
        if (LbReaders.SelectedIndex == -1) return;
        
        var reader = _readers[LbReaders.SelectedIndex];

        var transactions = await _bookTransactionService.GetReaderTransactions(reader.Id);

        var dialog = new ShowReaderTransactions(_libraryService, _bookTransactionService, transactions);
        
        dialog.ShowDialog();
    }
}