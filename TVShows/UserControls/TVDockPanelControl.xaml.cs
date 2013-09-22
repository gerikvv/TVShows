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
        public TVDockPanelControl()
        {
            InitializeComponent();
        }

        private void Favorites_click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var mainWindow = (Main_window)Application.Current.MainWindow;
            Class_favorites_and_man.Items.Add(new Class_favorites_and_man(mainWindow.Man, (Class_tvshow)DataContext));
        }
    }
}
