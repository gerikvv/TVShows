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

namespace TVShows
{
	/// <summary>
	/// Interaction logic for Cap.xaml
	/// </summary>
	public partial class Cap : UserControl
	{
		public Cap()
		{
			this.InitializeComponent();
		}

        private void Autorisation_click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("Autorisation.xaml", UriKind.Relative));
        }

        private void Home_click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("Home.xaml", UriKind.Relative));
        }

        private void Registration_click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("Registration.xaml", UriKind.Relative));
        }

        private void Add_user_click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("AddUser.xaml", UriKind.Relative));
        }

        private void Users_view_click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("UsersView.xaml", UriKind.Relative));
        }

        private void Add_tv_click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("AddTV.xaml", UriKind.Relative));
        }

        private void Favorites_click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("Favorites.xaml", UriKind.Relative));
        }
	}
}