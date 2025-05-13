using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;

namespace ZaverecnyProjekt.View.Pages;

public partial class BorrowBook : Page
{
    private IBookService _bookService;
    public BorrowBook(IBookService bookService)
    {
        InitializeComponent();

        _bookService = bookService;

        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {

    }

    private void RemoveSearchPlaceholder(object sender, RoutedEventArgs e)
    {
        lbl_searchPlaceholder.Visibility = Visibility.Collapsed;
    }

    private void NavigateBack(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void SelectReader(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}