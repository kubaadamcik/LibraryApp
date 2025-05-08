using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Pages;

public partial class ReaderManagement : Page
{
    private IReaderService _readerService;
    private List<Reader> _readers { get; set; }


    public ReaderManagement(IReaderService readerService)
    {
        InitializeComponent();

        _readerService = readerService;


        GetAllReaders();

        _readerService.ContextChanged += GetAllReaders;
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
        if (string.IsNullOrEmpty(TbReaderName.Text) || string.IsNullOrEmpty(TbReaderEmail.Text))
            return;

        Reader reader = new Reader() {FullName = TbReaderName.Text, Email = TbReaderEmail.Text, ReaderInfo = new ReaderInfo()};

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
        LvReaderInfo.Items.Clear();

        btn_removeReader.Visibility = Visibility.Visible;
        btn_showBorrowedBooks.Visibility = Visibility.Visible;

        ListBox lb = sender as ListBox;

        if (lb.SelectedIndex == -1) return;

        Reader reader = _readers[lb.SelectedIndex];

        LvReaderInfo.Items.Add($"Id čtenáře: {reader.Id}");
        LvReaderInfo.Items.Add($"Jméno: {reader.FullName}");
        LvReaderInfo.Items.Add($"Emailová adresa: {reader.Email}");
        LvReaderInfo.Items.Add($"Počet půjčených knih: {reader.ReaderInfo.BorrowedBooksCount}");
    }

    private void NavigateBack(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void RemoveReader(object sender, RoutedEventArgs e)
    {
        _readerService.RemoveReader(_readers[LbReaders.SelectedIndex]);
    }
}