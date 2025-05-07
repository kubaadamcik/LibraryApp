using System.Windows;
using System.Windows.Controls;

namespace ZaverecnyProjekt.View.Pages;

public partial class BorrowBook : Page
{
    public BorrowBook()
    {
        InitializeComponent();
    }

    private void RemoveSearchPlaceholder(object sender, RoutedEventArgs e)
    {
        lbl_searchPlaceholder.Visibility = Visibility.Collapsed;
    }
}