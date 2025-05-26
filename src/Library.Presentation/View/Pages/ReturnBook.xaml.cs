using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;

namespace ZaverecnyProjekt.View.Pages;

public partial class ReturnBook : Page
{
    private IReaderService _readerService;

    public ReturnBook(IReaderService readerService)
    {
        InitializeComponent();

        _readerService = readerService;

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
    
    private void OnReaderSelected(object sender, SelectionChangedEventArgs e)
    {
        // Zde načtete knihy vybraného čtenáře
    }

    private void ReturnBook_Click(object sender, RoutedEventArgs e)
    {
        // Zde implementujete logiku pro vrácení knihy
    }


    private void NavigateBack(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    // Add your logic for the specific page here
}