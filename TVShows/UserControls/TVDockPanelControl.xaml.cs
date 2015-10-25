using System.Windows;
using System.Windows.Controls;
using TVShows.Data;
using TVShows.Data.Classes;

namespace TVShows
{
    /// <summary>
    /// Логика взаимодействия для TVDockPanelControl.xaml
    /// </summary>
    public partial class TVDockPanelControl : UserControl
    {
        private static TVDockPanelControl tvDockPanelControl;
        public TVDockPanelControl() { this.InitializeComponent(); }

        public static TVDockPanelControl Instance()
        {
            return tvDockPanelControl ?? (tvDockPanelControl = new TVDockPanelControl());
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (Main_window)Application.Current.MainWindow;

            if (mainWindow.Man.GetType() == typeof(User))
                new Favorites_and_user((User)mainWindow.Man, (Tvshow)DataContext);
            else 
                new Favorites_and_admin((Administrator)mainWindow.Man, (Tvshow)DataContext);

            Star.IsEnabled = false;
        }
    }
}
