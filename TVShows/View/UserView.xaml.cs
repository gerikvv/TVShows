using System.Windows;
using TVShows.ViewModel;

namespace TVShows.View
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView(UserManipulatorViewModel view_model)
        {
            InitializeComponent();
            this.DataContext = view_model;
        }

        private void Btn_save(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }    
    }
}
