using System.Windows;
using System.Windows.Input;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Dialogs;

public partial class SelectReaderDialog : Window
{
    private IReaderService _readerService { get; set; }
    private ILibraryService _libraryService { get; set; }
    private IBookService _bookService { get; set; }
    private List<Reader> _readers { get; set; }
    private int bookId { get; set; }

    public SelectReaderDialog(IReaderService readerService, ILibraryService libraryService, int bookId,
        IBookService bookService)
    {
        InitializeComponent();

        _readerService = readerService;
        _libraryService = libraryService;
        _bookService = bookService;
        this.bookId = bookId;

        _ = GetAllReaders();
    }

    private async Task GetAllReaders()
    {
        _readers = await _readerService.GetAllReaders();

        foreach (var reader in _readers)
        {
            LbReaders.Items.Add(reader.FullName);
        }
    }

    private async void BorrowBook(object sender, RoutedEventArgs e)
    {
        if (LbReaders.SelectedIndex < 0) return;

        var reader = _readers[LbReaders.SelectedIndex];

        if (await _libraryService.BorrowBook(bookId, reader.Id))
        {
            var book = await _bookService.GetBookWithId(bookId);
            MessageBox.Show($"Kniha byla {book.Title} vypůjčena uživateli {reader.FullName}", "Úspěch",
                MessageBoxButton.OK, MessageBoxImage.Information);

            return;
        }

        MessageBox.Show("Nastala neznámá chyba při půjčování knihy", "Chyba", MessageBoxButton.OK,
            MessageBoxImage.Error);
    }
}