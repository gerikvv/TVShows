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

        private void Button1_click(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text != "" & TbEmail.Text != "" & Password1.Password != "" & Password1.Password == Password2.Password)
            {
                var user = new Class_user();
                user.Get(Class_user.Dtable);

                if (Class_user.Items.Count > 0)
                {
                    user.Name = TbLogin.Text;
                    user.Password = Password1.Password;
                    user.Email = TbEmail.Text;

                    foreach (var item in Class_user.Items)
                    {
                        if (user.Name != item.Name | user.Password != item.Password | user.Email != item.Email) ;
                        return;
                    }
                    user.Save(Class_user.Dtable);
                }

                else new Class_user(TbLogin.Text, Password1.Password, TbEmail.Text);
            }
        }
	}
}