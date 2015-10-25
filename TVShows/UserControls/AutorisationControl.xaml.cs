using System.Windows;
using System.Windows.Controls;
using TVShows.Data.Classes;

namespace TVShows.UserControls
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
            Man man;
            Message.Text = "";
            Message.Text = Man.Login(TbLogin.Text, Password.Password, out man);

            var mainWindow = (Main_window)Application.Current.MainWindow;
            mainWindow.Log_in(man);
            
            mainWindow.Cap.BtnLogout.IsEnabled = true;
        }
	}
}