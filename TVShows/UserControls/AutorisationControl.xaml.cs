using System.Windows;
using System.Windows.Controls;
using TVShows.Data;

namespace TVShows
{
	/// <summary>
	/// Interaction logic for AutorisationContol.xaml
	/// </summary>
	public partial class AutorisationContol : UserControl
	{
		public AutorisationContol()
		{
			this.InitializeComponent();
		}

        private void Btn_login_click(object sender, RoutedEventArgs e)
        {
            Class_man man;
            Message.Text = "";
            Message.Text = Class_man.Login(TbLogin.Text, Password.Password, out man);

            var mainWindow = (Main_window)Application.Current.MainWindow;
            mainWindow.Log_in(man);
            
            mainWindow.Cap.BtnLogout.IsEnabled = true;
        }
	}
}