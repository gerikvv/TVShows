using System.Windows;
using System.Windows.Controls;
using TVShows.Data;

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
            Class_man man;
            Message.Text = "";
            Message.Text = Class_user.Registration(TbLogin.Text, Password1.Password, Password2.Password, TbEmail.Text, out man);
            
            var mainWindow = (Main_window)Application.Current.MainWindow;
            mainWindow.Log_in(man);

            mainWindow.Cap.BtnLogout.IsEnabled = true;
        }
    }
}