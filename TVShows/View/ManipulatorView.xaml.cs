using System.Windows;
using System.Windows.Controls;

namespace TVShows
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class ManipulatorView : Window
    {
        public ManipulatorView(ManipulatorViewModel view_model)
        {
            InitializeComponent();
            this.DataContext = view_model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Btn_close(object sender, RoutedEventArgs e)
        {
            var control = new UserViewControl();
            var mainWindow = (Main_window)Application.Current.MainWindow;
            mainWindow.RandomTVShow.Content = control;
        }    
    }
}
