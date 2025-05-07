using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Library.Application.Interfaces;

namespace ZaverecnyProjekt.View.Pages;

public partial class MainPage : Page
{
    private IReaderService _readerService { get; set; }
    public MainPage(IReaderService readerService)
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

    private void RegisterUser(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ReaderManagement(_readerService));
    }
}