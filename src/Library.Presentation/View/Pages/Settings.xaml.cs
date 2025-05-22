using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Library.Application.Interfaces;

namespace ZaverecnyProjekt.View.Pages
{
    public partial class Settings : Page
    {
        private Brush _originalBackground;

        public Settings(IReaderService readerservice)
        {
            InitializeComponent();

            // Uložíme původní barvu pozadí
            _originalBackground = this.Background;

            // Nastavení výchozího stavu CheckBoxu
            DarkModeToggle.IsChecked = false;
        }

        private void NavigateBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DarkModeToggle_Checked(object sender, RoutedEventArgs e)
        {
            ThemeManager.Instance.SetTheme(true);
        }

        private void DarkModeToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ThemeManager.Instance.SetTheme(false);
        }

        private void ResetSettings_Click(object sender, RoutedEventArgs e)
        {
            DarkModeToggle.IsChecked = false;
            ThemeManager.Instance.SetTheme(false);
        }


        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}