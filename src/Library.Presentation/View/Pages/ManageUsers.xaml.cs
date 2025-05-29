using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Pages;

public partial class ManageUsers : Page
{
    private readonly IReaderService _readerService;
    private List<Reader> _readers;

    public ManageUsers(IReaderService readerService)
    {
        InitializeComponent();
        _readerService = readerService;
        LoadReaders();
    }

    private async void LoadReaders()
    {
        LbReaders.Items.Clear();
        _readers = await _readerService.GetAllReaders();

        foreach (var reader in _readers)
        {
            LbReaders.Items.Add(reader.FullName);
        }
    }

    private void NavigateBack(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void ShowReaderInfo(object sender, SelectionChangedEventArgs e)
    {
        if (LbReaders.SelectedIndex == -1) return;

        var reader = _readers[LbReaders.SelectedIndex];

        TbReaderDetails.Text =
            $"Id čtenáře: {reader.Id}\n" +
            $"Jméno: {reader.FullName}\n" +
            $"Email: {reader.Email}";

        btn_removeReader.Visibility = Visibility.Visible;
        btn_showBorrowedBooks.Visibility = Visibility.Visible;
    }

    private async void RemoveReader(object sender, RoutedEventArgs e)
    {
        if (LbReaders.SelectedIndex == -1) return;

        var reader = _readers[LbReaders.SelectedIndex];

        if (MessageBox.Show($"Opravdu chcete vymazat čtenáře {reader.FullName}?", "Potvrzení",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
            await _readerService.RemoveReader(reader);
            LoadReaders();
            TbReaderDetails.Text = "";
            btn_removeReader.Visibility = Visibility.Collapsed;
            btn_showBorrowedBooks.Visibility = Visibility.Collapsed;
        }
    }
}