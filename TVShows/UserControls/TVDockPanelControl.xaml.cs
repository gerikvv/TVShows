using System.Windows;
using System.Windows.Controls;
using TVShows.Data;

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

            if (mainWindow.Man.GetType() == typeof(Class_user))
                Class_favorites_and_user.Items.Add
                    (new Class_favorites_and_user((Class_user)mainWindow.Man, (Class_tvshow)DataContext));
            else Class_favorites_and_admin.Items.Add
                    (new Class_favorites_and_admin((Class_administrator)mainWindow.Man, (Class_tvshow)DataContext));

            Star.IsEnabled = false;
        }
    }
}
