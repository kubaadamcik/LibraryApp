using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.Application.Interfaces;
using ZaverecnyProjekt.View.Windows;

namespace ZaverecnyProjekt;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IReaderService _readerService { get; set; }

    public MainWindow(IReaderService readerService)
    {
        InitializeComponent();

        _readerService = readerService;
    }

    private void RegisterUser(object sender, RoutedEventArgs e)
    {
        ReaderManagement readerWindow = new ReaderManagement(_readerService);

        readerWindow.Show();
    }
}