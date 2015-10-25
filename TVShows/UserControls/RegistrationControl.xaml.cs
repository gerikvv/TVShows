using System.Windows;
using System.Windows.Controls;
using TVShows.Data;
using TVShows.Data.Classes;

namespace TVShows
{
    /// <summary>
    /// Interaction logic for RegistrationControl.xaml
    /// </summary>
    public partial class RegistrationControl : UserControl
    {
        public RegistrationControl()
        {
            this.InitializeComponent();
        }

        private void Registration_click(object sender, RoutedEventArgs e)
        {
            Man man;
            Message.Text = "";
            Message.Text = User.Registration(TbLogin.Text, Password1.Password, Password2.Password, TbEmail.Text, out man);
            
            var mainWindow = (Main_window)Application.Current.MainWindow;
            mainWindow.Log_in(man);

            mainWindow.Cap.BtnLogout.IsEnabled = true;
        }
    }
}