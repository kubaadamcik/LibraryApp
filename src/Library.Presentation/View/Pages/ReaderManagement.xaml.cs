using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Pages;

public partial class ReaderManagement : Page
{
    private IReaderService _readerService;
    private List<User> _readers { get; set; }

    public ReaderManagement(IReaderService readerService)
    {
        InitializeComponent();

        _readerService = readerService;

        TbReaderName.Text = "Pavel Novák";
        TbReaderName.Opacity = 0.5;

        GetAllReaders();
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

        User user = new User() {FullName = TbReaderName.Text, Email = TbReaderEmail.Text};

        if (!await _readerService.AddReader(user))
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

        ListBox lb = sender as ListBox;

        if (lb.SelectedIndex == -1) return;

        User reader = _readers[lb.SelectedIndex];

        LvReaderInfo.Items.Add(reader.Id);
        LvReaderInfo.Items.Add(reader.FullName);
        LvReaderInfo.Items.Add(reader.Email);
    }

    private void NavigateBack(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}