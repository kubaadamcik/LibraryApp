using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Pages;

public partial class BorrowBook : Page
{
    public ObservableCollection<Book> BooksCollection { get; set; }

    public List<Book> Books { get; set; }
    private IReaderService _readerService { get; set; }
    private IBookService _bookService { get; set; }

    public BorrowBook(IReaderService readerService, IBookService bookService)
    {
        InitializeComponent();

        _readerService = readerService;

        Loaded += OnLoaded;

        _bookService = bookService;

        GetAllBooks();
    }

    private async Task GetAllBooks()
    {
        Books = await _bookService.GetAllBooks();
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is Window window)
        {
            window.Height = this.Height;
            window.Width = this.Width;
        }
    }

    private void RemoveSearchPlaceholder(object sender, RoutedEventArgs e)
    {
        lbl_searchPlaceholder.Visibility = Visibility.Collapsed;
    }

    private void NavigateBack(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}