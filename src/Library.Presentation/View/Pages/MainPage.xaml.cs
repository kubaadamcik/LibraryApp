using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Library.Application.Interfaces;

namespace ZaverecnyProjekt.View.Pages;

public partial class MainPage : Page
{
    private IReaderService _readerService { get; set; }
    private IBookService _bookService { get; set; }
    public MainPage(IReaderService readerService, IBookService bookService)
    {
        InitializeComponent();

        _readerService = readerService;
        _bookService = bookService;

        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is Window window)
        {
            window.Height = this.Height;
            window.Width = this.Width;
        }
    }

    private void RegisterUser(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ReaderManagement(_readerService));
    }

    private void BorrowBook(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new BorrowBook(_readerService, _bookService));
    }
}