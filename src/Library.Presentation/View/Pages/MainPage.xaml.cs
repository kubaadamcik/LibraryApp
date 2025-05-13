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

        //Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is Window window)
        {
            window.Height = this.Height;
            window.Width = this.Width;
        }
    }

    private void ManageReaders(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ReaderManagement(_readerService));
    }

    private void BorrowBook(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new BorrowBook(_bookService));
    }
    
    private void ReturnBook(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ReturnBook(_readerService));
    }
    
    private void ShowBooks(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ShowBooks(_readerService));
    }
    
    private void ManageUsers(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ManageUsers(_readerService));
    }
    
    private void Settings(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Settings(_readerService));
    }
    
    private void ManageBorrows(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ManageBorrows(_readerService));
    }
    
    private void Settings(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Settings(_readerService));
    }
}