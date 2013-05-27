using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

            var control = new RandomTVShowControl();
            mainWindow.RandomTVShow.Content = control.Content;
        }
    }
}