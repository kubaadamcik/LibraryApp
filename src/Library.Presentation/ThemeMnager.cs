using System;
using System.Windows;
using System.Windows.Media;

namespace ZaverecnyProjekt
{
    public class ThemeManager
    {
        private static ThemeManager _instance;
        public static ThemeManager Instance => _instance ??= new ThemeManager();

        public bool IsDarkTheme { get; private set; }

        private readonly SolidColorBrush _darkBackground = new(Color.FromRgb(87, 87, 87));
        private readonly SolidColorBrush _lightBackground = new(Color.FromRgb(235, 235, 235));
        private readonly SolidColorBrush _darkForeground = new(Color.FromRgb(255, 255, 255));
        private readonly SolidColorBrush _lightForeground = new(Color.FromRgb(0, 0, 0));
        private readonly SolidColorBrush _lightbuttonBackground = new(Color.FromRgb(217, 217, 217));
        private readonly SolidColorBrush _darkbuttonBackground = new(Color.FromRgb(133, 133, 133));
        private readonly SolidColorBrush _darkbuttonForeground = new(Color.FromRgb(255, 255, 255));
        private readonly SolidColorBrush _lightbuttonForeground = new(Color.FromRgb(0, 0, 0));
        private readonly SolidColorBrush _lightTrigger = new(Color.FromRgb(196, 196, 196));
        private readonly SolidColorBrush _darkTrigger = new(Color.FromRgb(69, 69, 69));

        public void SetTheme(bool isDark)
        {
            IsDarkTheme = isDark;

            var resources = Application.Current.Resources;
            resources["BackgroundBrush"] = isDark ? _darkBackground : _lightBackground;
            resources["ForegroundBrush"] = isDark ? _darkForeground : _lightForeground;
            resources["ButtonBackgroundBrush"] = isDark ? _darkbuttonBackground : _lightbuttonBackground;
            resources["ButtonForegroundBrush"] = isDark ? _darkbuttonForeground : _lightbuttonForeground;
            resources["ButtonTriggerBrush"] = isDark ? _darkTrigger : _lightTrigger;
    }
    }
}