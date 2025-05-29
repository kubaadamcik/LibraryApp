using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;

namespace ZaverecnyProjekt.View.Pages;

public partial class ReturnBook : Page
{
    private IReaderService _readerService;
    private IBookService _bookService;
    private ILibraryService _libraryService;

    public ReturnBook(IReaderService readerService)
    {
        InitializeComponent();
        _readerService = readerService;
        
        UpdateListboxes();
    }

    private async void UpdateListboxes()
    {
        var readers = await _readerService.GetAllReaders();

        LbReaders.Items.Clear();
        LbBooks.Items.Clear();

        foreach (var reader in readers)
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
}