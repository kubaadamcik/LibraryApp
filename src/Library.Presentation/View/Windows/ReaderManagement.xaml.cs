using System.Windows;
using Library.Application.Services;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Windows;

public partial class ReaderManagement : Window
{
    private ReaderService _readerService;

    public ReaderManagement()
    {
        InitializeComponent();
    }
    
    public ReaderManagement(ReaderService readerService)
    {
        _readerService = readerService;
        

        TbReaderName.Text = "Pavel Novák";
        TbReaderName.Opacity = 0.5;

    }

    private async void AddReader(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(TbReaderName.Text))
            return;
        
        User user = new User() {FullName = TbReaderName.Text, Email = "pavelnovak@gmail.com", ReaderInfo = new ReaderInfo()};
        
        await _readerService.AddReader(user);
    }

    private void TbReaderName_OnGotFocus(object sender, RoutedEventArgs e)
    {
        TbReaderName.Text = string.Empty;
        TbReaderName.Opacity = 1;
    }
}